using System.IO;
using YamlDotNet.Serialization;

// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.ChemotaxisSimulation.Serialization
{
  public static class SimulationSerializer
  {
    #region Public Methods

    public static Simulation LoadFrom(string fileName)
    {
      using (Stream stream = File.OpenRead(fileName))
      {
        return SimulationSerializer.LoadFrom(stream);
      }
    }

    public static Simulation LoadFrom(Stream stream)
    {
      using (TextReader reader = new StreamReader(stream, Encoding.UTF8NoIdentifier))
      {
        return SimulationSerializer.LoadFrom(reader);
      }
    }

    public static Simulation LoadFrom(TextReader reader)
    {
      return new DeserializerBuilder()
        .Build()
        .Deserialize<Simulation>(reader);
    }

    public static void Save(Stream stream, Simulation simulation)
    {
      using (TextWriter writer = new StreamWriter(stream, Encoding.UTF8NoIdentifier))
      {
        SimulationSerializer.Save(writer, simulation);
      }
    }

    public static void Save(TextWriter writer, Simulation simulation)
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