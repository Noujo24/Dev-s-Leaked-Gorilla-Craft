﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class PlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("OakPlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Planks";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
