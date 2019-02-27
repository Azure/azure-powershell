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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Anf.Common
{

    /// <summary>
    /// Base class of Azure Cdn Cmdlet.
    /// </summary>
    public class AzureAnfCmdletBase : AzureRMCmdlet
    { 
        private IAzureNetAppFilesManagementClient _anfManagementClient;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        public const string ResourceIdParameterSet = "ByResouceIdParameterSet";
        public const string ObjectParameterSet = "ByObjectParameterSet";
        public const string FieldsParameterSet = "ByFieldsParameterSet";

        

        /// <summary>
        /// Gets or sets the ANF management client.
        /// </summary>
        public IAzureNetAppFilesManagementClient AzureNetAppFilesManagementClient
        {
            get
            {
                return _anfManagementClient ??
                       (_anfManagementClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<AzureNetAppFilesManagementClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _anfManagementClient = value; }
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
