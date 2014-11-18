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
using System.Collections;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class BitMapFactory
    {
        private readonly VhdFile vhdFile;

        public BitMapFactory(VhdFile vhdFile)
        {
            this.vhdFile = vhdFile;
        }

        public BitMap Create(uint block)
        {
            var bitMapAddress = vhdFile.BlockAllocationTable.GetBitMapAddress(block);
            var bitmapSizeInBytes = vhdFile.BlockAllocationTable.GetBitmapSizeInBytes();
            var bytes = vhdFile.DataReader.ReadBytes(bitMapAddress, bitmapSizeInBytes);
            ReverseBitsIfLittleEndian(bytes);
            return new BitMap(new BitArray(bytes));
        }

        private static void ReverseBitsIfLittleEndian(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                for (int bit = 0; bit < bytes.Length; bit++)
                {
                    // reverse the bits due to quirky BitArray
                    bytes[bit] = (byte)(((bytes[bit] * 0x80200802UL) & 0x0884422110UL) * 0x0101010101UL >> 32);
                }
            }
        }
    }
}