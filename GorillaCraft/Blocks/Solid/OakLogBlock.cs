﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class OakLogBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("OakLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("OakLogTop", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Oak Log";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.FullRotation;
    }
}
