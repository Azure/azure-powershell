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

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class VhdHeaderVersion
    {
        private const uint VHD_HEADER_SUPPORTED_VERSION = 0x00010000;

        public VhdHeaderVersion(uint data)
        {
            this.Data = data;
        }

        public uint Data { get; private set; }

        public bool IsSupported()
        {
            return Data == VHD_HEADER_SUPPORTED_VERSION;
        }

        public override string ToString()
        {
            return this.Data.ToString();
        }
    }
}