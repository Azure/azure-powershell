// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirstPartyServiceTag", SupportsShouldProcess = true), OutputType(typeof(PSFirstPartyServiceTag))]
    public class SetFirstPartyServiceTagCommand : FirstPartyServiceTagBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The first party service tag input object.")]
        [ValidateNotNull]
        public PSFirstPartyServiceTag FirstPartyServiceTag { get; set; }

        [Parameter(HelpMessage = "Run the cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!IsFirstPartyServiceTagPresent(FirstPartyServiceTag.ResourceGroupName, FirstPartyServiceTag.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceNotFound, FirstPartyServiceTag.Name));
            }

            if (ShouldProcess(FirstPartyServiceTag.Name, "Updating first party service tag"))
            {
                FirstPartyServiceTagsClient.CreateOrUpdate(
                    FirstPartyServiceTag.ResourceGroupName,
                    FirstPartyServiceTag.Name,
                    ToSdkFirstPartyServiceTag(FirstPartyServiceTag));

                WriteObject(GetFirstPartyServiceTag(FirstPartyServiceTag.ResourceGroupName, FirstPartyServiceTag.Name));
            }
        }
    }
}
