using System;
using System.Drawing;

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

    #endregion Public Methods
  }
}