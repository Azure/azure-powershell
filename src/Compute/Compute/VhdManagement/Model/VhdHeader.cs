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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    [VhdEntity(Size = 1024)]
    public class VhdHeader
    {
        [VhdProperty(Offset = 0, Size = 8)]
        public VhdCookie Cookie { get; set; }

        [VhdProperty(Offset = 8, Size = 8)]
        public long DataOffset { get; set; }

        [VhdProperty(Offset = 16, Size = 8)]
        public long TableOffset { get; set; }

        [VhdProperty(Offset = 24, Size = 4)]
        public VhdHeaderVersion HeaderVersion { get; set; }

        [VhdProperty(Offset = 28, Size = 4)]
        public uint MaxTableEntries { get; set; }

        [VhdProperty(Offset = 32, Size = 4)]
        public uint BlockSize { get; set; }

        [VhdProperty(Offset = 36, Size = 4)]
        public uint CheckSum { get; set; }

        [VhdProperty(Offset = 40, Size = 16)]
        public Guid ParentUniqueId { get; set; }

        [VhdProperty(Offset = 56, Size = 4)]
        public DateTime ParentTimeStamp { get; set; }

        [VhdProperty(Offset = 60, Size = 4)]
        public uint Reserverd1 { get; set; }

        [VhdProperty(Offset = 64, Size = 512)]
        public string ParentPath { get; set; }

        [VhdProperty(Offset = 576, Count = 8)]
        public IList<ParentLocator> ParentLocators { get; set; }

        [VhdProperty(Offset = 0, Size = 1024)]
        public byte[] RawData { get; set; }

        public string GetAbsoluteParentPath()
        {
            return (from p in ParentLocators
                    where p.PlatformCode == PlatformCode.W2Ku
                    select p.PlatformSpecificFileLocator).FirstOrDefault();
        }

        public string GetRelativeParentPath()
        {
            return (from p in ParentLocators
                    where p.PlatformCode == PlatformCode.W2Ru
                    select p.PlatformSpecificFileLocator).FirstOrDefault();
        }
    }
}