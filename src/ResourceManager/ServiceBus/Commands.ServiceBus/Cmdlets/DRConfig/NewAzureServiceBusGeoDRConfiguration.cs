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

using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.GeoDR
{
    /// <summary>
    /// 'New-AzureRmServicebusGeoDRConfiguration' Cmdlet Creates an new Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServicebusDRConfigurationVerb, DefaultParameterSetName = GeoDRParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSServiceBusDRConfigurationAttributes))]
    public class NewAzureRmEventHubGeoDRConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GeoDRParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSNamespaceAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "DR Configuration Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "DR Configuration PartnerNamespace")]
        [ValidateNotNullOrEmpty]
        public string PartnerNamespace { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "AlternateName")]
        [ValidateNotNullOrEmpty]
        public string AlternateName { get; set; }        

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSServiceBusDRConfigurationAttributes drConfiguration = new PSServiceBusDRConfigurationAttributes() { PartnerNamespace = this.PartnerNamespace };
            if (!string.IsNullOrEmpty(AlternateName))
                drConfiguration.AlternateName = AlternateName;

            if (ParameterSetName == NamespaceInputObjectParameterSet)
            {
                ResourceIdentifier getParamGeoDR = GetResourceDetailsFromId(InputObject.Id);

                if (getParamGeoDR.ResourceGroupName != null && getParamGeoDR.ResourceName != null)
                {
                    if (ShouldProcess(target: Name, action: string.Format(Resources.DRCreateAlias, Name, getParamGeoDR.ResourceName)))
                    {
                        WriteObject(Client.CreateServiceBusDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ResourceName, Name, drConfiguration));
                    }
                }
            }

            if (ParameterSetName == NamespaceResourceIdParameterSet)
            {
                ResourceIdentifier getParamGeoDR = GetResourceDetailsFromId(ResourceId);

                if (getParamGeoDR.ResourceGroupName != null && getParamGeoDR.ResourceName != null)
                {
                    if (ShouldProcess(target: Name, action: string.Format(Resources.DRCreateAlias, Name, getParamGeoDR.ResourceName)))
                    {
                        WriteObject(Client.CreateServiceBusDRConfiguration(getParamGeoDR.ResourceGroupName, getParamGeoDR.ResourceName, Name, drConfiguration));
                    }
                }
            }

            if (ParameterSetName == GeoDRParameterSet)
            {
                if (ShouldProcess(target: Name, action: string.Format(Resources.DRCreateAlias, Name, Namespace)))
                {
                    WriteObject(Client.CreateServiceBusDRConfiguration(ResourceGroupName, Namespace, Name, drConfiguration));
                }
            }
        }
    }
}
