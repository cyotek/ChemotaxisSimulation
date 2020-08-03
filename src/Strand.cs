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
      _strength = 1;
      _generation = 1;
    }

    private int _generation;

    public int Generation
    {
      get { return _generation; }
      set { _generation = value; }
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

    private Environment _environment;

    internal Environment Environment
    {
      get { return _environment; }
      set { _environment = value; }
    }

    public void Move()
    {
      if (!_heading.IsEmpty)
      {
        int x;
        int y;

        _previousPositions.Put(_position);

        x = _position.X + _heading.X;
        y = _position.Y + _heading.Y;

        if (x < 0 || y < 0 || x > _environment.Size.Width - 1 || y > _environment.Size.Height)
        {
          if (_environment.Wrap)
          {
            if (x < 0)
            {
              x = _environment.Size.Width - 1;
            }
            else if (x > _environment.Size.Width - 1)
            {
              x = 1;
            }

            if (y < 0)
            {
              y = _environment.Size.Height - 1;
            }
            else if (y > _environment.Size.Height - 1)
            {
              y = 1;
            }
          }
          else
          {
            _heading = Compass.GetOpposite(_heading);
          }
        }

        _position = new Point(x, y);
      }
    }

    internal void UndoMove()
    {
      _position = _previousPositions.GetLast();
    }

    private int _strength;

    public int Strength
    {
      get { return _strength; }
      set { _strength = value; }
    }

    public Strand Copy()
    {
      return new Strand
      {
        Position = _position,
        Strength = _strength,
        Generation = _generation + 1
      };
    }
  }
}
