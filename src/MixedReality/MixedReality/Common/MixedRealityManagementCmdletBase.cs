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

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.MixedReality
{
    using Common.Authentication;
    using Common.Authentication.Abstractions;
    using Management.MixedReality;
    using ResourceManager.Common;

    /// <summary>
    /// Base class of Azure Mixed Reality Management Cmdlet.
    /// </summary>
    public abstract class MixedRealityManagementCmdletBase : AzureRMCmdlet
    {
        private IMixedRealityClient client;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        public const string DefaultParameterSet = "DefaultParameterSet";
        public const string ResourceIdParameterSet = "ResourceIdParameterSet";
        public const string PipelineParameterSet = "PipelineParameterSet";

        /// <summary>
        /// Gets or sets the Mixed Reality management client.
        /// </summary>
        internal protected IMixedRealityClient Client
        {
            get
            {
                return client ??
                       (client =
                           AzureSession.Instance.ClientFactory.CreateArmClient<MixedRealityClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { client = value; }
        }

        /// <summary>
        /// Gets or sets the default headers send with rest requests.
        /// </summary>
        public Dictionary<string, List<string>> DefaultRequestHeaders
        {
            get
            {
                return _defaultRequestHeaders ??
                       (_defaultRequestHeaders =
                           new Dictionary<string, List<string>> { { "UserAgent", new List<string> { "PowerShell" } } });
            }
            set { _defaultRequestHeaders = value; }
        }
    }
}
