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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchNetworkSecurityPerimeterConfiguration",
    DefaultParameterSetName = ResourceNameParameterSetName,
    SupportsShouldProcess = true),
    OutputType(typeof(Models.PSNetworkSecurityPerimeterConfiguration))]
    public class GetNetworkSecurityPerimeterConfigurationCommand : NetworkSecurityPerimeterConfigurationsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceGroupHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = NetworkSecurityPerimeterConfigurationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            // LIST
            if (Name == null)
            {
                ListNetworkSecurityPerimeterConfigurations(ResourceGroupName, ServiceName);
            }
            // GET
            else
            {
                GetNetworkSecurityPerimeterConfiguration(ResourceGroupName, ServiceName, Name);
            }
        }

        private void GetNetworkSecurityPerimeterConfiguration(
            string resourceGroupName,
            string serviceName,
            string networkSecurityPerimeterConfigurationName)
        {
            try
            {
                var networkSecurityPerimeterConfiguration = 
                    SearchClient.NetworkSecurityPerimeterConfigurations.GetWithHttpMessagesAsync(
                        resourceGroupName,
                        serviceName,
                        networkSecurityPerimeterConfigurationName).Result;

                WriteNetworkSecurityPerimeterConfiguration(networkSecurityPerimeterConfiguration.Body);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException is CloudException
                    && ((CloudException)ae.InnerException).Response?.StatusCode == HttpStatusCode.NotFound)
                {
                    // the method throws an exception when the service does not exist.
                    return;
                }

                throw ae.InnerException;
            }
        }

        private void ListNetworkSecurityPerimeterConfigurations(
            string resourceGroupName,
            string serviceName)
        {
            try
            {
                var networkSecurityPerimeterConfigurations =
                    SearchClient.NetworkSecurityPerimeterConfigurations.ListByServiceWithHttpMessagesAsync(
                        resourceGroupName,
                        serviceName).Result;

                WriteNetworkSecurityPerimeterConfigurationsList(networkSecurityPerimeterConfigurations.Body);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException is CloudException
                    && ((CloudException)ae.InnerException).Response?.StatusCode == HttpStatusCode.NotFound)
                {
                    // the method throws an exception when the service does not exist.
                    return;
                }

                throw ae.InnerException;
            }
        }
    }
}
