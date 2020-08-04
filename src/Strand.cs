using Cyotek.Collections.Generic;
using System.Drawing;

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal class Strand
  {
    #region Private Fields

    private Simulation _environment;

    private int _generation;

    private Point _heading;

    private Point _position;

    private CircularBuffer<Point> _previousPositions;

    private double _previousSensor;

    private int _strength;

    #endregion Private Fields

    #region Public Constructors

    public Strand()
    {
      _previousPositions = new CircularBuffer<Point>(128);
      _heading = new Point(1, 1);
      _strength = 100;
      _generation = 1;
    }

    #endregion Public Constructors

    #region Public Properties

    public int Generation
    {
      get { return _generation; }
      set { _generation = value; }
    }

    public Point Heading
    {
      get { return _heading; }
      set { _heading = value; }
    }

    public Point Position
    {
      get { return _position; }
      set { _position = value; }
    }

    public CircularBuffer<Point> PreviousPositions
    {
      get { return _previousPositions; }
    }

    public double PreviousSensor
    {
      get { return _previousSensor; }
      set { _previousSensor = value; }
    }

    public int Strength
    {
      get { return _strength; }
      set { _strength = value; }
    }

    #endregion Public Properties

    #region Internal Properties

    internal Simulation Environment
    {
      get { return _environment; }
      set { _environment = value; }
    }

    #endregion Internal Properties

    #region Public Methods

    public Strand Copy()
    {
      return new Strand
      {
        Position = _position,
        Strength = _strength,
        Generation = _generation + 1
      };
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

            _position = new Point(x, y);
          }
          else
          {
            _heading = Compass.GetOpposite(_heading);
          }
        }
        else
        {
          _position = new Point(x, y);
        }
      }
    }

    #endregion Public Methods

    #region Internal Methods

    internal void UndoMove()
    {
      _position = _previousPositions.GetLast();
    }

    #endregion Internal Methods
  }
}