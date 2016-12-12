using UnityEngine;
using System.Collections.Generic;


namespace MathLib.DataStructure
{
    /// <summary>
    /// Generic implementation of a NodeGraph data structure where the Node is a public
    /// data type that has references to both it's parent and it's children.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NodeGraph<T>
    {
        public class Node
        {
            Node parent;
            List<Node> children;
            T data;

            public delegate bool Compare(Node n1, Node n2);

            public Node(Node parent, T data)
            {
                this.parent = parent;
                this.data = data;
            }

            public Node(Node parent, T data, params Node[] children) : this(parent, data)
            {
                this.children = new List<Node>(children);
            }

            public T GetData()
            {
                return this.data;
            }

            public void SetData(T data)
            {
                this.data = data;
            }

            public Node GetParent()
            {
                return this.parent;
            }

            public Node[] GetChildren()
            {
                return this.children.ToArray();
            }

            public void ClearChildren()
            {
                this.children.Clear();
            }

            public int GetChildCount()
            {
                return this.children.Count;
            }

            public void AddChild(T childData)
            {
                Node child = new Node(this, childData);
                this.children.Add(child);
            }

            public bool DeleteChild(Node child)
            {
                return this.children.Remove(child);
            }
        }

        private Node root;
        public delegate void NodeVisitor(Node n);


        public NodeGraph(T rootData)
        {
            this.root = new Node(null, rootData);
        }

        public Node GetRoot()
        {
            return this.root;
        }

        public void Clear()
        {
            Traverse(root, delegate (Node n)
            {
                foreach (Node c in n.GetChildren())
                    c.ClearChildren();
            }, true);
        }

        // Basic depth/breadth first traversal function. 
        public void Traverse(Node start, NodeVisitor function, bool depthFirst = true)
        {
            if (!depthFirst)
            {
                function(start);
            }

            foreach (Node n in start.GetChildren())
            {
                Traverse(n, function, depthFirst);
            }

            if (depthFirst)
            {
                function(start);
            }
        }

        // Finds the first instance of Node with this data
        public Node Find(T data)
        {
            Node ret = null;
            Traverse(root, delegate (Node n)
            {
                if (ret == null)
                    foreach (Node c in n.GetChildren())
                        if (c != null && c.GetData().Equals(data))
                            ret = c;
            }, true);
            return ret;
        }

        public Node Find(Node.Compare comparion)
        {
            Node ret = null;
            Traverse(root, delegate (Node n)
            {
                if(ret == null)
                {
                    foreach (Node c in n.GetChildren())
                        if (c != null && comparion(n, c))
                            ret = c;
                }
            }, true);
            return ret;
        }
    }
}