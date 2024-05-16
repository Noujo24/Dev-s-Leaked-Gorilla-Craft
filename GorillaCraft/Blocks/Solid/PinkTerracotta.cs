﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PinkTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("PinkTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PinkTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PinkTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PinkTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PinkTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PinkTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Pink Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
