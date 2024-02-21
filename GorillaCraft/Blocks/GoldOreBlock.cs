﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class GoldOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Up => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Down => new("GoldOre", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Gold Ore";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
