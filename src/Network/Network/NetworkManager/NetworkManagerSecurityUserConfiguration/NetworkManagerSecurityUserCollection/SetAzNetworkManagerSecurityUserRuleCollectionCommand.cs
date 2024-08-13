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
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerSecurityUserRuleCollection))]
    public class SetAzNetworkManagerSecurityUserRuleCollection : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The NetworkManagerSecurityUserRuleCollection")]
        public PSNetworkManagerSecurityUserRuleCollection InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (!this.IsNetworkManagerSecurityUserRuleCollectionPresent(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.SecurityUserConfigurationName, this.InputObject.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.InputObject.Name));
                }

                // Map to the sdk object
                var securityUserRuleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityUserRuleCollection>(this.InputObject);

                // Execute the PUT NetworkManagerSecurityUserRuleCollection call
                this.NetworkManagerSecurityUserRuleCollectionClient.CreateOrUpdate(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.SecurityUserConfigurationName, this.InputObject.Name, securityUserRuleCollectionModel);

                var psSecurityUserRuleCollection = this.GetNetworkManagerSecurityUserRuleCollection(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.SecurityUserConfigurationName, this.InputObject.Name);
                WriteObject(psSecurityUserRuleCollection);
            }
        }
    }
}
