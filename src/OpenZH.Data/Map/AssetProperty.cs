﻿using System.IO;
using OpenZH.Data.Utilities.Extensions;

namespace OpenZH.Data.Map
{
    public sealed class AssetProperty
    {
        public AssetPropertyType PropertyType { get; private set; }
        public string Name { get; private set; }
        public object Value { get; private set; }

        public static AssetProperty Parse(BinaryReader reader, MapParseContext context)
        {
            var propertyType = reader.ReadByteAsEnum<AssetPropertyType>();

            var propertyNameIndex = reader.ReadUInt24();
            var propertyName = context.GetAssetName(propertyNameIndex);

            object value = null;
            switch (propertyType)
            {
                case AssetPropertyType.Boolean:
                    value = reader.ReadBoolean();
                    break;

                case AssetPropertyType.Integer:
                    value = reader.ReadUInt32();
                    break;

                case AssetPropertyType.RealNumber:
                    value = reader.ReadSingle();
                    break;

                case AssetPropertyType.AsciiString:
                    value = reader.ReadUInt16PrefixedAsciiString();
                    break;

                case AssetPropertyType.UnicodeString:
                    value = reader.ReadUInt16PrefixedUnicodeString();
                    break;

                default:
                    throw new InvalidDataException($"Unexpected property type: {propertyType}.");
            }

            return new AssetProperty
            {
                PropertyType = propertyType,
                Name = propertyName,
                Value = value
            };
        }

        public void WriteTo(BinaryWriter writer, AssetNameCollection assetNames)
        {
            writer.Write((byte) PropertyType);

            writer.WriteUInt24(assetNames.GetOrCreateAssetIndex(Name));

            switch (PropertyType)
            {
                case AssetPropertyType.Boolean:
                    writer.Write((bool) Value);
                    break;

                case AssetPropertyType.Integer:
                    writer.Write((uint) Value);
                    break;

                case AssetPropertyType.RealNumber:
                    writer.Write((float) Value);
                    break;

                case AssetPropertyType.AsciiString:
                    writer.WriteUInt16PrefixedAsciiString((string) Value);
                    break;

                case AssetPropertyType.UnicodeString:
                    writer.WriteUInt16PrefixedUnicodeString((string) Value);
                    break;

                default:
                    throw new InvalidDataException($"Unexpected property type: {PropertyType}.");
            }
        }
    }

    public enum AssetPropertyType : byte
    {
        Boolean = 0,
        Integer = 1,
        RealNumber = 2,
        AsciiString = 3,
        UnicodeString = 4
    }
}
