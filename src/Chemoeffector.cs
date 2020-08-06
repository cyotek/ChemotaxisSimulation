using System.Drawing;

namespace Cyotek.ChemotaxisSimulation
{
  public class Chemoeffector
  {
    #region Private Fields

    private Point _heading;

    private Simulation _owner;

    private Point _position;

    private int _strength;

    #endregion Private Fields

    #region Public Properties

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

    public void Move()
    {
      if (!_heading.IsEmpty)
      {
        int x;
        int y;

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
  }
}