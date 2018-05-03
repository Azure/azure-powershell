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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmDdosProtectionPlan", SupportsShouldProcess = true), OutputType(typeof(PSDdosProtectionPlan))]
    public partial class NewAzureRmDdosProtectionPlan : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the resource group of the DDoS protection plan to be created.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the name of the DDoS protection plan to be created.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the location of the DDoS protection plan to be created.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/DdosProtectionPlans")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();


            var vDdosProtectionPlan = new PSDdosProtectionPlan
            {
                Location = this.Location,
            };

            var vDdosProtectionPlanModel = NetworkResourceManagerProfile.Mapper.Map<MNM.DdosProtectionPlan>(vDdosProtectionPlan);
            vDdosProtectionPlanModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.DdosProtectionPlans.Get(this.ResourceGroupName, this.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            ConfirmAction(
                true,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
            () =>
            {
                this.NetworkClient.NetworkManagementClient.DdosProtectionPlans.CreateOrUpdate(this.ResourceGroupName, this.Name, vDdosProtectionPlanModel);
                var getDdosProtectionPlan = this.NetworkClient.NetworkManagementClient.DdosProtectionPlans.Get(this.ResourceGroupName, this.Name);
                var psDdosProtectionPlan = NetworkResourceManagerProfile.Mapper.Map<PSDdosProtectionPlan>(getDdosProtectionPlan);
                psDdosProtectionPlan.ResourceGroupName = this.ResourceGroupName;
                psDdosProtectionPlan.Tag = TagsConversionHelper.CreateTagHashtable(getDdosProtectionPlan.Tags);
                WriteObject(psDdosProtectionPlan, true);
            },
            () => present);

        }
    }
}
