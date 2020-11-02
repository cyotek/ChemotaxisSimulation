using Cyotek.Collections.Generic;
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