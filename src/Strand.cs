using Cyotek.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.Demo.EColiSimulation
{
  internal class Strand
  {
    private Point _position;

    public Point Position
    {
      get { return _position; }
      set { _position = value; }
    }

    private CircularBuffer<Point> _previousPositions;

    public CircularBuffer<Point> PreviousPositions
    {
      get { return _previousPositions; }
    }

    public Strand()
    {
      _previousPositions = new CircularBuffer<Point>(128);
      _heading = new Point(1, 1);
    }

    private Point _heading;

    public Point Heading
    {
      get { return _heading; }
      set { _heading = value; }
    }

    private double _previousSensor;

    public double PreviousSensor
    {
      get { return _previousSensor; }
      set { _previousSensor = value; }
    }

    public void Move()
    {
      if (!_heading.IsEmpty)
      {
        _previousPositions.Put(_position);
        _position.X += _heading.X;
        _position.Y += _heading.Y;
      }
    }

    internal void UndoMove()
    {
      _position = _previousPositions.GetLast();
    }
  }
}
