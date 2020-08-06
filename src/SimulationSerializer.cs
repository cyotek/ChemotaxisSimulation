using Cyotek.Collections.Generic;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal class SimulationSerializer
  {
    #region Public Methods

    public void Save(Stream stream, Simulation simulation)
    {
      using (TextWriter writer = new StreamWriter(stream, Encoding.UTF8NoIdentifier))
      {
        this.Save(writer, simulation);
      }
    }

    public void Save(TextWriter writer, Simulation simulation)
    {
      int indent;

      indent = 0;

      this.WriteProperties(writer, ref indent, simulation);
    }

    #endregion Public Methods

    #region Private Methods

    private void WriteIndent(TextWriter writer, int indent)
    {
      for (int i = 0; i < indent; i++)
      {
        writer.Write(' ');
      }
    }

    private void WriteProperties(TextWriter writer, ref int indent, object value)
    {
      Type type;
      PropertyInfo[] properties;

      type = value.GetType();
      properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

      for (int i = 0; i < properties.Length; i++)
      {
        PropertyInfo property;

        property = properties[i];

        if (property.CanRead)
        {
          this.WriteProperty(writer, ref indent, property.Name, property.GetValue(value));
        }
      }
    }

    private void WriteProperty(TextWriter writer, ref int indent, string name, object value)
    {
      if (!(value is null))
      {
        switch (Type.GetTypeCode(value.GetType()))
        {
          case TypeCode.Boolean:
            this.WritePropertyValue(writer, indent, name, (bool)value ? "yes" : "no");
            break;

          case TypeCode.Int16:
            this.WritePropertyValue(writer, indent, name, (short)value);
            break;

          case TypeCode.Int32:
            this.WritePropertyValue(writer, indent, name, (int)value);
            break;

          case TypeCode.Int64:
            this.WritePropertyValue(writer, indent, name, (long)value);
            break;

          case TypeCode.UInt16:
            this.WritePropertyValue(writer, indent, name, (ushort)value);
            break;

          case TypeCode.UInt32:
            this.WritePropertyValue(writer, indent, name, (uint)value);
            break;

          case TypeCode.UInt64:
            this.WritePropertyValue(writer, indent, name, (ulong)value);
            break;

          case TypeCode.Single:
            this.WritePropertyValue(writer, indent, name, (float)value);
            break;

          case TypeCode.Double:
            this.WritePropertyValue(writer, indent, name, (double)value);
            break;

          case TypeCode.Decimal:
            this.WritePropertyValue(writer, indent, name, (decimal)value);
            break;

          case TypeCode.Object:
            if (value is IList collection)
            {
              this.WriteProperty(writer, ref indent, name, collection);
            }
            else if (value is Size size)
            {
              this.WritePropertyValue(writer, indent, name, string.Format("{0}, {1}", size.Width, size.Height));
            }
            else if (value is Point point)
            {
              this.WritePropertyValue(writer, indent, name, string.Format("{0}, {1}", point.X, point.Y));
            }
            else if (value is CircularBuffer<Point> pointBuffer)
            {
              this.WriteProperty(writer, ref indent, name, pointBuffer);
            }
            else
            {
              throw new NotSupportedException(string.Format("No support for property of type '{0}'.", value.GetType().Name));
            }
            break;

          default:
            throw new NotSupportedException(string.Format("No support for property of type '{0}'.", value.GetType().Name));
        }
      }
    }

    private void WriteProperty(TextWriter writer, ref int indent, string name, IList value)
    {
      if (value.Count > 0)
      {
        this.WritePropertyHeader(writer, indent, name);
        writer.WriteLine();

        indent += 2;

        for (int i = 0; i < value.Count; i++)
        {
          this.WriteIndent(writer, indent);
          writer.WriteLine(i);

          indent += 2;

          this.WriteProperties(writer, ref indent, value[i]);

          indent -= 2;
        }

        indent -= 2;
      }
    }

    private void WriteProperty<T>(TextWriter writer, ref int indent, string name, CircularBuffer<T> value)
    {
      if (value.Size > 0)
      {
        this.WritePropertyHeader(writer, indent, name);
        writer.WriteLine();

        indent += 2;

        for (int i = 0; i < value.Size; i++)
        {
          this.WriteProperty(writer, ref indent, i.ToString(), value.PeekAt(i));
        }

        indent -= 2;
      }
    }

    private void WritePropertyHeader(TextWriter writer, int indent, string name)
    {
      this.WriteIndent(writer, indent);
      writer.Write(name.ToLowerInvariant());
      writer.Write(' ');
      writer.Write('=');
      writer.Write(' ');
    }

    private void WritePropertyValue(TextWriter writer, int indent, string name, object value)
    {
      this.WritePropertyHeader(writer, indent, name);
      writer.WriteLine(value);
    }

    #endregion Private Methods
  }
}