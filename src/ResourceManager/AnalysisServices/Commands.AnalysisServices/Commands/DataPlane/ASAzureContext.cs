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

using Newtonsoft.Json;
using System;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    /// <summary>
    /// Represents current Azure session context.
    /// </summary>
    [Serializable]
    public class AsAzureContext
    {
        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The azure tenant object</param>
        public AsAzureContext(AsAzureAccount account, AsAzureEnvironment environment)
        {
            Account = account;
            Environment = environment;
            //Tenant = tenant;
        }

        /// <summary>
        /// Gets the azure account.
        /// </summary>
        public AsAzureAccount Account { get; private set; }

        /// <summary>
        /// Gets the azure environment.
        /// </summary>
        public AsAzureEnvironment Environment { get; private set; }

        ///// <summary>
        ///// Gets the azure tenant.
        ///// </summary>
        //public AsAzureTenant Tenant { get; private set; }

        /// <summary>
        /// Gets or sets the token cache contents.
        /// </summary>
        public byte[] TokenCache { get; set; }
    }
}
