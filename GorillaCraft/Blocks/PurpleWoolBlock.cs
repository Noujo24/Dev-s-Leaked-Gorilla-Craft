﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class PurpleWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("PurpleWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Purple Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
