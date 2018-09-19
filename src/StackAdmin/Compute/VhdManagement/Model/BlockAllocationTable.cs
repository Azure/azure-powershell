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

using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence;
using System;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class BlockAllocationTable
    {
        private readonly uint blockSize;

        public BlockAllocationTable(uint size, uint blockSize, uint[] bat)
        {
            this.blockSize = blockSize;
            this.Size = size;
            this.Data = bat;
        }

        public uint Size { get; internal set; }

        private uint[] Data { get; set; }

        public long GetBlockAddress(uint block)
        {
            return GetBitMapAddress(block) + GetSectorPaddedBitmapSizeInBytes();
        }

        public long GetBitMapAddress(uint block)
        {
            return ((long)this.Data[block]) * VhdConstants.VHD_SECTOR_LENGTH;
        }

        public int GetSectorPaddedBitmapSizeInBytes()
        {
            var sectorSpanOfBitMap = (double)GetBitmapSizeInBytes() / VhdConstants.VHD_SECTOR_LENGTH;
            return (int)(Math.Ceiling(sectorSpanOfBitMap) * VhdConstants.VHD_SECTOR_LENGTH);
        }

        public int GetBitmapSizeInBytes()
        {
            return (int)(blockSize / VhdConstants.VHD_SECTOR_LENGTH / 8);
        }

        public bool HasData(uint block)
        {
            return block != VhdConstants.VHD_NO_DATA_INT && Data[block] != VhdConstants.VHD_NO_DATA_INT;
        }
    }
}