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

using System.Management.Automation;
using System.Net;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(
        VerbsCommon.New,
        AzureInternalLoadBalancerSettingNoun,
        DefaultParameterSetName = ServiceAndSlotParamSet),
    OutputType(
        typeof(InternalLoadBalancerConfig))]
    public class NewAzureInternalLoadBalancerConfig : ServiceManagementBaseCmdlet
    {
        protected const string AzureInternalLoadBalancerSettingNoun = "AzureInternalLoadBalancerConfig";
        protected const string ServiceAndSlotParamSet = "ServiceAndSlot";
        protected const string SubnetNameOnlyParamSet = "SubnetNameOnly";
        protected const string SubnetNameAndIPParamSet = "SubnetNameAndIP";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Internal Load Balancer Name.")]
        [ValidateNotNullOrEmpty]
        public string InternalLoadBalancerName { get; set; }

        [Parameter(
            ParameterSetName = SubnetNameOnlyParamSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet Name.")]
        [Parameter(
            ParameterSetName = SubnetNameAndIPParamSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet Name.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(
            ParameterSetName = SubnetNameAndIPParamSet,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet IP Address.")]
        [ValidateNotNullOrEmpty]
        public IPAddress StaticVNetIPAddress { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            WriteObject(new InternalLoadBalancerConfig
            {
                InternalLoadBalancerName = this.InternalLoadBalancerName,
                SubnetName = this.SubnetName,
                IPAddress = this.StaticVNetIPAddress == null ? null : this.StaticVNetIPAddress.ToString()
            });
        }
    }
}
