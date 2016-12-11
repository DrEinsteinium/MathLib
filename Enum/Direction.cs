using UnityEngine;
using System.Collections;

namespace MathLib.Enum
{
    public enum Direction
    {
        North, 
        South,
        East,
        West,

        NorthEast,
        SouthEast,
        NorthWest,
        SouthWest,
    }

    public static class DirectionExtensions
    {
        /// <summary>
        /// Returns the opposite direction based on the given direction. 
        /// Ex: north->south, east->west, northeast->southwest... ect
        /// </summary>
        public static Direction Inverse(this Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    return Direction.South;
                case Direction.South:
                    return Direction.North;
                case Direction.East:
                    return Direction.West;
                case Direction.West:
                    return Direction.East;
                case Direction.NorthWest:
                    return Direction.SouthEast;
                case Direction.NorthEast:
                    return Direction.SouthWest;
                case Direction.SouthEast:
                    return Direction.NorthWest;
                case Direction.SouthWest:
                    return Direction.NorthEast;
            }


            return Direction.North;
        }

        public static Vector3 ToVector2(this Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    return new Vector2(1, 0);
                case Direction.South:
                    return new Vector2(-1, 0);
                case Direction.East:
                    return new Vector2(0, 1);
                case Direction.West:
                    return new Vector2(0, -1);


                case Direction.NorthEast:
                    return Direction.North.ToVector2() + Direction.East.ToVector2();
                case Direction.NorthWest:          
                    return Direction.North.ToVector2() + Direction.West.ToVector2();
                case Direction.SouthEast:          
                    return Direction.South.ToVector2() + Direction.East.ToVector2();
                case Direction.SouthWest:          
                    return Direction.South.ToVector2() + Direction.West.ToVector2();
            }

            return Vector2.zero;
        }
        public static Vector3 ToVector3(this Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    return new Vector3(1,0,0);
                case Direction.South:
                    return new Vector3(-1,0,0);
                case Direction.East:
                    return new Vector3(0,0,1);
                case Direction.West:
                    return new Vector3(0,0,-1);


                case Direction.NorthEast:
                    return Direction.North.ToVector3() + Direction.East.ToVector3();
                case Direction.NorthWest:
                    return Direction.North.ToVector3() + Direction.West.ToVector3();
                case Direction.SouthEast:
                    return Direction.South.ToVector3() + Direction.East.ToVector3();
                case Direction.SouthWest:
                    return Direction.South.ToVector3() + Direction.West.ToVector3();
            }

            return Vector3.zero ;
        }
    }
}