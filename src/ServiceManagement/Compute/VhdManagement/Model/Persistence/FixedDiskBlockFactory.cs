// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class FixedDiskBlockFactory : IBlockFactory
    {
        private readonly VhdFile vhdFile;
        private SectorFactory sectorFactory;
        private Block cachedBlock;
        private long blockSize;
        private long? extraBlockIndex;

        public FixedDiskBlockFactory(VhdFile vhdFile) : this(vhdFile, VhdConstants.VHD_DEFAULT_BLOCK_SIZE)
        {
        }

        public FixedDiskBlockFactory(VhdFile vhdFile, long blockSize)
        {
            this.vhdFile = vhdFile;
            this.blockSize = blockSize;
            this.BlockCount = CalculateBlockCount();
            this.sectorFactory = new SectorFactory(vhdFile, this);
        }

        private int CalculateBlockCount()
        {
            var count = this.vhdFile.Footer.VirtualSize * 1.0m / this.GetBlockSize();
            if (Math.Floor(count) < Math.Ceiling(count))
            {
                extraBlockIndex = (long)Math.Floor(count);
            }
            return (int)Math.Ceiling(count);
        }

        public long BlockCount { get; private set; }

        public Block Create(uint block)
        {
            if (!this.HasData(block))
            {
                if (cachedBlock == null || cachedBlock.BlockIndex != block)
                {
                    IndexRange logicalRange = IndexRange.FromLength(block * GetBlockSize(), this.GetBlockSize());
                    if (extraBlockIndex.HasValue && block == extraBlockIndex)
                    {
                        long startIndex = block * GetBlockSize();
                        long size = this.vhdFile.DataReader.Size - startIndex - VhdConstants.VHD_FOOTER_SIZE;
                        logicalRange = IndexRange.FromLength(startIndex, size);
                    }
                    cachedBlock = new Block(this)
                    {
                        BlockIndex = block,
                        VhdUniqueId = this.vhdFile.Footer.UniqueId,
                        LogicalRange = logicalRange,
                        BitMap = null,
                        Empty = true
                    };
                }
                return cachedBlock;
            }
            if (cachedBlock == null || cachedBlock.BlockIndex != block)
            {
                IndexRange logicalRange = IndexRange.FromLength(block * GetBlockSize(), this.GetBlockSize());
                if (extraBlockIndex.HasValue && block == extraBlockIndex)
                {
                    long startIndex = block * GetBlockSize();
                    long size = this.vhdFile.DataReader.Size - startIndex - VhdConstants.VHD_FOOTER_SIZE;
                    logicalRange = IndexRange.FromLength(startIndex, size);
                }
                cachedBlock = new Block(this)
                {
                    BlockIndex = block,
                    VhdUniqueId = this.vhdFile.Footer.UniqueId,
                    LogicalRange = logicalRange,
                    Empty = false
                };
            }
            return cachedBlock;
        }

        public byte[] ReadBlockData(Block block)
        {
            long blockAddress = GetBlockAddress(block.BlockIndex);
            return vhdFile.DataReader.ReadBytes(blockAddress, (int)block.LogicalRange.Length);
        }

        public Sector GetSector(Block block, uint sector)
        {
            if (block.Empty)
            {
                return this.sectorFactory.CreateEmptySector(block.BlockIndex, sector);
            }
            return this.sectorFactory.Create(block, sector);
        }

        public IndexRange GetFooterRange()
        {
            long startIndex = this.vhdFile.DataReader.Size - VhdConstants.VHD_FOOTER_SIZE;
            var logicalRange = IndexRange.FromLength(startIndex, VhdConstants.VHD_FOOTER_SIZE);
            return logicalRange;
        }

        public bool HasData(uint blockIndex)
        {
            return blockIndex != VhdConstants.VHD_NO_DATA_INT;
        }

        public long GetBlockAddress(uint blockIndex)
        {
            return blockIndex * this.blockSize;
        }

        public long GetBlockSize()
        {
            return this.blockSize;
        }
    }
}