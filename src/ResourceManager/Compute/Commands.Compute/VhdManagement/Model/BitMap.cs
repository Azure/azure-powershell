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

using System.Collections;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class BitMap
    {
        public BitMap(BitArray data)
        {
            this.Data = data;
            Covered = CheckIfCovered();
        }

        public BitArray Data { get; private set; }

        public bool Covered { get; private set; }

        bool CheckIfCovered()
        {
            for (int i = 0; i < Data.Length; i++)
                if (!Data[i]) return false;
            return true;
        }
    }
}