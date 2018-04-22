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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network.Automation
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDdosProtectionPlan"), OutputType(typeof(PSDdosProtectionPlan))]
    public partial class GetAzureRmDdosProtectionPlan : NetworkBaseCmdlet
    {
        internal const string GetByNameGroupParameterSet = "GetByNameAndGroup";
        internal const string ListParameterSet = "List";

        [Parameter(
            ParameterSetName = GetByNameGroupParameterSet,
            Mandatory = true,
            HelpMessage = "Specifies the name of the DDoS protection plan resource group.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            ParameterSetName = ListParameterSet,
            Mandatory = false,
            HelpMessage = "Specifies the name of the DDoS protection plan resource group.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = GetByNameGroupParameterSet,
            Mandatory = true,
            HelpMessage = "Specifies the name of the DDoS protection plan.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if(!string.IsNullOrEmpty(this.Name))
            {
                var vDdosProtectionPlan = this.NetworkClient.NetworkManagementClient.DdosProtectionPlans.Get(ResourceGroupName, Name);
                var vDdosProtectionPlanModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSDdosProtectionPlan>(vDdosProtectionPlan);
                vDdosProtectionPlanModel.ResourceGroupName = this.ResourceGroupName;
                vDdosProtectionPlanModel.Tag = TagsConversionHelper.CreateTagHashtable(vDdosProtectionPlan.Tags);
                WriteObject(vDdosProtectionPlanModel, true);
            }
            else
            {
                IPage<DdosProtectionPlan> vDdosProtectionPlanPage;
                if(!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    vDdosProtectionPlanPage = this.NetworkClient.NetworkManagementClient.DdosProtectionPlans.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    vDdosProtectionPlanPage = this.NetworkClient.NetworkManagementClient.DdosProtectionPlans.List();
                }

                var vDdosProtectionPlanList = ListNextLink<DdosProtectionPlan>.GetAllResourcesByPollingNextLink(vDdosProtectionPlanPage,
                    this.NetworkClient.NetworkManagementClient.DdosProtectionPlans.ListNext);
                List<PSDdosProtectionPlan> psDdosProtectionPlanList = new List<PSDdosProtectionPlan>();
                foreach (var vDdosProtectionPlan in vDdosProtectionPlanList)
                {
                    var vDdosProtectionPlanModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSDdosProtectionPlan>(vDdosProtectionPlan);
                    vDdosProtectionPlanModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vDdosProtectionPlan.Id);
                    vDdosProtectionPlanModel.Tag = TagsConversionHelper.CreateTagHashtable(vDdosProtectionPlan.Tags);
                    psDdosProtectionPlanList.Add(vDdosProtectionPlanModel);
                }
                WriteObject(psDdosProtectionPlanList);
            }
        }
    }
}
