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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Cdn;

namespace Microsoft.Azure.Commands.Cdn.Common
{
    /// <summary>
    /// Base class of Azure Cdn Cmdlet.
    /// </summary>
    public class AzureCdnCmdletBase : AzureRMCmdlet
    {
        private ICdnManagementClient _cdnManagementClient;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        public const string ObjectParameterSet = "Parameter Set for object parameters";
        public const string FieldsParameterSet = "Parameter Set for fields parameters";

        /// <summary>
        /// Gets or sets the Cdn management client.
        /// </summary>
        public ICdnManagementClient CdnManagementClient
        {
            get
            {
                return _cdnManagementClient ??
                       (_cdnManagementClient =
                           AzureSession.ClientFactory.CreateArmClient<CdnManagementClient>(DefaultProfile.Context,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _cdnManagementClient = value; }
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

        public void ConfirmAction(bool force, string actionMessage, Action action)
        {
            if (force || ShouldContinue(actionMessage, ""))
            {
                action();
            }
        }
    }
}
