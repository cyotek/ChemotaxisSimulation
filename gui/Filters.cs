// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal static class Filters
  {
    #region Public Fields

    public const string AllFiles = "All Files (*.*)|*.*";

    public const string General = Filters.Simulation + "|" + Filters.ScriptFiles + "|" + Filters.AllFiles;

    public const string ScriptFiles = "Script Files (*.js)|*.js";

    public const string Simulation = "Simulation Files (*.sim)|*.sim";

    #endregion Public Fields
  }
}