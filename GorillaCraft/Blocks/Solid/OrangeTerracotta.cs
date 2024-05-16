﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class OrangeTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("OrangeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("OrangeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("OrangeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("OrangeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("OrangeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("OrangeTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Orange Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
