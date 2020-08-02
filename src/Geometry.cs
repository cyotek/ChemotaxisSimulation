using System;
using System.Drawing;
using System.Reflection;

namespace Cyotek.Demo.EColiSimulation
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
      float dx;
      float dy;
      double distance;

      dx = x - cx;
      dy = y - cy;
      distance = Math.Sqrt((dx * dx) + (dy * dy));

      return distance < radius;
    }

    public static int GetDistance(int x1, int y1, int x2, int y2)
    {
      return (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public static int GetDistance(Point p1, Point p2)
    {
      return (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }

    #endregion Public Methods
  }
}