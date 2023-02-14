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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertObjectHistory", DefaultParameterSetName = ByIdParameterSet)]
    [OutputType(typeof(PSAlertModification))]
    public class GetAzureAlertObjectHistory : AlertsManagementBaseCmdlet
    {
        #region Parameter sets
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByIdParameterSet = "ByAlertId";
        #endregion

        #region Parameters declarations
        /// <summary>
        /// Alert Id
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByIdParameterSet,
                   HelpMessage = "Unique Identifier of Alert / ResourceId of alert.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string AlertId { get; set; }

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
            string id = AlertId;
            switch (ParameterSetName)
            {
                case ByIdParameterSet:
                    id = CommonUtils.GetIdFromARMResourceId(AlertId);
                    break;

                case ByInputObjectParameterSet:
                    id = CommonUtils.GetIdFromARMResourceId(InputObject.Id);
                    break;
            }

            var test = this.AlertsManagementClient.Alerts.GetHistoryWithHttpMessagesAsync(id).Result.Body;
            PSAlertModification history = new PSAlertModification(test);
            WriteObject(sendToPipeline: history.Items, enumerateCollection: true);
        }
    }
}