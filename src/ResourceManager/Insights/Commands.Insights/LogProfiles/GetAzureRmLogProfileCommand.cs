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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Insights.Models;
using System.Linq;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.Insights.LogProfiles
{
    /// <summary>
    /// Gets the log profiles.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmLogProfile"), OutputType(typeof(PSLogProfileCollection))]
    public class GetAzureRmLogProfileCommand : ManagementCmdletBase
    {

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the name of the log profile.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the log profile.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            var result = new PSLogProfileCollection();
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                LogProfileListResponse resultList = this.InsightsManagementClient.LogProfilesOperations.ListAsync(CancellationToken.None).Result;

                result.AddRange(resultList.LogProfileCollection.Value.Select(x => new PSLogProfile(x.Id, x.Name, x.Properties)));
            }
            else
            {
                LogProfileGetResponse logProfiles = this.InsightsManagementClient.LogProfilesOperations.GetAsync(this.Name, CancellationToken.None).Result;
                var psResult = new PSLogProfile(logProfiles.Id, this.Name, logProfiles.Properties);
                result.Add(psResult);
            }

            WriteObject(result);
        }
    }
}
