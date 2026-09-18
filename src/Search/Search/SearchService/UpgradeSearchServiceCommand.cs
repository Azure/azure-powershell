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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchServiceUpgrade",
    DefaultParameterSetName = ResourceGroupParameterSetName,
    SupportsShouldProcess = true),
    OutputType(typeof(bool))]
    public class UpgradeSearchServiceCommand : SearchServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSetName,
            HelpMessage = ResourceGroupHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                var id = new ResourceIdentifier(ResourceId);
                ResourceGroupName = id.ResourceGroupName;
                Name = id.ResourceName;
            }

            try
            {
                SearchClient.Services.UpgradeWithHttpMessagesAsync(ResourceGroupName, Name).Wait();

                if (PassThru)
                {
                    WriteObject(true);
                }
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
