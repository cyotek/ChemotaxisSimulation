﻿using System.Drawing;

namespace Cyotek.Demo.EColiSimulation
{
  internal static class Compass
  {
    #region Public Fields

    public static readonly Point East = new Point(1, 0);

    public static readonly Point North = new Point(0, -1);

    public static readonly Point NorthEast = new Point(1, -1);

    public static readonly Point NorthWest = new Point(-1, -1);

    public static readonly Point South = new Point(0, 1);

    public static readonly Point SouthEast = new Point(1, 1);

    public static readonly Point SouthWest = new Point(-1, 1);

    public static readonly Point West = new Point(-1, 0);

    #endregion Public Fields

    #region Public Methods

    public static Point GetNext(Point current)
    {
      Point result;

      if (current == Compass.North)
      {
        result = Compass.NorthEast;
      }
      else if (current == Compass.NorthEast)
      {
        result = Compass.East;
      }
      else if (current == Compass.East)
      {
        result = Compass.SouthEast;
      }
      else if (current == Compass.SouthEast)
      {
        result = Compass.South;
      }
      else if (current == Compass.South)
      {
        result = Compass.SouthWest;
      }
      else if (current == Compass.SouthWest)
      {
        result = Compass.West;
      }
      else if (current == Compass.West)
      {
        result = Compass.NorthWest;
      }
      else if (current == Compass.NorthWest)
      {
        result = Compass.North;
      }
      else
      {
        result = Point.Empty;
      }

      return result;
    }

    public static Point GetOpposite(Point current)
    {
      Point result;

      if (current == Compass.North)
      {
        result = Compass.South;
      }
      else if (current == Compass.NorthEast)
      {
        result = Compass.SouthWest;
      }
      else if (current == Compass.East)
      {
        result = Compass.West;
      }
      else if (current == Compass.SouthEast)
      {
        result = Compass.NorthWest;
      }
      else if (current == Compass.South)
      {
        result = Compass.North;
      }
      else if (current == Compass.SouthWest)
      {
        result = Compass.NorthEast;
      }
      else if (current == Compass.West)
      {
        result = Compass.East;
      }
      else if (current == Compass.NorthWest)
      {
        result = Compass.SouthEast;
      }
      else
      {
        result = Point.Empty;
      }

      return result;
    }

    public static Point GetPrevious(Point current)
    {
      Point result;

      if (current == Compass.North)
      {
        result = Compass.NorthWest;
      }
      else if (current == Compass.NorthWest)
      {
        result = Compass.West;
      }
      else if (current == Compass.West)
      {
        result = Compass.SouthWest;
      }
      else if (current == Compass.SouthWest)
      {
        result = Compass.South;
      }
      else if (current == Compass.South)
      {
        result = Compass.SouthEast;
      }
      else if (current == Compass.SouthEast)
      {
        result = Compass.East;
      }
      else if (current == Compass.East)
      {
        result = Compass.NorthEast;
      }
      else if (current == Compass.NorthEast)
      {
        result = Compass.North;
      }
      else
      {
        result = Point.Empty;
      }

      return result;
    }

    #endregion Public Methods
  }
}