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
//
namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal interface ISupportsDisableInstanceDiscovery
    {
        /// <summary>
        /// Gets or sets the setting which determines whether or not instance discovery is performed when attempting to authenticate.
        /// Setting this to true will completely disable both instance discovery and authority validation.
        /// This functionality is intended for use in scenarios where the metadata endpoint cannot be reached, such as in private clouds or Azure Stack.
        /// The process of instance discovery entails retrieving authority metadata from https://login.microsoft.com/ to validate the authority.
        /// By setting this to <c>true</c>, the validation of the authority is disabled.
        /// As a result, it is crucial to ensure that the configured authority host is valid and trustworthy."
        /// </summary>
        bool DisableInstanceDiscovery { get; set; }
    }
}
