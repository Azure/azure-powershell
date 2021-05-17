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

namespace Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions
{
    internal static class ExceptionMessage
    {
        public const string Conflict = "Resource with Name {0} already exists.";
        public const string NotFound = "Resource with Name {0} does not exist.";

        public const string ConflictSqlRoleResourceId = "Role {0} with Id [{1}] already exists.";
        public const string NotFoundSqlRoleResourceId = "Role {0} with Id [{1}] does not exist.";
        public const string NotFoundSqlRoleResourceName = "Role {0} with Name [{1}] does not exist.";
    }
}
