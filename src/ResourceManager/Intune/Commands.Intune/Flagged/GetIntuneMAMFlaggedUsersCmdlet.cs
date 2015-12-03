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
    using Microsoft.Azure.Commands.Intune.Properties;
    using System.Collections.Generic;
    using System.Management.Automation;


    /// <summary>
    /// Cmdlet to get the flagged MAM users.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneMAMFlaggedUser"), OutputType(typeof(List<FlaggedUser>), typeof(FlaggedUser))]
    public sealed class GetIntuneMAMFlaggedUsersCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the flagged user name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The flagged user name to fetch.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (Name != null)
            {
                GetMAMFlaggedUserByName();
            }
            else
            {
                GetMAMFlaggedUsers();
            }            
        }

        /// <summary>
        /// Get MAM flagged user by name
        /// </summary>
        private void GetMAMFlaggedUserByName()
        {
            var result = IntuneClient.GetMAMFlaggedUserByName(this.AsuHostName, Name);
            this.WriteObject(result);
        }

        /// <summary>
        /// Get MAM flagged users
        /// </summary>
        private void GetMAMFlaggedUsers()
        {
            MultiPageGetter<FlaggedUser> mpg = new MultiPageGetter<FlaggedUser>();
            List<FlaggedUser> items = mpg.GetAllResources(
               this.IntuneClient.GetMAMFlaggedUsers,
               this.IntuneClient.GetMAMFlaggedUsersNext,
               this.AsuHostName,
               filter: null,
               top: null,
               select: null);

            this.WriteObject(items, enumerateCollection: true);
        }
    }
}
