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

using LocalModels;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppUser"), OutputType(typeof(ConsentStatusModel))]
    public class GetAzureRemoteAppUser : RdsCmdlet
    {
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "User name. Wildcard pattern supported.")]
        [ValidateNotNullOrEmpty()]
        public string UserUpn { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Published program alias (applicable only in per-app publishing mode)")]
        [ValidateNotNullOrEmpty()]
        public string Alias { get; set; }

        private bool showAllUsers = false;

        public class ServicePrincipalComparer : IComparer<SecurityPrincipalInfo>
        {
            public int Compare(SecurityPrincipalInfo first, SecurityPrincipalInfo second)
            {
                if (first == null)
                {
                    if (second == null)
                    {
                        return 0; // both null are equal
                    }
                    else
                    {
                        return -1; // second is greateer
                    }
                }
                else
                {
                    if (second == null)
                    {
                        return 1; // first is greater as it is not null
                    }
                }

                return string.Compare(first.SecurityPrincipal.Name, second.SecurityPrincipal.Name, StringComparison.OrdinalIgnoreCase);
            }
        }

        private bool ProccessUsers(SecurityPrincipalInfoListResult response)
        {
            ConsentStatusModel model = null;
            bool found = false;

            if (ExactMatch)
            {
                SecurityPrincipalInfo userconsent = null;

                userconsent = response.SecurityPrincipalInfoList.FirstOrDefault(user => user.SecurityPrincipal.SecurityPrincipalType == PrincipalType.User &&
                String.Equals(user.SecurityPrincipal.Name, UserUpn, StringComparison.OrdinalIgnoreCase));

                if (userconsent == null)
                {
                    WriteErrorWithTimestamp("User: " + UserUpn + " does not exist in collection " + CollectionName);
                    found = false;
                }
                else
                {
                    model = new ConsentStatusModel(userconsent);
                    WriteObject(model);
                    found = true;
                }
            }
            else
            {
                IEnumerable<SecurityPrincipalInfo> spList = null;

                if (showAllUsers)
                {
                    spList = response.SecurityPrincipalInfoList.Where(user => user.SecurityPrincipal.SecurityPrincipalType == PrincipalType.User);
                }
                else
                {
                    spList = response.SecurityPrincipalInfoList.Where(user => user.SecurityPrincipal.SecurityPrincipalType == PrincipalType.User &&
                    Wildcard.IsMatch(user.SecurityPrincipal.Name));
                }

                if (spList != null && spList.Count() > 0)
                {
                    List<SecurityPrincipalInfo> userConsents = new List<SecurityPrincipalInfo>(spList);
                    IComparer<SecurityPrincipalInfo> comparer = new ServicePrincipalComparer();

                    userConsents.Sort(comparer);
                    foreach (SecurityPrincipalInfo consent in userConsents)
                    {
                        model = new ConsentStatusModel(consent);
                        WriteObject(model);
                    }
                    found = true;
                }
            }

            return found;
        }
        public override void ExecuteCmdlet()
        {
            SecurityPrincipalInfoListResult response = null;
            bool found = false;

            showAllUsers =  String.IsNullOrWhiteSpace(UserUpn);

            if (showAllUsers == false)
            {
                CreateWildcardPattern(UserUpn);
            }

            // You must pass in an empty string to this call. After that pass in the token returned by the previous call
            if (String.IsNullOrEmpty(Alias))
            {
                response = CallClient(() => Client.Principals.List(CollectionName), Client.Principals);
            }
            else
            {
                response = CallClient(() => Client.Principals.ListForApp(CollectionName, Alias), Client.Principals);
            }

            if (response != null && response.SecurityPrincipalInfoList != null)
            {
                found = ProccessUsers(response);
            }

            if (!found && !showAllUsers)
            {
                WriteVerboseWithTimestamp(String.Format("User '{0}' is not assigned to Collection '{1}'.", UserUpn, CollectionName));
            }

        }
    }
}
