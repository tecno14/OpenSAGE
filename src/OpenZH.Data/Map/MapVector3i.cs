﻿using System.IO;

namespace OpenZH.Data.Map
{
    public struct MapVector3i
    {
        public int X;
        public int Y;
        public int Z;

        public static MapVector3i Parse(BinaryReader reader)
        {
            return new MapVector3i
            {
                X = reader.ReadInt32(),
                Y = reader.ReadInt32(),
                Z = reader.ReadInt32()
            };
        }

        public void WriteTo(BinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
            writer.Write(Z);
        }
    }
}
