﻿using System.Collections.Generic;
using Blockcore.Consensus.Chain;

namespace Blockcore.BlockPulling
{
    /// <summary>Represents consecutive collection of headers that are to be downloaded.</summary>
    public struct DownloadJob
    {
        /// <summary>Unique identifier of this job.</summary>
        public int Id;

        /// <summary>Headers of blocks that are to be downloaded.</summary>
        public List<ChainedHeader> Headers;
    }
}
