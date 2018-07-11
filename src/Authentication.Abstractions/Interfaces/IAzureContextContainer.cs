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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Storage container for all targeted environments, allowing the user to store named target configurations
    /// </summary>
    public interface IAzureContextContainer: IExtensibleModel
    {
        /// <summary>
        /// The azure target configuration to use by default
        /// </summary>
        IAzureContext DefaultContext { get; set; }

        /// <summary>
        /// The set of environments that can be targeted
        /// </summary>
        IEnumerable<IAzureEnvironment> Environments { get; }

        /// <summary>
        /// The set of all subscriptions used in the container
        /// </summary>
        IEnumerable<IAzureSubscription> Subscriptions { get; }

        /// <summary>
        /// The set of all accounts in the container
        /// </summary>
        IEnumerable<IAzureAccount> Accounts { get; }

        /// <summary>
        /// Remove all contexts from the container
        /// </summary>
        void Clear();
    }
}
