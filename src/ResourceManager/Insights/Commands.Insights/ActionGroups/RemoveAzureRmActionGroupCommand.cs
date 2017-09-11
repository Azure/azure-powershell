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

using System.Management.Automation;
using System.Net;

using Microsoft.Azure.Commands.Insights.OutputClasses;

namespace Microsoft.Azure.Commands.Insights.ActionGroups
{
    /// <summary>
    /// Gets an Azure Action Group.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmActionGroup", SupportsShouldProcess = true), OutputType(typeof(PSActionGroupResource))]
    public class RemoveAzureRmActionGroupCommand : ManagementCmdletBase
    {
        private const string ByPropertyName = "ByPropertyName";

        private const string ByInputObject = "ByInputObject";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the action group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The action group name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The action group resource")]
        public PSActionGroupResource InputObject { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            if (ShouldProcess(
                target: string.Format("Delete action group: {0} from resource group: {1}", this.Name, this.ResourceGroup),
                action: "Delete action group"))
            {
                if (ParameterSetName == ByInputObject)
                {
                    this.ResourceGroup = InputObject.ResourceGroup;
                    this.Name = InputObject.Name;
                }

                var result =
                    this.MonitorManagementClient.ActionGroups.DeleteWithHttpMessagesAsync(
                        resourceGroupName: this.ResourceGroup,
                        actionGroupName: this.Name).Result;

                var response = new AzureOperationResponse
                               {
                                   RequestId = result.RequestId,
                                   StatusCode =
                                       result.Response != null
                                           ? result.Response.StatusCode
                                           : HttpStatusCode.OK
                               };

                WriteObject(response);
            }
        }
    }
}
