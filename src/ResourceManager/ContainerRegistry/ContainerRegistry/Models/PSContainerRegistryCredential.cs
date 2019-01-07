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

using Microsoft.Azure.Management.ContainerRegistry.Models;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class PSContainerRegistryCredential
    {
        public PSContainerRegistryCredential(RegistryListCredentialsResult credentials)
        {
            Username = credentials?.Username;
            Password = credentials?.Passwords?.Count > 0 ? credentials.Passwords[0]?.Value : string.Empty;
            Password2 = credentials?.Passwords?.Count > 1 ? credentials.Passwords[1]?.Value : string.Empty;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
