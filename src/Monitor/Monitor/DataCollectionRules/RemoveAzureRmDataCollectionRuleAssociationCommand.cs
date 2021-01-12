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
using System.Management.Automation;

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Insights.DataCollectionRules
{
    /// <summary>
    /// Delete a Data Collection Rule Association
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionRuleAssociation", DefaultParameterSetName = ByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmDataCollectionRuleAssociationCommand : ManagementCmdletBase
    {
        private const string ByName = "ByName";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the associated resource.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The associated resource id.")]
        [Alias("ResourceUri")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource name")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AssociationName { get; set; }

        /// <summary>
        /// Gets or sets the InputObject parameter
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The data collection rule association resource from the pipe")]
        [ValidateNotNull]
        public PSDataCollectionRuleAssociationProxyOnlyResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource identifier")]
        [Alias("ResourceId")]
        [ValidateNotNullOrEmpty]
        public string AssociationId { get; set; }

        /// <summary>
        /// Gets or sets the PassThru switch parameter to force return an object when removing the resource.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return true upon successful removal.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet. Remove-AzDataCollectionRuleAssociation
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case ByName:
                    break;
                case ByInputObject:
                    var dcra = new ResourceIdentifier(InputObject.Id);
                    TargetResourceId = InputObject.Id.Replace("/providers/Microsoft.Insights/dataCollectionRuleAssociations/" + dcra.ResourceName, "");
                    AssociationName = InputObject.Name;
                    break;
                case ByResourceId:
                    var dcraById = new ResourceIdentifier(AssociationId);
                    TargetResourceId = AssociationId.Replace("/providers/Microsoft.Insights/dataCollectionRuleAssociations/" + dcraById.ResourceName, "");
                    AssociationName = dcraById.ResourceName;
                    break;
                default:
                    throw new Exception("Unkown ParameterSetName");
            }

            if (ShouldProcess(
                    target: string.Format("Data collection rule association '{0}' from resource '{1}'", this.AssociationName, this.TargetResourceId),
                    action: "Delete a data collection rule association"))
            {
                this.MonitorManagementClient.DataCollectionRuleAssociations.DeleteWithHttpMessagesAsync(
                    resourceUri: TargetResourceId,
                    associationName: AssociationName).GetAwaiter().GetResult();

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}