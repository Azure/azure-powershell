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

namespace Microsoft.Azure.Commands.DataShare.Common
{
    using Microsoft.Azure.Management.DataShare;
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    /// <summary>
    /// Base class of azure data share cmdlet.
    /// </summary>
    [GenericBreakingChange("DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.")]
    public class AzureDataShareCmdletBase : AzureRMCmdlet
    {
        private IDataShareManagementClient dataShareManagementClient;

        private Dictionary<string, List<string>> defaultRequestHeaders;

        /// <summary>
        /// Gets or sets the DataShare management client.
        /// </summary>
        public IDataShareManagementClient DataShareManagementClient
        {
            get => this.dataShareManagementClient ??
                   (this.dataShareManagementClient =
                       AzureSession.Instance.ClientFactory.CreateArmClient<DataShareManagementClient>(
                           this.DefaultProfile.DefaultContext,
                           AzureEnvironment.Endpoint.ResourceManager));
            set => this.dataShareManagementClient = value;
        }

        /// <summary>
        /// Gets or sets the default headers send with rest requests.
        /// </summary>
        public Dictionary<string, List<string>> DefaultRequestHeaders
        {
            get => this.defaultRequestHeaders ??
                   (this.defaultRequestHeaders =
                       new Dictionary<string, List<string>> { { "UserAgent", new List<string> { "PowerShell" } } });
            set => this.defaultRequestHeaders = value;
        }
    }
}