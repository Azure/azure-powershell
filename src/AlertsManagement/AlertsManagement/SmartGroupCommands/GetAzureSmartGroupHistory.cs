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

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SmartGroupHistory", DefaultParameterSetName = ByIdParameterSet)]
    [OutputType(typeof(PSSmartGroupModification))]
    public class GetAzureSmartGroupHistory : AlertsManagementBaseCmdlet
    {
        #region Parameter sets
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByIdParameterSet = "BySmartGroupId";
        #endregion

        #region Parameters declarations
        /// <summary>
        /// Smart group Id
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByIdParameterSet,
                   HelpMessage = "Unique Identifier of SmartGroup / ResourceId of alert.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string SmartGroupId { get; set; }

        /// <summary>
        /// Input Object
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByInputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Input object from pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSSmartGroup InputObject { get; set; }
        #endregion

        protected override void ProcessRecordInternal()
        {
            string id = SmartGroupId;
            switch (ParameterSetName)
            {
                case ByIdParameterSet:
                    id = CommonUtils.GetIdFromARMResourceId(SmartGroupId);
                    break;

                case ByInputObjectParameterSet:
                    id = CommonUtils.GetIdFromARMResourceId(InputObject.Id);
                    break;
            }

            PSSmartGroupModification history = new PSSmartGroupModification(
                        this.AlertsManagementClient.SmartGroups.GetHistoryWithHttpMessagesAsync(id).Result.Body);
            WriteObject(sendToPipeline: history.Items, enumerateCollection: true);
        }
    }
}