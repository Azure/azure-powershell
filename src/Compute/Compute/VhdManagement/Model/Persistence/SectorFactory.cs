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
    public class SectorFactory
    {
        private readonly VhdFile vhdFile;
        private readonly IBlockFactory blockFactory;

        public SectorFactory(VhdFile vhdFile, IBlockFactory blockFactory)
        {
            this.vhdFile = vhdFile;
            this.blockFactory = blockFactory;
        }

        public Sector Create(Block blockArg, uint sector)
        {
            uint block = blockArg.BlockIndex;
            long totalSectors = blockArg.SectorCount;
            if (sector > totalSectors)
            {
                string message = String.Format("TotalSectors: {0}, Requested Sector:{1}", totalSectors, sector);
                throw new ArgumentOutOfRangeException("sector", message);
            }
            if (!blockFactory.HasData(block))
            {
                return CreateEmptySector(block, sector);
            }

            long currentAddress = blockFactory.GetBlockAddress(block);
            vhdFile.DataReader.SetPosition(currentAddress + (int)VhdConstants.VHD_SECTOR_LENGTH * sector);

            var result = new Sector
            {
                BlockIndex = block,
                SectorIndex = sector,
                GlobalSectorIndex = this.blockFactory.GetBlockSize() * block + sector,
                Data = vhdFile.DataReader.ReadBytes((int)VhdConstants.VHD_SECTOR_LENGTH)
            };
            return result;
        }

        public Sector CreateEmptySector(uint block, uint sector)
        {
            var buffer = new byte[((int)VhdConstants.VHD_SECTOR_LENGTH)];
            Array.Clear(buffer, 0, buffer.Length);
            var emptySector = new Sector
            {
                BlockIndex = block,
                SectorIndex = sector,
                GlobalSectorIndex = this.blockFactory.GetBlockSize() * block + sector,
                Data = buffer
            };
            return emptySector;
        }
    }
}