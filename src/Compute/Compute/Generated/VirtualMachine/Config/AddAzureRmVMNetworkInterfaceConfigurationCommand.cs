//
// Copyright (c) Microsoft and contributors. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
//

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMNetworkInterfaceConfiguration", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachine))]
    public class AddAzureRmVMNetworkInterfaceConfigurationCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias("VirtualMachine")]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Primary { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineNetworkInterfaceIPConfiguration[] IpConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string NetworkApiVersion { get; set; }

        protected override void ProcessRecord()
        {
            if (!ShouldProcess("VirtualMachine", "Add network interface configuration"))
            {
                return;
            }

            if (this.VM.NetworkProfile == null)
            {
                this.VM.NetworkProfile = new NetworkProfile();
            }

            if (this.IsParameterBound(c => c.NetworkApiVersion))
            {
                this.VM.NetworkProfile.NetworkApiVersion = this.NetworkApiVersion;
            }

            if (this.VM.NetworkProfile.NetworkInterfaceConfigurations == null)
            {
                this.VM.NetworkProfile.NetworkInterfaceConfigurations =
                    new List<VirtualMachineNetworkInterfaceConfiguration>();
            }

            var networkInterfaceConfiguration = new VirtualMachineNetworkInterfaceConfiguration();

            if (this.IsParameterBound(c => c.Name))
            {
                networkInterfaceConfiguration.Name = this.Name;
            }

            if (this.IsParameterBound(c => c.Primary))
            {
                networkInterfaceConfiguration.Primary = this.Primary.IsPresent;
            }

            if (this.IsParameterBound(c => c.IpConfiguration))
            {
                networkInterfaceConfiguration.IpConfigurations =
                    this.IpConfiguration == null
                        ? null
                        : new List<VirtualMachineNetworkInterfaceIPConfiguration>(this.IpConfiguration);
            }

            this.VM.NetworkProfile.NetworkInterfaceConfigurations.Add(networkInterfaceConfiguration);
            WriteObject(this.VM);
        }
    }
}
