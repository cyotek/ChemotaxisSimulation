using Cyotek.Collections.Generic;
using System.Drawing;

namespace Cyotek.ChemotaxisSimulation
{
  public class PointBuffer : CircularBuffer<Point>
  {
    #region Public Constructors

    public PointBuffer()
      : base(128)
    {
    }

    #endregion Public Constructors
  }
}