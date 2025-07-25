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
using System.Management.Automation;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Helper class for job agent level identity
    /// </summary>
    public class JobAgentIdentityHelper
    {
        /// <summary>
        /// Gets the job agent identity object for Set-* or New-* command aka PUT request. 
        /// For PUT request on JobAgentIdentity, expectation is that passed in UMI will either replace any existing UMI or be created on the job agent. 
        /// Also, passing in IdentityType.None should remove any Identity info from the job agent. 
        /// </summary>
        /// <param name="identityType">Identity type</param>
        /// <param name="userAssignedIdentities">User assigned identities</param>
        /// <returns>JobAgentIdentity</returns>
        public static JobAgentIdentity GetJobAgentIdentity(string identityType, string[] userAssignedIdentities)
        {
            if (identityType == null && userAssignedIdentities == null)
            {
                return null;
            }

            if (identityType == null || !(identityType.Equals(JobAgentIdentityType.UserAssigned.ToString()) || identityType.Equals(JobAgentIdentityType.None.ToString())))
            {
                throw new PSArgumentException("Invalid IdentityType. Supported types are: UserAssigned, None");
            }

            // If the user passes in IdentityType as None, we return None to remove all Identity info from the Job Agent
            if (identityType.Equals(JobAgentIdentityType.None.ToString()))
            {
                // Throw if the customer put None but still passed in a UMI.
                if (userAssignedIdentities != null)
                {
                    throw new PSArgumentException("Invalid IdentityType: UserAssignedIdentityId is only supported for 'UserAssigned' identity type.");
                }

                return new JobAgentIdentity()
                {
                    Type = JobAgentIdentityType.None.ToString()
                };
            }

            // At this point we know that the IdentityType must be UserAssigned. Therefore, validate the userAssignedIdentities 
            if (userAssignedIdentities == null)
            {
                throw new PSArgumentNullException("The list of user assigned identity ids needs to be passed if the IdentityType is UserAssigned.");
            }

            // Now we know that identity type is UserAssigned and there are UMIs. Any other checks will be left to the API. 
            var umiDict = new Dictionary<string, JobAgentUserAssignedIdentity>();
            foreach (string identity in userAssignedIdentities)
            {
                umiDict.Add(identity, new JobAgentUserAssignedIdentity());
            }

            return new JobAgentIdentity()
            {
                Type = JobAgentIdentityType.UserAssigned.ToString(),
                UserAssignedIdentities = umiDict
            };
        }
    }
}
