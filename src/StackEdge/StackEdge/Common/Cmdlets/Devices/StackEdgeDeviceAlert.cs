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

using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Devices
{
    public class StackEdgeAlert
    {
        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string DeviceName { get; set; }
        public string Name { get; set; }
        private readonly DataBoxEdgeManagementClient _dataBoxManagementClient;

        public PSStackEdgeDevice DeviceObject { get; set; }


        private Alert GetResourceModel()
        {
            return this._dataBoxManagementClient.Alerts.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private IPage<Alert> ListResourceModel()
        {
            return this._dataBoxManagementClient.Alerts.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<Alert> ListResourceModel(string nextPageLink)
        {
            return this._dataBoxManagementClient.Alerts.ListByDataBoxEdgeDeviceNext(
                nextPageLink);
        }

        private List<PSStackEdgeAlert> GetByResourceName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSStackEdgeAlert>() {new PSStackEdgeAlert(resourceModel)};
        }

        public List<PSStackEdgeAlert> Get()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetByResourceName();
            }

            var resourceModels = ListResourceModel();
            var paginatedResult = new List<Alert>(resourceModels);
            while (!string.IsNullOrEmpty(resourceModels.NextPageLink))
            {
                resourceModels = ListResourceModel(resourceModels.NextPageLink);
                paginatedResult.AddRange(resourceModels);
            }

            return paginatedResult.Select(t => new PSStackEdgeAlert(t)).ToList();
        }

        public StackEdgeAlert(DataBoxEdgeManagementClient dataBoxManagementClient,
            string respResourceGroupName, string deviceName)
        {
            this._dataBoxManagementClient = dataBoxManagementClient;
            this.DeviceName = deviceName;
            this.ResourceGroupName = respResourceGroupName;
        }
    }
}