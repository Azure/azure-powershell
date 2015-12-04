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
        public DataContainerListResponse GetAllDataContainers(string deviceId)
        {
            return this.GetStorSimpleClient().DataContainer.List(deviceId, this.GetCustomRequestHeaders());
        }

        public TaskStatusInfo GetTaskStatus(string taskId)
        {
            return GetStorSimpleClient().GetOperationStatus(taskId);
        }
        public TaskStatusInfo CreateDataContainer(string deviceId,DataContainerRequest dc)
        {
                return GetStorSimpleClient().DataContainer.Create(deviceId, dc, GetCustomRequestHeaders());
           
        }

        public TaskResponse CreateDataContainerAsync(string deviceId, DataContainerRequest dc)
        {
            return GetStorSimpleClient().DataContainer.BeginCreating(deviceId, dc, GetCustomRequestHeaders());
        }


        public DataContainerGetResponse GetDataContainer(string deviceId, string Name)
        {
            return GetStorSimpleClient().DataContainer.Get(deviceId, Name, GetCustomRequestHeaders());
        }

        public TaskResponse DeleteDataContainerAsync(string deviceid, string dcid)
        {
            return GetStorSimpleClient().DataContainer.BeginDeleting(deviceid, dcid, GetCustomRequestHeaders());
        }

        public TaskStatusInfo DeleteDataContainer(string deviceid, string dcid)
        {
            return GetStorSimpleClient().DataContainer.Delete(deviceid, dcid, GetCustomRequestHeaders());
        }
    }
}