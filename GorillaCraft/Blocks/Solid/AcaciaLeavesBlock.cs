﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class AcaciaLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Up => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("AcaciaLeaves", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Acacia Leaves";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
