// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirstPartyServiceTag", DefaultParameterSetName = FirstPartyServiceTagParameterSetNames.ByName), OutputType(typeof(PSFirstPartyServiceTag), typeof(IEnumerable<PSFirstPartyServiceTag>))]
    public class GetFirstPartyServiceTagCommand : FirstPartyServiceTagBaseCmdlet
    {
        [Parameter(ParameterSetName = FirstPartyServiceTagParameterSetNames.ByName, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(ParameterSetName = FirstPartyServiceTagParameterSetNames.ByName, ValueFromPipelineByPropertyName = true, HelpMessage = "The first party service tag name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ResourceNameCompleter("Microsoft.Network/firstPartyServiceTags", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = FirstPartyServiceTagParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The first party service tag resource ID.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/firstPartyServiceTags")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName == FirstPartyServiceTagParameterSetNames.ByResourceId)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                WriteObject(GetFirstPartyServiceTag(ResourceGroupName, Name));
                return;
            }

            IEnumerable<FirstPartyServiceTag> serviceTags;
            if (ShouldListBySubscription(ResourceGroupName, Name))
            {
                var page = FirstPartyServiceTagsClient.ListAll();
                serviceTags = ListNextLink<FirstPartyServiceTag>.GetAllResourcesByPollingNextLink(
                    page,
                    FirstPartyServiceTagsClient.ListAllNext);
            }
            else
            {
                var page = FirstPartyServiceTagsClient.List(ResourceGroupName);
                serviceTags = ListNextLink<FirstPartyServiceTag>.GetAllResourcesByPollingNextLink(
                    page,
                    FirstPartyServiceTagsClient.ListNext);
            }

            var output = serviceTags.Select(serviceTag => ToPSFirstPartyServiceTag(serviceTag)).ToList();
            WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, output), true);
        }
    }
}
