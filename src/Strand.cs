using System.Drawing;

// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.ChemotaxisSimulation
{
  public class Strand
  {
    #region Private Fields

    private int _generation;

    private Point _heading;

    private Simulation _owner;

    private Point _position;

    private PointBuffer _previousPositions;

    private double _previousSensor;

    private int _strength;

    #endregion Private Fields

    #region Public Constructors

    public Strand()
    {
      _previousPositions = new PointBuffer();
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

    public PointBuffer PreviousPositions
    {
      get { return _previousPositions; }
      set { _previousPositions = value; }
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

    internal Simulation Owner
    {
      get { return _owner; }
      set { _owner = value; }
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

        if (x < 0 || y < 0 || x > _owner.Size.Width - 1 || y > _owner.Size.Height)
        {
          if (_owner.Wrap)
          {
            if (x < 0)
            {
              x = _owner.Size.Width - 1;
            }
            else if (x > _owner.Size.Width - 1)
            {
              x = 1;
            }

            if (y < 0)
            {
              y = _owner.Size.Height - 1;
            }
            else if (y > _owner.Size.Height - 1)
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