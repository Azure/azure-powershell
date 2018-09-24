// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2SVpnGatewayVpnProfile"),
        OutputType(typeof(PSVpnProfileResponse))]
    public class GetAzureRmP2SVpnGatewayVpnProfile : P2SVpnGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "ResourceGroup name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "P2SVpnGatewayName", "GatewayName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "P2SVpnGateway name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "AuthenticationMethod")]
        [ValidateSet(
        MNM.AuthenticationMethod.EAPTLS,
        MNM.AuthenticationMethod.EAPMSCHAPv2,
        IgnoreCase = true)]
        public string AuthenticationMethod { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsP2SVpnGatewayPresent(ResourceGroupName, Name))
            {
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, Name));
            }

            PSP2SVpnProfileParameters p2sVpnProfileParameters = new PSP2SVpnProfileParameters();
            p2sVpnProfileParameters.AuthenticationMethod = this.AuthenticationMethod;

            WriteObject(this.GenerateP2SVpnGatewayVpnProfile(ResourceGroupName, Name, p2sVpnProfileParameters));
        }
    }
}

