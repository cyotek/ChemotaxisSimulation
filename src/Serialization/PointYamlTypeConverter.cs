using System;
using System.Drawing;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

// Using custom type converters with C# and YamlDotNet, part 1
// https://www.cyotek.com/blog/using-custom-type-converters-with-csharp-and-yamldotnet-part-1

// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.ChemotaxisSimulation.Serialization
{
  internal sealed class PointYamlTypeConverter : IYamlTypeConverter
  {
    #region Public Methods

    public bool Accepts(Type type)
    {
      return type == typeof(Point);
    }

    public object ReadYaml(IParser parser, Type type)
    {
      throw new NotImplementedException();
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
      Point point;

      point = (Point)value;

      emitter.Emit(new MappingStart(null, null, false, MappingStyle.Block));

      emitter.Emit(new Scalar(null, "X"));
      emitter.Emit(new Scalar(null, point.X.ToString()));
      emitter.Emit(new Scalar(null, "Y"));
      emitter.Emit(new Scalar(null, point.Y.ToString()));

      emitter.Emit(new MappingEnd());
    }

    #endregion Public Methods
  }
}