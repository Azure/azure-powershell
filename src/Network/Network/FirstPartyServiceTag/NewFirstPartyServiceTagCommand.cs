// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirstPartyServiceTag", SupportsShouldProcess = true), OutputType(typeof(PSFirstPartyServiceTag))]
    public class NewFirstPartyServiceTagCommand : FirstPartyServiceTagBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The first party service tag name.")]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]{0,79}$")]
        [ResourceNameCompleter("Microsoft.Network/firstPartyServiceTags", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource location.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Network/firstPartyServiceTags")]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The value of the first party service tag.")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "A hashtable representing resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(HelpMessage = "Do not ask for confirmation when overwriting an existing resource.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "Run the cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = IsFirstPartyServiceTagPresent(ResourceGroupName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var serviceTag = new FirstPartyServiceTag
                    {
                        Location = Location,
                        Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                        Properties = new FirstPartyServiceTagPropertiesFormat(Value)
                    };

                    FirstPartyServiceTagsClient.CreateOrUpdate(ResourceGroupName, Name, serviceTag);
                    WriteObject(GetFirstPartyServiceTag(ResourceGroupName, Name));
                },
                () => present);
        }
    }
}
