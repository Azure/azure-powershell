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

using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Helper class for database level identity
    /// </summary>
    public class DatabaseIdentityAndKeysHelper
    {
        /// <summary>
        /// Gets the database identity object
        /// </summary>
        /// <param name="assignIdentityIsPresent">Flag to check if AssignIdentity flag is used in the cmdlet.</param>
        /// <param name="userAssignedIdentities">User assigned identities</param>
        /// <returns>Database Identity</returns>
        public static DatabaseIdentity GetDatabaseIdentity(bool assignIdentityIsPresent, string[] userAssignedIdentities)
        {
            DatabaseIdentity identityResult = null;
            if (!assignIdentityIsPresent)
            {
                return identityResult;
            }

            if (userAssignedIdentities == null)
            {
                throw new PSArgumentNullException("The list of user assigned identity ids needs to be passed when configuring database level identity.");
            }

            Dictionary<string, DatabaseUserIdentity> identityDict = new Dictionary<string, DatabaseUserIdentity>();

            // Create identity on database
            //
            foreach (string identity in userAssignedIdentities)
            {
                if (!identityDict.ContainsKey(identity))
                {
                    identityDict.Add(identity, new DatabaseUserIdentity());
                }
            }

            identityResult = new DatabaseIdentity()
            {
                Type = DatabaseIdentityType.UserAssigned,
                UserAssignedIdentities = identityDict
            };

            return identityResult;
        }

        /// <summary>
        /// Gets the dictionary of database keys to be passed to the api.
        /// </summary>
        /// <param name="akvKeys">List of AKV keys</param>
        /// <returns>Dictionary of database keys</returns>
        public static Dictionary<string, DatabaseKey> GetDatabaseKeysDictionary(string[] akvKeys)
        {
            Dictionary<string, DatabaseKey> akvKeysResult = new Dictionary<string, DatabaseKey>();

            if (akvKeys != null && akvKeys.Any())
            {
                foreach (string akvKey in akvKeys)
                {
                    if (!akvKeysResult.ContainsKey(akvKey))
                    {
                        akvKeysResult.Add(akvKey, new DatabaseKey());
                    }
                }
            }

            return akvKeysResult;
        }

        /// <summary>
        /// Gets the dictionary of database keys to be removed to the api.
        /// </summary>
        /// <param name="akvKeys">List of AKV keys</param>
        /// <param name="newDBModel">New DB Model to be updated</param>
        /// <returns>Dictionary of database keys</returns>
        public static void GetDatabaseKeysDictionaryToRemove(string[] akvKeys, ref AzureSqlDatabaseModel newDBModel)
        {
            if (newDBModel.Keys == null)
            {
                newDBModel.Keys = new Dictionary<string, DatabaseKey>();
            }

            if (akvKeys != null && akvKeys.Any())
            {
                foreach (string akvKey in akvKeys)
                {
                    if (!newDBModel.Keys.ContainsKey(akvKey))
                    {
                        newDBModel.Keys.Add(akvKey, null);
                    }
                }
            }
        }
    }
}
