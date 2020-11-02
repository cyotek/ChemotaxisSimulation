using System.Text;
using Enc = System.Text.Encoding;

// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.ChemotaxisSimulation
{
  internal static class Encoding
  {
    #region Private Fields

    private static readonly Enc _utf8bomless = new UTF8Encoding(false);

    #endregion Private Fields

    #region Public Properties

    public static Enc UTF8NoIdentifier
    {
      get { return _utf8bomless; }
    }

    #endregion Public Properties
  }
}