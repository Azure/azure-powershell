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
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Represents AS Azure profile structure with default context, environments and token cache.
    /// </summary>
    [Serializable]
    public sealed class AsAzureProfile
    {
        /// <summary>
        /// Gets or sets AS Azure environments.
        /// </summary>
        public Hashtable Environments { get; set; }

        /// <summary>
        /// Gets or sets the AS azure context object.
        /// </summary>
        public AsAzureContext Context { get; set; }

        /// <summary>
        /// Initializes a new instance of AsAzureProfile and loads its content from specified path.
        /// </summary>
        public AsAzureProfile()
        {
            this.Environments = new Hashtable();
        }

        /// <summary>
        /// Serializes the current profile and return its contents.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public AsAzureEnvironment CreateEnvironment(string environmentName)
        {
            var env = new AsAzureEnvironment(environmentName);
            env.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl, AsAzureClientSession.GetAuthorityUrlForEnvironment(env));
            env.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat, AsAzureClientSession.RestartEndpointPathFormat);
            env.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.LogfileEndpointFormat, AsAzureClientSession.LogfileEndpointPathFormat);
            env.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.SyncEndpoint, AsAzureClientSession.SynchronizeEndpointPathFormat);
            return env;
        }
    }
}
