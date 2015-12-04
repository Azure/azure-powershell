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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo
{
    public class SetAzureDataDiskConfig
    {
        public readonly HostCaching hostCaching;

        public readonly int lun;

        public SetAzureDataDiskConfig(HostCaching hostCaching, int lun)
        {
            this.hostCaching = hostCaching;
            this.lun = lun;
        }

        public PersistentVM Vm { get; set; }
    }

    public class SetAzureDataDiskResizeConfig
    {
        public string DiskName;

        public int ResizedSizeInGB;
        public PersistentVM Vm { get; set; }

        public SetAzureDataDiskResizeConfig(string diskName, int resize, PersistentVM vm)
        {
            this.DiskName = diskName;
            this.ResizedSizeInGB = resize;
            this.Vm = vm;
        }

    }
}
