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

namespace Microsoft.Azure.Commands.ResourceManager.Common.Serialization
{
    public class LegacyAzureContext
    {
        /// <summary>
        /// Gets the azure account.
        /// </summary>
        public LegacyAzureAccount Account { get;  set; }

        /// <summary>
        /// Gets the azure subscription.
        /// </summary>
        public LegacyAzureSubscription Subscription { get;  set; }

        /// <summary>
        /// Gets the azure environment.
        /// </summary>
        public LegacyAzureEnvironment Environment { get;  set; }

        /// <summary>
        /// Gets the azure tenant.
        /// </summary>
        public LegacyAzureTenant Tenant { get;  set; }

        /// <summary>
        /// Gets or sets the token cache contents.
        /// </summary>
        public byte[] TokenCache { get; set; }
    }
}
