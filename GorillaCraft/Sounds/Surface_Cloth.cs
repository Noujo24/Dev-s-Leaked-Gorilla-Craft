﻿using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Surface_Cloth : IDataType
    {
        public string Name => "Cloth";
        public float Volume => 0.15f;
        public float Pitch => 1f;
        public int MaxRange => 4;
    }
}
