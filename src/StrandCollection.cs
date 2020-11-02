using System.Collections.ObjectModel;

// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.ChemotaxisSimulation
{
  public class StrandCollection : Collection<Strand>
  {
    #region Private Fields

    private Simulation _owner;

    #endregion Private Fields

    #region Internal Properties

    internal Simulation Owner
    {
      get { return _owner; }
      set
      {
        _owner = value;

        if (value != null)
        {
          for (int i = 0; i < this.Count; i++)
          {
            this[i].Owner = value;
          }
        }
      }
    }

    #endregion Internal Properties

    #region Protected Methods

    protected override void InsertItem(int index, Strand item)
    {
      item.Owner = _owner;

      base.InsertItem(index, item);
    }

    #endregion Protected Methods
  }
}