﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class GravelBlock : IBlock
    {
        public BlockFaceInfo Front => new("Gravel", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("Gravel", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("Gravel", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("Gravel", typeof(Surface_Gravel));
        public BlockFaceInfo Up => new("Gravel", typeof(Surface_Gravel));
        public BlockFaceInfo Down => new("Gravel", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Gravel);
        public Type DestroySoundType => typeof(Interaction_Gravel);

        public string BlockDefinition => "Gravel";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
