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
    public abstract class AbstractDiskBlockFactory : IBlockFactory
    {
        protected readonly VhdFile vhdFile;
        private byte[] emptyBlockData;

        protected AbstractDiskBlockFactory(VhdFile vhdFile)
        {
            this.vhdFile = vhdFile;
        }

        public abstract Block Create(uint block);
        public abstract Sector GetSector(Block block, uint sector);

        public IndexRange GetFooterRange()
        {
            return IndexRange.FromLength(this.GetBlockSize() * this.BlockCount, VhdConstants.VHD_FOOTER_SIZE);
        }

        public byte[] ReadBlockData(Block block)
        {
            if (!this.HasData(block.BlockIndex))
            {
                if (emptyBlockData == null)
                {
                    emptyBlockData = new byte[(int)GetBlockSize()];
                    Array.Clear(emptyBlockData, 0, emptyBlockData.Length);
                }
                return emptyBlockData;
            }
            return DoReadBlockData(block);
        }

        protected abstract byte[] DoReadBlockData(Block block);

        public long BlockCount
        {
            get { return vhdFile.BlockAllocationTable.Size; }
        }

        public bool HasData(uint blockIndex)
        {
            return vhdFile.BlockAllocationTable.HasData(blockIndex);
        }

        public long GetBlockAddress(uint blockIndex)
        {
            return vhdFile.BlockAllocationTable.GetBlockAddress(blockIndex);
        }

        public long GetBlockSize()
        {
            return vhdFile.Header.BlockSize;
        }
    }
}