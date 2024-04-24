﻿using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using MNM = Microsoft.Azure.Management.Network.Models;


namespace Microsoft.Azure.Commands.Network.AzureFirewall.PacketCapture
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPacketCaptureParameter", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPacketCaptureParameters))]
    public class NewAzureFirewallPacketCaptureParametersCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The intended durations of packet capture in seconds")]
        [ValidateRange(30,1800)]
        public uint DurationInSeconds { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The intended number of packets to capture")]
        [ValidateRange(100,90000)]
        public uint NumberOfPacketsToCapture { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Upload capture storage container SASURL with write and delete permissions")]
        [ValidateNotNullOrEmpty]
        public virtual string SasUrl { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of packet capture file")]
        [ValidateNotNullOrEmpty]
        public virtual string FileName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Protocols to capture")]
        [ValidateSet(
            MNM.AzureFirewallNetworkRuleProtocol.Any,
            MNM.AzureFirewallNetworkRuleProtocol.TCP,
            MNM.AzureFirewallNetworkRuleProtocol.UDP,
            MNM.AzureFirewallNetworkRuleProtocol.Icmp,
            IgnoreCase = false)]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of tcp-flags to capture")]
        public string[] Flag { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of filters to capture")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPacketCaptureRule[] Filter { get; set; }

        public override void Execute()
        {
            base.Execute();

            List<PSAzureFirewallPacketCaptureFlags> PSFlags = new List<PSAzureFirewallPacketCaptureFlags>();
            
            if(Flag != null)
            {
                foreach (var flag in Flag)
                {
                    PSFlags.Add(PSAzureFirewallPacketCaptureFlags.MapUserInputToPacketCaptureFlag(flag));
                }
            }          

            var packetCaptureParameters = new PSAzureFirewallPacketCaptureParameters
            {
                DurationInSeconds = this.DurationInSeconds,
                NumberOfPacketsToCapture = this.NumberOfPacketsToCapture,
                SasUrl = this.SasUrl,
                FileName = this.FileName,
                Protocol = this.Protocol,
                Flags = PSFlags,
                Filters = this.Filter?.ToList(),

            };

            WriteObject(packetCaptureParameters);
        }
    }
}
