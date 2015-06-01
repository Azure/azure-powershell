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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppSession"), OutputType(typeof(RemoteAppSession))]
    public class GetAzureRemoteAppSession : RdsCmdlet
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
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Session user UPN. Wildcards are permitted.")]
        public string UserUpn { get; set; }

        public override void ExecuteCmdlet()
        {
            CollectionSessionListResult response = null;
            List<RemoteAppSession> sessions = new List<RemoteAppSession>();

            if (!string.IsNullOrWhiteSpace(UserUpn))
            {
                CreateWildcardPattern(UserUpn);
            }

            response = CallClient(() => Client.Collections.ListSessions(CollectionName), Client.Collections);

            if (ExactMatch)
            {
                foreach (RemoteAppSession session in response.Sessions)
                {
                    if (string.Equals(session.UserUpn, UserUpn))
                    {
                        sessions.Add(session);
                        break;
                    }
                }

                if (sessions.Count == 0)
                {
                    WriteErrorWithTimestamp("No session found matching " + UserUpn);
                }
            }
            else
            {
                if (UseWildcard)
                {
                    foreach (RemoteAppSession session in response.Sessions)
                    {
                        if (Wildcard.IsMatch(session.UserUpn))
                        {
                            sessions.Add(session);
                        }
                    }
                }
                else
                {
                    sessions.AddRange(response.Sessions);
                }

                if (response.Sessions.Count == 0)
                {
                    WriteVerboseWithTimestamp("No sessions found in collection.");
                }
                else
                {
                    WriteObject(response.Sessions, true);
                }
            }
        }
    }
}
