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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public virtual PSDataFactoryGateway CreateOrUpdateGateway(string resourceGroupName, string dataFactoryName, PSDataFactoryGateway gateway)
        {
            if (gateway == null)
            {
                throw new ArgumentNullException("gateway");
            }

            var response = DataPipelineManagementClient.Gateways.CreateOrUpdate(
                resourceGroupName, dataFactoryName, new GatewayCreateOrUpdateParameters { Gateway = gateway.ToGatewayDefinition() });

            Gateway createdGateway = response.Gateway;
            if (createdGateway.Properties != null &&
                !DataFactoryCommonUtilities.IsSucceededProvisioningState(createdGateway.Properties.ProvisioningState))
            {
                // ToDo: service side should set the error message for provisioning failures.
                throw new ProvisioningFailedException(Resources.GatewayProvisioningFailed);
            }

            return new PSDataFactoryGateway(createdGateway);
        }

        public virtual PSDataFactoryGateway PatchGateway(string resourceGroupName, string dataFactoryName, PSDataFactoryGateway gateway)
        {
            if (gateway == null)
            {
                throw new ArgumentNullException("gateway");
            }

            var response = DataPipelineManagementClient.Gateways.Update(
                resourceGroupName, dataFactoryName, new GatewayCreateOrUpdateParameters { Gateway = gateway.ToGatewayDefinition() });

            return new PSDataFactoryGateway(response.Gateway);
        }

        public virtual List<PSDataFactoryGateway> ListGateways(string resourceGroupName, string dataFactoryName)
        {
            var response = DataPipelineManagementClient.Gateways.List(resourceGroupName, dataFactoryName);

            return response.Gateways.Select(gateway => new PSDataFactoryGateway(gateway)).ToList();
        }

        public virtual PSDataFactoryGateway GetGateway(string resourceGroupName, string dataFactoryName, string gatewayName)
        {
            var response = DataPipelineManagementClient.Gateways.Get(resourceGroupName, dataFactoryName, gatewayName);

            return new PSDataFactoryGateway(response.Gateway);
        }

        public virtual void DeleteGateway(string resourceGroupName, string dataFactoryName, string gatewayName)
        {
            DataPipelineManagementClient.Gateways.Delete(resourceGroupName, dataFactoryName, gatewayName);
        }

        public virtual PSDataFactoryGatewayKey RegenerateGatewayKey(string resourceGroupName, string dataFactoryName, string gatewayName)
        {
            var response = DataPipelineManagementClient.Gateways.RegenerateKey(resourceGroupName, dataFactoryName, gatewayName);

            return new PSDataFactoryGatewayKey(response.Key);
        }
    }
}