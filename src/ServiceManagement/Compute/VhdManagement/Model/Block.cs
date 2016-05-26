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
    public class Block
    {
        private readonly IBlockFactory blockFactory;
        private byte[] data;

        public Block(IBlockFactory blockFactory)
        {
            this.blockFactory = blockFactory;
        }

        public Guid VhdUniqueId { get; set; }
        public uint BlockIndex { get; set; }
        public BitMap BitMap { get; set; }

        public byte[] Data
        {
            get
            {
                if (data == null)
                {
                    data = this.blockFactory.ReadBlockData(this);
                }
                return data;
            }
        }

        public long SectorCount
        {
            get { return this.LogicalRange.Length / VhdConstants.VHD_SECTOR_LENGTH; }
        }

        public Sector GetSector(uint sector)
        {
            return this.blockFactory.GetSector(this, sector);
        }

        public bool Empty { get; set; }

        public IndexRange LogicalRange { get; set; }

        public override string ToString()
        {
            return BlockIndex.ToString();
        }
    }
}