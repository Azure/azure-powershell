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

using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Devices
{
    public class DataBoxEdgeDeviceAlert
    {
        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string DeviceName { get; set; }
        public string Name { get; set; }
        public DataBoxEdgeManagementClient DataBoxEdgeManagementClient;

        public PSDataBoxEdgeDevice DeviceObject { get; set; }


        private Alert GetResource()
        {
            return this.DataBoxEdgeManagementClient.Alerts.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private IPage<Alert> ListResource()
        {
            return this.DataBoxEdgeManagementClient.Alerts.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<Alert> ListResource(string nextPageLink)
        {
            return this.DataBoxEdgeManagementClient.Alerts.ListByDataBoxEdgeDeviceNext(
                nextPageLink);
        }

        private List<PSDataBoxEdgeAlert> GetResourceByName()
        {
            return new List<PSDataBoxEdgeAlert>() {new PSDataBoxEdgeAlert(GetResource()) };
        }

        public List<PSDataBoxEdgeAlert> Get()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetResourceByName();
            }

            var listResource = ListResource();
            var paginatedResult = new List<Alert>(listResource);
            while (!string.IsNullOrEmpty(listResource.NextPageLink))
            {
                listResource = ListResource(listResource.NextPageLink);
                paginatedResult.AddRange(listResource);
            }

            return paginatedResult.Select(t => new PSDataBoxEdgeAlert(t)).ToList();
        }

        public DataBoxEdgeDeviceAlert(DataBoxEdgeManagementClient dataBoxManagementClient,
            string respResourceGroupName, string deviceName)
        {
            this.DataBoxEdgeManagementClient = dataBoxManagementClient;
            this.DeviceName = deviceName;
            this.ResourceGroupName = respResourceGroupName;
        }
    }
}