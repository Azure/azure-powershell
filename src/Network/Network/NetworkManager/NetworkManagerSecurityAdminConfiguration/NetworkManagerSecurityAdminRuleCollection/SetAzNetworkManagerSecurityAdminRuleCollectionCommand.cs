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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityAdminRuleCollection", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerSecurityAdminRuleCollection))]
    public class SetAzNetworkManagerSecurityAdminRuleCollection : NetworkManagerSecurityAdminRuleCollectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The NetworkManagerSecurityAdminRuleCollection")]
        public PSNetworkManagerSecurityAdminRuleCollection InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (!this.IsNetworkManagerSecurityAdminRuleCollectionPresent(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.SecurityAdminConfigurationName, this.InputObject.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.InputObject.Name));
                }

                // Map to the sdk object
                var securityRuleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.AdminRuleCollection>(this.InputObject);

                // Execute the PUT NetworkManagerSecurityAdminRuleCollection call
                this.NetworkManagerSecurityAdminRuleCollectionClient.CreateOrUpdate(securityRuleCollectionModel, this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.SecurityAdminConfigurationName, this.InputObject.Name);
                var psSecurityRuleCollection = this.GetNetworkManagerSecurityAdminRuleCollection(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.SecurityAdminConfigurationName, this.InputObject.Name);
                WriteObject(psSecurityRuleCollection);
            }
        }
    }
}
