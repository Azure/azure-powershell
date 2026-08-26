//
// Copyright (c) Microsoft and contributors. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
//

using System.Management.Automation;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMIpTagConfig", SupportsShouldProcess = true)]
    [OutputType(typeof(VirtualMachineIpTag))]
    public class NewAzureRmVMIpTagConfigCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.PSArgumentCompleter("FirstPartyUsage", "NetworkDomain")]
        public string IpTagType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string FirstPartyServiceTagId { get; set; }

        protected override void ProcessRecord()
        {
            if (!ShouldProcess("VirtualMachine", "New"))
            {
                return;
            }

            var ipTag = new VirtualMachineIpTag();

            if (this.IsParameterBound(c => c.IpTagType))
            {
                ipTag.IpTagType = this.IpTagType;
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                ipTag.Tag = this.Tag;
            }

            if (this.IsParameterBound(c => c.FirstPartyServiceTagId))
            {
                ipTag.FirstPartyServiceTagId = this.FirstPartyServiceTagId;
            }

            WriteObject(ipTag);
        }
    }
}
