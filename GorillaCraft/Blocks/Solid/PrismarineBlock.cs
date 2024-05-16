﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PrismarineBlock : IBlock
    {
        public BlockFaceInfo Front => new("Prismarine", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Prismarine", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Prismarine", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Prismarine", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Prismarine", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Prismarine", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Prismarine";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
