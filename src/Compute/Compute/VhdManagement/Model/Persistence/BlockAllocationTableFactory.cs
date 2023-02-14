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

using Microsoft.WindowsAzure.Commands.Tools.Common.General;
using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class BlockAllocationTableFactory
    {
        private readonly VhdDataReader dataReader;
        private readonly VhdHeader header;

        public BlockAllocationTableFactory(VhdDataReader dataReader, VhdHeader header)
        {
            this.dataReader = dataReader;
            this.header = header;
        }

        public BlockAllocationTable Create()
        {
            dataReader.SetPosition(header.TableOffset);

            var bat = new uint[header.MaxTableEntries];
            for (int block = 0; block < header.MaxTableEntries; block++)
            {
                bat[block] = dataReader.ReadUInt32();
            }
            return new BlockAllocationTable(header.MaxTableEntries, header.BlockSize, bat);
        }

        public IAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return AsyncMachine<BlockAllocationTable>.BeginAsyncMachine(CreateAsync, callback, state);
        }

        public BlockAllocationTable EndCreate(IAsyncResult result)
        {
            return AsyncMachine<BlockAllocationTable>.EndAsyncMachine(result);
        }

        private IEnumerable<CompletionPort> CreateAsync(AsyncMachine<BlockAllocationTable> machine)
        {
            dataReader.SetPosition(header.TableOffset);

            var bat = new uint[header.MaxTableEntries];
            for (int block = 0; block < header.MaxTableEntries; block++)
            {
                dataReader.BeginReadUInt32(machine.CompletionCallback, null);
                yield return CompletionPort.SingleOperation;
                bat[block] = dataReader.EndReadUInt32(machine.CompletionResult);
            }
            machine.ParameterValue = new BlockAllocationTable(header.MaxTableEntries, header.BlockSize, bat);
        }
    }
}