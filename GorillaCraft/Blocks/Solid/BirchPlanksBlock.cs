﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BirchPlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("BirchPlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Birch Planks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
