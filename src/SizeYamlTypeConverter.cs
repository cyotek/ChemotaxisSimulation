using System;
using System.Drawing;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

// Using custom type converters with C# and YamlDotNet, part 1
// https://www.cyotek.com/blog/using-custom-type-converters-with-csharp-and-yamldotnet-part-1

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal sealed class SizeYamlTypeConverter : IYamlTypeConverter
  {
    #region Public Methods

    public bool Accepts(Type type)
    {
      return type == typeof(Size);
    }

    public object ReadYaml(IParser parser, Type type)
    {
      throw new NotImplementedException();
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
      Size size;

      size = (Size)value;

      emitter.Emit(new MappingStart(null, null, false, MappingStyle.Block));

      emitter.Emit(new Scalar(null, "Width"));
      emitter.Emit(new Scalar(null, size.Width.ToString()));
      emitter.Emit(new Scalar(null, "Height"));
      emitter.Emit(new Scalar(null, size.Height.ToString()));

      emitter.Emit(new MappingEnd());
    }

    #endregion Public Methods
  }
}