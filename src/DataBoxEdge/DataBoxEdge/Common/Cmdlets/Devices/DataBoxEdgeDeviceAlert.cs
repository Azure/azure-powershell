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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Rest.Azure;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.Alert;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeAlert;
using PSTopLevelResourceObject = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeDevice;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Devices
{
    public class DataBoxEdgeAlert
    {
        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string DeviceName { get; set; }
        public string Name { get; set; }
        private DataBoxEdgeManagementClient _dataBoxManagementClient;

        public PSTopLevelResourceObject DeviceObject { get; set; }


        private ResourceModel GetResourceModel()
        {
            return AlertsOperationsExtensions.Get(
                this._dataBoxManagementClient.Alerts,
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private IPage<ResourceModel> ListResourceModel()
        {
            return AlertsOperationsExtensions.ListByDataBoxEdgeDevice(
                this._dataBoxManagementClient.Alerts,
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<ResourceModel> ListResourceModel(string nextPageLink)
        {
            return AlertsOperationsExtensions.ListByDataBoxEdgeDeviceNext(
                this._dataBoxManagementClient.Alerts,
                nextPageLink);
        }

        private List<PSResourceModel> GetByResourceName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSResourceModel>() {new PSResourceModel(resourceModel)};
        }

        public List<PSResourceModel> Get()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetByResourceName();
            }

            var resourceModels = ListResourceModel();
            var paginatedResult = new List<ResourceModel>(resourceModels);
            while (!string.IsNullOrEmpty(resourceModels.NextPageLink))
            {
                resourceModels = ListResourceModel(resourceModels.NextPageLink);
                paginatedResult.AddRange(resourceModels);
            }

            return paginatedResult.Select(t => new PSResourceModel(t)).ToList();
        }

        public DataBoxEdgeAlert(DataBoxEdgeManagementClient dataBoxManagementClient,
            string respResourceGroupName, string deviceName)
        {
            this._dataBoxManagementClient = dataBoxManagementClient;
            this.DeviceName = deviceName;
            this.ResourceGroupName = respResourceGroupName;
        }
    }
}