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
using System.Threading;

namespace Microsoft.Azure.Commands.Insights.LogProfiles
{
    /// <summary>
    /// Removes the log profile.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmLogProfile", SupportsShouldProcess = true), OutputType(typeof(AzureOperationResponse))]
    public class RemoveAzureRmLogProfileCommand : ManagementCmdletBase
    {
        #region Parameters declarations

        /// <summary>
        /// Gets or sets the name of the log profile
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the log profile")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (ShouldProcess(
                target: string.Format("Remove a log profile: {0}", this.Name),
                action: "Remove a log profile"))
            {
                Rest.Azure.AzureOperationResponse result = this.MonitorManagementClient.LogProfiles.DeleteWithHttpMessagesAsync(logProfileName: this.Name, cancellationToken: CancellationToken.None).Result;

                var response = new AzureOperationResponse
                {
                    RequestId = result.RequestId,
                    StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK
                };

                if (this.PassThru)
                {
                    WriteObject(response);
                }
            }
        }
    }
}
