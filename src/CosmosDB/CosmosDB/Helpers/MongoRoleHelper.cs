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

using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.CosmosDB.Helpers
{
    public static class MongoRoleHelper
    {
        private static Regex mongoDBRoleDefinitionPrefix = new Regex("/subscriptions/(?<Subscription>.*)/resourceGroups/(?<ResourceGroup>.*)/providers/Microsoft.DocumentDB/databaseAccounts/(?<DatabaseAccount>.*)/mongodbRoleDefinitions/(?<MongoDBRoleDefinitionId>.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex mongoDBUserDefinitionPrefix = new Regex("/subscriptions/(?<Subscription>.*)/resourceGroups/(?<ResourceGroup>.*)/providers/Microsoft.DocumentDB/databaseAccounts/(?<DatabaseAccount>.*)/mongodbUserDefinitions/(?<MongoDBUserDefinitionId>.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string ParseToMongoDbRoleDefinitionId(string id)
        {
            Match match = mongoDBRoleDefinitionPrefix.Match(id);
            if (match.Success)
            {
                return match.Groups["MongoDBRoleDefinitionId"].Value;
            }
            else
            {
                return id;
            }
        }

        public static string ParseToFullyQualifiedRoleDefinitionId(string id, string subscription, string resourceGroup, string databaseAccount)
        {
            Match match = mongoDBRoleDefinitionPrefix.Match(id);
            if (match.Success)
            {
                return id;
            }
            else
            {
                return $"/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.DocumentDB/databaseAccounts/{databaseAccount}/mongodbRoleDefinitions/{id}";
            }
        }

        public static string ParseToMongoDbUserDefinitionId(string id)
        {
            Match match = mongoDBUserDefinitionPrefix.Match(id);
            if (match.Success)
            {
                return match.Groups["MongoDBUserDefinitionId"].Value;
            }
            else
            {
                return id;
            }
        }

        public static string ParseToFullyQualifiedUSerDefinitionId(string id, string subscription, string resourceGroup, string databaseAccount)
        {
            Match match = mongoDBUserDefinitionPrefix.Match(id);
            if (match.Success)
            {
                return id;
            }
            else
            {
                return $"/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.DocumentDB/databaseAccounts/{databaseAccount}/mongodbUserDefinitions/{id}";
            }
        }

    }
}