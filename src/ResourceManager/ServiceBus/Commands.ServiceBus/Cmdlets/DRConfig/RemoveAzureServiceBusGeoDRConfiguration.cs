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

using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.ServiceBus.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.GeoDR
{
    /// <summary>
    /// 'Remove-AzServicebusGeoDRConfiguration' Cmdlet Deletes an Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusGeoDRConfiguration", DefaultParameterSetName = GeoDRParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveServicBusGeoDRConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]   
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Alias (GeoDR) Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Service Bus GeoDR Configuration Object")]
        [ValidateNotNullOrEmpty]
        public PSServiceBusDRConfigurationAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRConfigResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "GeoDRConfiguration Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == GeoDRInputObjectParameterSet)
            {
                LocalResourceIdentifier getParamGeoDR = new LocalResourceIdentifier(InputObject.Id);
                ResourceGroupName = getParamGeoDR.ResourceGroupName;
                Namespace = getParamGeoDR.ParentResource;
                Name = getParamGeoDR.ResourceName;
            }

            if (ParameterSetName == GeoDRConfigResourceIdParameterSet)
            {
                LocalResourceIdentifier getParamGeoDR = new LocalResourceIdentifier(ResourceId);
                ResourceGroupName = getParamGeoDR.ResourceGroupName;
                Namespace = getParamGeoDR.ParentResource;
                Name = getParamGeoDR.ResourceName;
            }

            if (ShouldProcess(target: Name, action: string.Format(Resources.DRRemoveAlias, Name, Namespace)))
            {
                try
                {
                    Client.DeleteServiceBusDRConfiguration(ResourceGroupName, Namespace, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
                catch (ErrorResponseException ex)
                {
                    WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                }                
            }
        }
    }
}
