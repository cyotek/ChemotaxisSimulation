using System.Drawing;

namespace Cyotek.Demo.EColiSimulation
{
  internal class Chemoeffector
  {
    #region Private Fields

    private Environment _environment;

    private Point _heading;

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

    internal Environment Environment
    {
      get { return _environment; }
      set { _environment = value; }
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
  }
}