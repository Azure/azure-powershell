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
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSVirtualMachine VirtualMachine { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public bool? Primary { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
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

            if (this.VirtualMachine.NetworkProfile == null)
            {
                this.VirtualMachine.NetworkProfile = new NetworkProfile();
            }

            if (this.IsParameterBound(c => c.NetworkApiVersion))
            {
                this.VirtualMachine.NetworkProfile.NetworkApiVersion = this.NetworkApiVersion;
            }

            if (this.VirtualMachine.NetworkProfile.NetworkInterfaceConfigurations == null)
            {
                this.VirtualMachine.NetworkProfile.NetworkInterfaceConfigurations =
                    new List<VirtualMachineNetworkInterfaceConfiguration>();
            }

            var networkInterfaceConfiguration = new VirtualMachineNetworkInterfaceConfiguration();

            if (this.IsParameterBound(c => c.Name))
            {
                networkInterfaceConfiguration.Name = this.Name;
            }

            if (this.IsParameterBound(c => c.Primary))
            {
                networkInterfaceConfiguration.Primary = this.Primary;
            }

            if (this.IsParameterBound(c => c.IpConfiguration))
            {
                networkInterfaceConfiguration.IpConfigurations =
                    this.IpConfiguration == null
                        ? null
                        : new List<VirtualMachineNetworkInterfaceIPConfiguration>(this.IpConfiguration);
            }

            this.VirtualMachine.NetworkProfile.NetworkInterfaceConfigurations.Add(networkInterfaceConfiguration);
            WriteObject(this.VirtualMachine);
        }
    }
}
