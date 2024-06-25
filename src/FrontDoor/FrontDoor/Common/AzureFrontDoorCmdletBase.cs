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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.FrontDoor;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.FrontDoor.Common
{
    /// <summary>
    /// Base class of Azure Front Door Cmdlet.
    /// </summary>
    public class AzureFrontDoorCmdletBase : AzureRMCmdlet
    {
        private IFrontDoor _frontDoorManagementClient;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        public const string ObjectParameterSet = "ByObjectParameterSet";
        public const string FieldsParameterSet = "ByFieldsParameterSet";
        public const string ResourceIdParameterSet = "ByResourceIdParameterSet";
        public const string FieldsWithVaultParameterSet = "ByFieldsWithVaultParameterSet";
        public const string ResourceIdWithVaultParameterSet = "ByResourceIdWithVaultParameterSet";
        public const string ObjectWithVaultParameterSet = "ByObjectWithVaultParameterSet";
        public const string FieldsWithRegularActionParameterSet = "ByFieldsWithRegularActionParameterSet";
        public const string FieldsWithForwardingParameterSet = "ByFieldsWithForwardingParameterSet";
        public const string FieldsWithRedirectParameterSet = "ByFieldsWithRedirectParameterSet";
        public const string FieldsWithBackendPoolsSettingParameterSet = "ByFieldsWithBackendPoolsSettingParameterSet";
        public const string ObjectWithBackendPoolsSettingParameterSet = "ByObjectWithBackendPoolsSettingParameterSet";
        public const string ResourceIdWithBackendPoolsSettingParameterSet = "ByResourceIdWithBackendPoolsSettingParameterSet";
        public const string FieldsWithCertificateNameCheckParameterSet = "ByFieldsWithCertificateNameCheckParameterSet";
        public const string ObjectWithCertificateNameCheckParameterSet = "ByObjectWithCertificateNameCheckParameterSet";
        public const string ResourceIdWithCertificateNameCheckParameterSet = "ByResourceIdWithCertificateNameCheckParameterSet";

        /// <summary>
        /// Gets or sets the Front Door management client.
        /// </summary>
        public IFrontDoor FrontDoorManagementClient
        {
            get
            {
                return _frontDoorManagementClient ??
                       (_frontDoorManagementClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<Management.FrontDoor.FrontDoor>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _frontDoorManagementClient = value; }
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
