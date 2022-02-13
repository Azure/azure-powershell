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

using System;
using System.Collections;
using System.Management.Automation;

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionRule", DefaultParameterSetName = ByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDataCollectionRuleResource))]
    public class SetAzureRmDataCollectionRuleCommand : ManagementCmdletBase
    {
        private const string ByName = "ByName";
        private const string ByResourceId = "ByResourceId";
        private const string ByInputObject = "ByInputObject";
        private DataCollectionRuleResource Dcr;

        #region Cmdlet parameters
        /// <summary>
        /// Gets or sets the data collection rule location.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource location.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule name.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource identifier")]
        [Alias("ResourceId")]
        [ValidateNotNullOrEmpty]
        public string RuleId { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule file definition path
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The JSON file path.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The JSON file path.")]
        [ValidateNotNullOrEmpty]
        public string RuleFile { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule object.
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "PSDataCollectionRuleResource Object.")]
        [ValidateNotNull]
        public PSDataCollectionRuleResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule description.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource description.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule tags.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource tags.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource tags.")]
        public Hashtable Tag { get; set; }
        #endregion

        /// <summary>
        /// Executes the cmdlet. Set-AzDataCollectionRule
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            ResourceIdentifier resourceIdentifier;
            switch (ParameterSetName)
            {
                case ByName:
                    SetDcrByFile();
                    break;
                case ByResourceId:
                    resourceIdentifier = new ResourceIdentifier(RuleId);
                    RuleName = resourceIdentifier.ResourceName;
                    ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    SetDcrByFile();
                    break;
                case ByInputObject:
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                    RuleName = resourceIdentifier.ResourceName;
                    ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    Dcr = InputObject.ConvertToApiObject();
                    break;
                default:
                    throw new Exception("Unknown ParameterSetName");
            }

            ReplaceDataCollectionRule();
        }

        private void SetDcrByFile()
        {
            string rawJsonContent = Utilities.ReadFileContent(this.TryResolvePath(RuleFile));

            var psDcr = SafeJsonConvert.DeserializeObject<PSDataCollectionRuleResource>(rawJsonContent, MonitorManagementClient.DeserializationSettings);
            if (psDcr == null || psDcr.DataSources == null)
                Dcr = SafeJsonConvert.DeserializeObject<DataCollectionRuleResource>(rawJsonContent, MonitorManagementClient.DeserializationSettings);
            else
                Dcr = psDcr.ConvertToApiObject();
        }

        private void ReplaceDataCollectionRule()
        {
            if (Location != null) Dcr.Location = Location;
            if (Description != null) Dcr.Description = Description;
            if (Tag != null) Dcr.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            if (ShouldProcess(
                        target: string.Format("Data collection rule '{0}' in resource group '{1}'", RuleName, ResourceGroupName),
                        action: "Update a data collection rule"))
            {
                var dcrResponse = this.MonitorManagementClient.DataCollectionRules.Create(
                    resourceGroupName: ResourceGroupName,
                    dataCollectionRuleName: RuleName,
                    body: Dcr);

                var output = new PSDataCollectionRuleResource(dcrResponse);
                WriteObject(sendToPipeline: output);
            }
        }
    }
}