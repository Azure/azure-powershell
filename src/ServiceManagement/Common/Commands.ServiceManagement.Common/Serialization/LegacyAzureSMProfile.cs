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
using Microsoft.Azure.Commands.Common.Serialization;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Common.Serialization
{
    /// <summary>
    /// Serialization class for legacy SM profiles
    /// </summary>
    public class LegacyAzureSMProfile
    {
        /// <summary>
        /// Environments in the profile
        /// </summary>
        public IList<LegacyAzureEnvironment> Environments { get; set; }

        /// <summary>
        /// Subscriptions in the profile
        /// </summary>
        public IList<LegacyAzureSubscription> Subscriptions { get; set; }

        /// <summary>
        /// Accounts in the profile
        /// </summary>
        public IList<LegacyAzureAccount> Accounts { get; set; }
    }
}
