﻿using System;
using System.Drawing;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

// Using custom type converters with C# and YamlDotNet, part 1
// https://www.cyotek.com/blog/using-custom-type-converters-with-csharp-and-yamldotnet-part-1

namespace Cyotek.Demo.ChemotaxisSimulation
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