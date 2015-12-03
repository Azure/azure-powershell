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

namespace Microsoft.Azure.Commands.Intune.Flagged
{
    using Management.Intune;
    using Management.Intune.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    /// Cmdlet to get the MAM flagged devices
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneMAMUserFlaggedEnrolledApp"), OutputType(typeof(List<FlaggedEnrolledApp>))]
    public sealed class GetIntuneMAMUserFlaggedEnrolledAppsCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the flagged user name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The flagged user name to fetch the enrolled Apps for.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            GetMAMUserFlaggedEnrolledApps();
        }

        /// <summary>
        /// Get MAM flagged devices
        /// </summary>
        private void GetMAMUserFlaggedEnrolledApps()
        {
            MultiPageGetter<FlaggedEnrolledApp> mpg = new MultiPageGetter<FlaggedEnrolledApp>();
            List<FlaggedEnrolledApp> items = mpg.GetAllResources(
               this.IntuneClient.GetMAMUserFlaggedEnrolledApps,
               this.IntuneClient.GetMAMUserFlaggedEnrolledAppsNext,
               this.AsuHostName,
               this.Name,
               filter: null,
               top: null,
               select: null);

            this.WriteObject(items, enumerateCollection: true);
        }
    }
}