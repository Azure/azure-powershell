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

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{


    public class DynamicDiskBlockFactory : AbstractDiskBlockFactory
    {
        private BitMapFactory bitMapFactory;
        private SectorFactory sectorFactory;
        private Block cachedBlock;

        public DynamicDiskBlockFactory(VhdFile vhdFile) : base(vhdFile)
        {
            this.bitMapFactory = new BitMapFactory(vhdFile);
            this.sectorFactory = new SectorFactory(vhdFile, this);
        }

        public override Block Create(uint block)
        {
            if (!vhdFile.BlockAllocationTable.HasData(block))
            {
                if (cachedBlock == null || cachedBlock.BlockIndex != block)
                {
                    cachedBlock = new Block(this)
                    {
                        BlockIndex = block,
                        VhdUniqueId = this.vhdFile.Footer.UniqueId,
                        LogicalRange = IndexRange.FromLength(block * GetBlockSize(), vhdFile.Header.BlockSize),
                        BitMap = null,
                        Empty = true
                    };
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
            return this.sectorFactory.Create(block, sector);
        }

        protected override byte[] DoReadBlockData(Block block)
        {
            return vhdFile.DataReader.ReadBytes(GetBlockAddress(block.BlockIndex), (int)GetBlockSize());
        }
    }
}