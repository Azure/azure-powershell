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


    [VhdEntity(Size = 24)]
    public class ParentLocator
    {
        [VhdProperty(Offset = 0, Size = 4)]
        public PlatformCode PlatformCode { get; set; }

        [VhdProperty(Offset = 4, Size = 4)]
        public int PlatformDataSpace { get; set; }

        [VhdProperty(Offset = 8, Size = 4)]
        public int PlatformDataLength { get; set; }

        [VhdProperty(Offset = 12, Size = 4)]
        public int Reserved { get; set; }

        [VhdProperty(Offset = 16, Size = 8)]
        public long PlatformDataOffset { get; set; }

        public string PlatformSpecificFileLocator { get; set; }
    }
}