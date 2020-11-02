﻿// ----------------------------------------------------------------------------------
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

using System;
using System.Management.Automation;

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.DataCollectionRules
{
    /// <summary>
    /// Update a Data Collection Rule
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionRule", DefaultParameterSetName = ByFile, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDataCollectionRuleResource))]
    public class SetAzureRmDataCollectionRuleCommand : ManagementCmdletBase
    {
        private const string ByFile = "ByFile";
        private const string ByInputObject = "ByInputObject";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the data collection rule object.
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "PSDataCollectionRuleResource Object.")]
        [ValidateNotNull]
        public PSDataCollectionRuleResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule file definition path
        /// </summary>
        [Parameter(ParameterSetName = ByFile, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The JSON file path.")]
        [ValidateNotNullOrEmpty]
        public string File { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet. Set-AzDataCollectionRule
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case ByFile:
                    ProcessRecordInternalByFile();
                    break;
                case ByInputObject:
                    CreateDataCollectionRule(InputObject.Id, InputObject.ConvertToApiObject());
                    break;
                default:
                    throw new Exception("Unkown ParameterSetName");
            }
        }

        private void ProcessRecordInternalByFile()
        {
            string rawJsonContent = Utilities.ReadFileContent(this.TryResolvePath(File));

            DataCollectionRuleResource dcr;
            PSDataCollectionRuleResource psDcr = SafeJsonConvert.DeserializeObject<PSDataCollectionRuleResource>(rawJsonContent, MonitorManagementClient.DeserializationSettings);
            if (psDcr == null || psDcr.DataSources == null)
            {
                dcr = SafeJsonConvert.DeserializeObject<DataCollectionRuleResource>(rawJsonContent, MonitorManagementClient.DeserializationSettings);
            }
            else
            {
                dcr = psDcr.ConvertToApiObject();
            }

            CreateDataCollectionRule(dcr.Id, dcr);
        }

        private void CreateDataCollectionRule(string resourceId, DataCollectionRuleResource dcr) 
        {
            var resourceIdentifier = new ResourceIdentifier(resourceId);
            var name = resourceIdentifier.ResourceName;
            var resourceGroupName = resourceIdentifier.ResourceGroupName;

            if (ShouldProcess(
                        target: string.Format("Data collection rule '{0}' in resource group '{1}'", name, resourceGroupName),
                        action: "Update a data collection rule"))
            {
                var dcrRespone = this.MonitorManagementClient.DataCollectionRules.Create(
                    resourceGroupName: resourceGroupName, 
                    dataCollectionRuleName: name, 
                    body: dcr);

                var output = new PSDataCollectionRuleResource(dcrRespone);
                WriteObject(sendToPipeline: output);
            }
        }
    }
}