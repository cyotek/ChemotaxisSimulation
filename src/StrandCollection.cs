using System.Collections.ObjectModel;

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
      set { _owner = value; }
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