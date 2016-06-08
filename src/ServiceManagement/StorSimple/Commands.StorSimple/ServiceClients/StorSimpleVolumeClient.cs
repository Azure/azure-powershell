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

using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public VirtualDiskListResponse GetAllVolumesFordataContainer(string deviceid,string datacontainerid)
        {
            return GetStorSimpleClient().VirtualDisk.List(deviceid, datacontainerid, GetCustomRequestHeaders());
        }

        public VirtualDiskGetResponse GetVolumeByName(string deviceid, string diskName)
        {
            return GetStorSimpleClient().VirtualDisk.GetByName(deviceid, diskName, GetCustomRequestHeaders());
        }

        public TaskStatusInfo CreateVolume(string deviceid, VirtualDiskRequest diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.Create(deviceid, diskDetails, GetCustomRequestHeaders());
        }

        public GuidTaskResponse CreateVolumeAsync(string deviceid, VirtualDiskRequest diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.BeginCreating(deviceid, diskDetails, GetCustomRequestHeaders());
        }

        public TaskStatusInfo RemoveVolume(string deviceid, string diskid)
        {
            return GetStorSimpleClient().VirtualDisk.Delete(deviceid, diskid, GetCustomRequestHeaders());
        }
        public GuidTaskResponse RemoveVolumeAsync(string deviceid, string diskid)
        {
            return GetStorSimpleClient().VirtualDisk.BeginDeleting(deviceid, diskid, GetCustomRequestHeaders());
        }

        public TaskStatusInfo UpdateVolume(string deviceid, string diskid, VirtualDisk diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.Update(deviceid, diskid, diskDetails, GetCustomRequestHeaders());
        }
        public GuidTaskResponse UpdateVolumeAsync(string deviceid, string diskid, VirtualDisk diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.BeginUpdating(deviceid, diskid, diskDetails,GetCustomRequestHeaders());
        }
    }
}