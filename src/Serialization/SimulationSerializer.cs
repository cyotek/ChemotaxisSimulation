using System.IO;
using YamlDotNet.Serialization;

namespace Cyotek.ChemotaxisSimulation.Serialization
{
  internal class SimulationSerializer
  {
    #region Public Methods

    public Simulation Load(string fileName)
    {
      using (Stream stream = File.OpenRead(fileName))
      {
        return this.Load(stream);
      }
    }

    public Simulation Load(Stream stream)
    {
      using (TextReader reader = new StreamReader(stream, Encoding.UTF8NoIdentifier))
      {
        return this.Load(reader);
      }
    }

    public Simulation Load(TextReader reader)
    {
      return new DeserializerBuilder()
        .Build()
        .Deserialize<Simulation>(reader);
    }

    public void Save(Stream stream, Simulation simulation)
    {
      using (TextWriter writer = new StreamWriter(stream, Encoding.UTF8NoIdentifier))
      {
        this.Save(writer, simulation);
      }
    }

    public void Save(TextWriter writer, Simulation simulation)
    {
      new SerializerBuilder()
        .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
        .DisableAliases()
        .IgnoreFields()
        .WithTypeConverter(new PointYamlTypeConverter())
        .WithTypeConverter(new SizeYamlTypeConverter())
        .Build()
        .Serialize(writer, simulation);
    }

    #endregion Public Methods
  }
}