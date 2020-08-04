using System.Collections.ObjectModel;

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal class ChemoeffectorCollection : Collection<Chemoeffector>
  {
    #region Private Fields

    private readonly Simulation _environment;

    #endregion Private Fields

    #region Public Constructors

    public ChemoeffectorCollection(Simulation environment)
    {
      _environment = environment;
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void InsertItem(int index, Chemoeffector item)
    {
      item.Environment = _environment;

      base.InsertItem(index, item);
    }

    #endregion Protected Methods
  }
}