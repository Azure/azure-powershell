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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
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
                IEnumerable<LogProfileResource> resultList = this.MonitorManagementClient.LogProfiles.ListAsync(cancellationToken: CancellationToken.None).Result;

                result.AddRange(resultList.Select(x => new PSLogProfile(logProfile: x)));
            }
            else
            {
                LogProfileResource logProfile = this.MonitorManagementClient.LogProfiles.GetAsync(logProfileName: this.Name, cancellationToken: CancellationToken.None).Result;
                result.Add(new PSLogProfile(logProfile: logProfile));
            }

            WriteObject(result, enumerateCollection: true);
        }
    }
}
