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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpPrefix", SupportsShouldProcess = true), OutputType(typeof(PSPublicIpPrefix))]
    public class SetAzurePublicIpPrefixCommand : PublicIpPrefixBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The PublicIpPrefix")]
        public PSPublicIpPrefix PublicIpPrefix { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsPublicIpPrefixPresent(this.PublicIpPrefix.ResourceGroupName, this.PublicIpPrefix.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var theModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PublicIPPrefix>(this.PublicIpPrefix);
            theModel.Tags = TagsConversionHelper.CreateTagDictionary(this.PublicIpPrefix.Tag, validate: true);

            if (this.ShouldProcess(this.PublicIpPrefix.Name, $"Setting PublicIpPrefix Name:{this.PublicIpPrefix.Name} in ResourceGroup: {this.PublicIpPrefix.ResourceGroupName}"))
            {
                this.PublicIpPrefixClient.CreateOrUpdate(this.PublicIpPrefix.ResourceGroupName, this.PublicIpPrefix.Name, theModel);

                var getPublicIpPrefix = this.GetPublicIpPrefix(this.PublicIpPrefix.ResourceGroupName, this.PublicIpPrefix.Name);

                WriteObject(getPublicIpPrefix);
            }
        }
    }
}
