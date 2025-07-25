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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.Properties;
using System;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertProcessingRule", DefaultParameterSetName = ByNameParameterSet, 
        SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureAlertProcessingRule : AlertsManagementBaseCmdlet
    {
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByNameParameterSet = "ByName";

        #region Parameters declarations

        /// <summary>
        /// Resource Group name
        /// </summary>
        [Parameter(Mandatory = true,
                    ParameterSetName = ByNameParameterSet,
                    HelpMessage = "Resource Group name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Action Rule name
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByNameParameterSet,
                   HelpMessage = "Name of alert processing rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Resource Id of Action rule
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByResourceIdParameterSet,
                   HelpMessage = "Delete Alert Processing rule by resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the input object
        /// </summary>
        [Parameter(ParameterSetName = ByInputObjectParameterSet, 
                    Mandatory = true, 
                    ValueFromPipeline = true, 
                    HelpMessage = "The alert processing rule resource")]
        public PSAlertProcessingRule InputObject { get; set; }

        /// <summary>
        /// Gets or sets the PassThru switch parameter to force return an object when removing
        /// </summary>
        [Parameter(Mandatory = false,
                    HelpMessage = "PassThru returns an object representing the item with which you are working."+
                    " By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru;

        #endregion

        protected override void ProcessRecordInternal()
        {
            bool? isDeleted = false;
            try
            {

              
                switch (ParameterSetName)
                {
                    case ByResourceIdParameterSet:
                        if (ShouldProcess(
                            target: string.Format(Resources.Target, this.ResourceId),
                            action: Resources.RemoveAlertProcessingRule_Action))
                        {
                            var extractedInfo = CommonUtils.ExtractFromActionRuleResourceId(ResourceId);
                            isDeleted = this.AlertsManagementClient.AlertProcessingRules.DeleteWithHttpMessagesAsync(
                                resourceGroupName: extractedInfo.ResourceGroupName,
                                alertProcessingRuleName: extractedInfo.Resource)
                                .Result.Response.IsSuccessStatusCode;
                        }

                        if (PassThru.IsPresent)
                        {
                            WriteObject(isDeleted);
                        }
                        break;
                
                    case ByInputObjectParameterSet:
                        if (ShouldProcess(
                            target: string.Format(Resources.Target, this.InputObject.Id),
                            action: Resources.RemoveAlertProcessingRule_Action))
                        {
                            var extractedInfo = CommonUtils.ExtractFromActionRuleResourceId(InputObject.Id);
                            isDeleted = this.AlertsManagementClient.AlertProcessingRules.DeleteWithHttpMessagesAsync(
                                resourceGroupName: extractedInfo.ResourceGroupName,
                                alertProcessingRuleName: extractedInfo.Resource)
                                .Result.Response.IsSuccessStatusCode;
                        }

                        if (PassThru.IsPresent)
                        {
                            WriteObject(isDeleted);
                        }

                        break;
                
                    case ByNameParameterSet:
                        if (ShouldProcess(
                           target: string.Format(Resources.TargetWithRG, this.Name, this.ResourceGroupName),
                           action: Resources.RemoveAlertProcessingRule_Action))
                        {
                            isDeleted = this.AlertsManagementClient.AlertProcessingRules.DeleteWithHttpMessagesAsync(
                                resourceGroupName: ResourceGroupName,
                                alertProcessingRuleName: Name)
                                .Result.Response.IsSuccessStatusCode;
                        }

                        if (PassThru.IsPresent)
                        {
                            WriteObject(isDeleted);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}