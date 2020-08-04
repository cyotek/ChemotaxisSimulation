using System;
using System.Drawing;

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal static class Geometry
  {
    #region Public Methods

    public static bool DoesPointIntersectCircle(Point point, Point center, float radius)
    {
      return Geometry.DoesPointIntersectCircle(point.X, point.Y, center.X, center.Y, radius);
    }

    public static bool DoesPointIntersectCircle(float x, float y, float cx, float cy, float radius)
    {
      return Geometry.GetDistance(x, y, cx, cy) < radius;
    }

    public static double GetDistance(float x1, float y1, float x2, float y2)
    {
      float dx;
      float dy;

      dx = x1 - x2;
      dy = y1 - y2;

      return Math.Sqrt((dx * dx) + (dy * dy));
    }

    public static int GetDistance(int x1, int y1, int x2, int y2)
    {
      float dx;
      float dy;

      dx = x1 - x2;
      dy = y1 - y2;

      return (int)Math.Sqrt((dx * dx) + (dy * dy));
    }

    public static int GetDistance(Point p1, Point p2)
    {
      return Geometry.GetDistance(p1.X, p1.Y, p2.X, p2.Y);
    }

    #endregion Public Methods
  }
}