// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal class AutoSaveOptions
  {
    #region Private Fields

    private bool _enabled;

    private string _saveFolder;

    #endregion Private Fields

    #region Public Properties

    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    public string SaveFolder
    {
      get { return _saveFolder; }
      set { _saveFolder = value; }
    }

    #endregion Public Properties
  }
}