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
    public class DifferencingDiskBlockFactory : AbstractDiskBlockFactory
    {
        private BitMapFactory bitMapFactory;
        private SectorFactory sectorFactory;
        private IBlockFactory parentBlockFactory;
        private Block cachedBlock;

        public DifferencingDiskBlockFactory(VhdFile vhdFile) : base(vhdFile)
        {
            this.bitMapFactory = new BitMapFactory(vhdFile);
            this.sectorFactory = new SectorFactory(vhdFile, this);
            this.parentBlockFactory = vhdFile.Parent.DiskType != DiskType.Fixed ? vhdFile.Parent.GetBlockFactory() : new FixedDiskBlockFactory(vhdFile.Parent, this.GetBlockSize());
        }

        public override Block Create(uint block)
        {
            if (!vhdFile.BlockAllocationTable.HasData(block))
            {
                if (cachedBlock == null || cachedBlock.BlockIndex != block)
                {
                    cachedBlock = parentBlockFactory.Create(block);
                }
                return cachedBlock;
            }

            if (cachedBlock == null || cachedBlock.BlockIndex != block)
            {
                cachedBlock = new Block(this)
                {
                    BlockIndex = block,
                    VhdUniqueId = this.vhdFile.Footer.UniqueId,
                    LogicalRange = IndexRange.FromLength(block * GetBlockSize(), vhdFile.Header.BlockSize),
                    BitMap = bitMapFactory.Create(block),
                    Empty = false
                };
            }
            return cachedBlock;
        }

        public override Sector GetSector(Block block, uint sector)
        {
            if (block.Empty)
            {
                return this.sectorFactory.CreateEmptySector(block.BlockIndex, sector);
            }

            if (block.BitMap != null && block.BitMap.Data[(int)sector])
            {
                return this.sectorFactory.Create(block, sector);
            }

            var parentBlock = parentBlockFactory.Create(block.BlockIndex);
            return parentBlockFactory.GetSector(parentBlock, sector);
        }

        protected override byte[] DoReadBlockData(Block block)
        {
            var result = new byte[GetBlockSize()];
            int index = 0;
            for (int i = 0; i < block.SectorCount; i++)
            {
                var sector = block.GetSector((uint)i);
                Buffer.BlockCopy(sector.Data, 0, result, index, sector.Data.Length);
                index += sector.Data.Length;
            }
            return result;
        }
    }
}