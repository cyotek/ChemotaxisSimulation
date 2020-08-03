using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.Demo.EColiSimulation
{
  internal class Chemoeffector
  {


    private Environment _environment;

    internal Environment Environment
    {
      get { return _environment; }
      set { _environment = value; }
    }
    private int _strength;

    public int Strength
    {
      get { return _strength; }
      set { _strength = value; }
    }

    private Point _position;

    public Point Position
    {
      get { return _position; }
      set { _position = value; }
    }

  }
}
