// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirstPartyServiceTag", DefaultParameterSetName = FirstPartyServiceTagParameterSetNames.ByName, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveFirstPartyServiceTagCommand : FirstPartyServiceTagBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(ParameterSetName = FirstPartyServiceTagParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The first party service tag name.")]
        [ResourceNameCompleter("Microsoft.Network/firstPartyServiceTags", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = FirstPartyServiceTagParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = FirstPartyServiceTagParameterSetNames.ByObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The first party service tag input object.")]
        [ValidateNotNull]
        public PSFirstPartyServiceTag FirstPartyServiceTag { get; set; }

        [Parameter(ParameterSetName = FirstPartyServiceTagParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The first party service tag resource ID.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/firstPartyServiceTags")]
        public string ResourceId { get; set; }

        [Parameter(HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        [Parameter(HelpMessage = "Run the cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName == FirstPartyServiceTagParameterSetNames.ByObject)
            {
                Name = FirstPartyServiceTag.Name;
                ResourceGroupName = FirstPartyServiceTag.ResourceGroupName;
            }
            else if (ParameterSetName == FirstPartyServiceTagParameterSetNames.ByResourceId)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                Name = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            base.Execute();
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    FirstPartyServiceTagsClient.Delete(ResourceGroupName, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
