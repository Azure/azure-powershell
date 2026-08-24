//
// Copyright (c) Microsoft and contributors. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
//

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMIpConfig", SupportsShouldProcess = true)]
    [OutputType(typeof(VirtualMachineNetworkInterfaceIPConfiguration))]
    public class NewAzureRmVMIpConfigCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Primary { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Alias("PublicIPAddressName")]
        public string PublicIPAddressConfigurationName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineIpTag[] IpTag { get; set; }

        protected override void ProcessRecord()
        {
            var ipConfiguration = new VirtualMachineNetworkInterfaceIPConfiguration();

            if (this.IsParameterBound(c => c.Name))
            {
                ipConfiguration.Name = this.Name;
            }

            if (this.IsParameterBound(c => c.Primary))
            {
                ipConfiguration.Primary = this.Primary.IsPresent;
            }

            if (this.IsParameterBound(c => c.SubnetId))
            {
                ipConfiguration.Subnet = new SubResource { Id = this.SubnetId };
            }

            if (this.IsParameterBound(c => c.PublicIPAddressConfigurationName))
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.Name = this.PublicIPAddressConfigurationName;
            }

            if (this.IsParameterBound(c => c.IpTag))
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.IpTags =
                    this.IpTag == null ? null : new List<VirtualMachineIpTag>(this.IpTag);
            }

            WriteObject(ipConfiguration);
        }
    }
}
