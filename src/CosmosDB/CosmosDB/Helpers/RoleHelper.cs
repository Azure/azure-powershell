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

using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.CosmosDB.Helpers
{
    public static class RoleHelper
    {
        private static Regex roleDefinitionPrefix = new Regex("/subscriptions/(?<Subscription>.*)/resourceGroups/(?<ResourceGroup>.*)/providers/Microsoft.DocumentDB/databaseAccounts/(?<DatabaseAccount>.*)/sqlRoleDefinitions/(?<RoleDefinitionId>.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex roleAssignmentPrefix = new Regex("/subscriptions/(?<Subscription>.*)/resourceGroups/(?<ResourceGroup>.*)/providers/Microsoft.DocumentDB/databaseAccounts/(?<DatabaseAccount>.*)/sqlRoleAssignments/(?<RoleAssignmentId>.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex scopePrefix = new Regex("/subscriptions/(?<Subscription>.*)/resourceGroups/(?<ResourceGroup>.*)/providers/Microsoft.DocumentDB/databaseAccounts/(?<DatabaseAccount>.*)/?(?<Scope>.*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string ParseToRoleDefinitionId(string id)
        {
            Match match = roleDefinitionPrefix.Match(id);
            if(match.Success)
            {
                return match.Groups["RoleDefinitionId"].Value;
            }
            else
            {
                return id;
            }
        }

        public static string ParseToFullyQualifiedRoleDefinitionId(string id, string subscription, string resourceGroup, string databaseAccount)
        {
            Match match = roleDefinitionPrefix.Match(id);
            if (match.Success)
            {
                return id;
            }
            else
            {
                return $"/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.DocumentDB/databaseAccounts/{databaseAccount}/sqlRoleDefinitions/{id}";
            }
        }

        public static string ParseToRoleAssignmentId(string id)
        {
            Match match = roleAssignmentPrefix.Match(id);
            if (match.Success)
            {
                return match.Groups["RoleAssignmentId"].Value;
            }
            else
            {
                return id;
            }
        }

        public static string ParseToFullyQualifiedScope(string scope, string subscription, string resourceGroup, string databaseAccount)
        {
            Match match = scopePrefix.Match(scope);
            if (match.Success)
            {
                return scope;
            }
            else
            {
                scope = scope.Trim('/');
                return $"/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.DocumentDB/databaseAccounts/{databaseAccount}/{scope}";
            }
        }
    }
}