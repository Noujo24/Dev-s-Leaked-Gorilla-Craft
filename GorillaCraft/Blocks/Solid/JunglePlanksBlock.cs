﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class JunglePlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("JunglePlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Jungle Planks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
