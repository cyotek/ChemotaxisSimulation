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
    private double _strength;

    public double Strength
    {
      get { return _strength; }
      set { _strength = value; }
    }
    private int _size;

    public int Size
    {
      get { return _size; }
      set { _size = value; }
    }

    private Point _position;

    public Point Position
    {
      get { return _position; }
      set { _position = value; }
    }

  }
}
