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
    public interface IBlockFactory
    {
        long BlockCount { get; }

        long GetBlockSize();
        long GetBlockAddress(uint blockIndex);
        bool HasData(uint blockIndex);

        Block Create(uint block);
        byte[] ReadBlockData(Block block);

        Sector GetSector(Block block, uint sector);

        IndexRange GetFooterRange();
    }
}