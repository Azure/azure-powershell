//
// Copyright (c) Microsoft and contributors. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
//

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
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
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Primary { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter("IPv4", "IPv6")]
        public string PrivateIPAddressVersion { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Alias("PublicIPAddressName")]
        public string PublicIPAddressConfigurationName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Alias("PublicIPAddressIdleTimeoutInMinutes")]
        public int PublicIPAddressConfigurationIdleTimeoutInMinutes { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Alias("PublicIPAddressDomainNameLabel")]
        public string DnsSetting { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineIpTag[] IpTag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string PublicIPPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter("IPv4", "IPv6")]
        public string PublicIPAddressVersion { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter("Dynamic", "Static")]
        public string PublicIPAllocationMethod { get; set; }

        protected override void ProcessRecord()
        {
            if (!ShouldProcess("VirtualMachine", "New"))
            {
                return;
            }

            var ipConfiguration = new VirtualMachineNetworkInterfaceIPConfiguration();

            if (this.IsParameterBound(c => c.Name))
            {
                ipConfiguration.Name = this.Name;
            }

            if (this.IsParameterBound(c => c.Primary))
            {
                ipConfiguration.Primary = this.Primary.IsPresent;
            }

            if (this.IsParameterBound(c => c.PrivateIPAddressVersion))
            {
                ipConfiguration.PrivateIPAddressVersion = this.PrivateIPAddressVersion;
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

            if (this.IsParameterBound(c => c.PublicIPAddressConfigurationIdleTimeoutInMinutes))
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.IdleTimeoutInMinutes =
                    this.PublicIPAddressConfigurationIdleTimeoutInMinutes;
            }

            if (this.IsParameterBound(c => c.DnsSetting))
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.DnsSettings =
                    new VirtualMachinePublicIPAddressDnsSettingsConfiguration(this.DnsSetting);
            }

            if (this.IpTag != null)
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.IpTags =
                    new List<VirtualMachineIpTag>(this.IpTag);
            }

            if (this.IsParameterBound(c => c.PublicIPPrefix))
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.PublicIPPrefix =
                    new SubResource { Id = this.PublicIPPrefix };
            }

            if (this.IsParameterBound(c => c.PublicIPAddressVersion))
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.PublicIPAddressVersion =
                    this.PublicIPAddressVersion;
            }

            if (this.IsParameterBound(c => c.PublicIPAllocationMethod))
            {
                ipConfiguration.PublicIPAddressConfiguration =
                    ipConfiguration.PublicIPAddressConfiguration ?? new VirtualMachinePublicIPAddressConfiguration();
                ipConfiguration.PublicIPAddressConfiguration.PublicIPAllocationMethod =
                    this.PublicIPAllocationMethod;
            }

            WriteObject(ipConfiguration);
        }
    }
}
