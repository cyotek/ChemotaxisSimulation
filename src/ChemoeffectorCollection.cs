using System.Collections.ObjectModel;

namespace Cyotek.Demo.EColiSimulation
{
  internal class ChemoeffectorCollection : Collection<Chemoeffector>
  {
    #region Private Fields

    private readonly Environment _environment;

    #endregion Private Fields

    #region Public Constructors

    public ChemoeffectorCollection(Environment environment)
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