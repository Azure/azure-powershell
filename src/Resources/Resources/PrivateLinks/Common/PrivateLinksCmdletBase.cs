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
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks.Common
{
    /// <summary>
    /// Base class of Resource Management Private Link.
    /// </summary>
    public class PrivateLinksCmdletBase : AzureRMCmdlet
    {
        private IResourcePrivateLinkClient _resourcePrivateLinkClient;

        public IResourcePrivateLinkClient ResourceManagementPrivateLinkClient
        {
            get
            {
                return _resourcePrivateLinkClient ??
                       (_resourcePrivateLinkClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<ResourcePrivateLinkClient>(
                               DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _resourcePrivateLinkClient = value; }
        }

        /// <summary>
        /// Override method to extract inner errors.
        /// </summary>
        /// <param name="ex">exception</param>
        protected override void WriteExceptionError(Exception ex)
        {
            var aggEx = ex as AggregateException;

            if (aggEx != null && aggEx.InnerExceptions != null)
            {
                foreach (var e in aggEx.Flatten().InnerExceptions)
                {
                    WriteExceptionError(e);
                }

                return;
            }

            base.WriteExceptionError(ex);
        }
    }
}
