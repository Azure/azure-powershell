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

using Azure.Security.KeyVault.Administration;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public static class RbacExtensions
    {
        public static KeyVaultPermission ToSdkType(this PSKeyVaultPermission psPermission)
        {
            var sdkPermission = new KeyVaultPermission();
            foreach (var x in psPermission.Actions)
            {
                sdkPermission.Actions.Add(x);
            }
            foreach (var x in psPermission.NotActions)
            {
                sdkPermission.NotActions.Add(x);
            }
            foreach (var x in psPermission.DataActions)
            {
                sdkPermission.DataActions.Add(x);
            }
            foreach (var x in psPermission.NotDataActions)
            {
                sdkPermission.NotDataActions.Add(x);
            }
            return sdkPermission;
        }
    }
}
