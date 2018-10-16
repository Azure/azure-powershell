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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.Management.Automation;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpPrefix", SupportsShouldProcess = true, DefaultParameterSetName = RemoveAzurePublicIpPrefixParameterSetNames.Default), OutputType(typeof(bool))]
    public class RemoveAzurePublicIpPrefixCommand : PublicIpPrefixBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = RemoveAzurePublicIpPrefixParameterSetNames.RemoveByName)]
        [ResourceNameCompleter("Microsoft.Network/publicIPPrefixes", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = RemoveAzurePublicIpPrefixParameterSetNames.RemoveByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true, 
            ParameterSetName = RemoveAzurePublicIpPrefixParameterSetNames.DeleteByResourceId)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipeline = true, 
            ParameterSetName = RemoveAzurePublicIpPrefixParameterSetNames.DeleteByInputObject)]
        [ValidateNotNull]
        public PSPublicIpPrefix InputObject
        {
            get; set;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.RemovingResource, Name),
                Microsoft.Azure.Commands.Network.Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    if (this.ShouldProcess(this.Name, $"Deleting PublicIpPrefix {this.Name} in ResourceGroup {this.ResourceGroupName}"))
                    {
                        this.PublicIpPrefixClient.Delete(this.ResourceGroupName, this.Name);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    }
                });
        }
    }

    public static class RemoveAzurePublicIpPrefixParameterSetNames
    {
        public const string RemoveByName = "RemoveByNameParameterSet";
        public const string DeleteByResourceId = "DeleteByResourceIdParameterSet";
        public const string DeleteByInputObject = "DeleteByInputObjectParameterSet";

        // The Default
        public const string Default = RemoveAzurePublicIpPrefixParameterSetNames.RemoveByName;
    }
}
