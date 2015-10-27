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

namespace Microsoft.Azure.Commands.Intune
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using RestClient;
    /// <summary>
    /// Cmdlet to get apps for iOS platform.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneAndroidMAMPolicyGroup"), OutputType(typeof(PSObject))]
    public sealed class GetIntuneAndroidMAMPolicyGroupCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the policy Name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The policy name to fetch for the groups.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
            Action action = () =>
            {
                var groupCollection = this.IntuneClient.GetGroupsForAndroidMAMPolicy(this.AsuHostName, this.Name);

                if (groupCollection != null && groupCollection.Value.Count > 0)
                {
                    for (int batchSize = 10, start = 0; start < groupCollection.Value.Count; start += batchSize)
                    {
                        var batch = groupCollection.Value.Skip(start).Take(batchSize);
                        this.WriteObject(batch, enumerateCollection: true);
                    }
                }
                else
                {
                    this.WriteObject("0 groups returned");
                }
            };

            this.SafeExecutor(action);
        }

    }
}