﻿using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Surface_Sand : IDataType
    {
        public string Name => "Sand";
        public float Volume => 0.15f;
        public float Pitch => 1f;
        public int MaxRange => 5;
    }
}
