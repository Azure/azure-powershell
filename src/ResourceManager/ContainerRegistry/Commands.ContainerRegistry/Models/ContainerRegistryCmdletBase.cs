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

using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public abstract class ContainerRegistryCmdletBase : AzureRMCmdlet
    {
        protected const string ContainerRegistryNoun = "AzureRmContainerRegistry";
        protected const string ContainerRegistryCredentialNoun = ContainerRegistryNoun + "Credential";
        protected const string ContainerRegistryNameAvailabilityNoun = "AzureRmContainerRegistryNameAvailability";

        protected const string ContainerRegistryNameAlias = "ContainerRegistryName";
        protected const string RegistryNameAlias = "RegistryName";
        protected const string ResourceNameAlias = "ResourceName";

        protected const string ContainerRegistrySkuAlias = "ContainerRegistrySku";
        protected const string RegistrySkuAlias = "RegistrySku";

        protected const string TagsAlias = "Tags";
        protected const string EnableAdminAlias = "EnableAdmin";
        protected const string DisableAdminAlias = "DisableAdmin";

        protected const string AllowedSkuNames = "Allowed values: Basic.";
        protected const string AllowedPasswordNames = "Allowed values: password, password2.";

        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string RegistryNameParameterSet = "RegistryNameParameterSet";
        protected const string NameResourceGroupParameterSet = "NameResourceGroupParameterSet";
        protected const string RegistryObjectParameterSet = "RegistryObjectParameterSet";
        protected const string EnableAdminUserParameterSet = "EnableAdminUserParameterSet";
        protected const string DisableAdminUserParameterSet = "DisableAdminUserParameterSet";

        protected struct PasswordNameStrings
        {
            internal const string Password = "password";
            internal const string Password2 = "password2";
        }

        private ContainerRegistryClient _RegistryClient;

        public ContainerRegistryClient RegistryClient
        {
            get
            {
                if (_RegistryClient == null)
                {
                    _RegistryClient = new ContainerRegistryClient(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _RegistryClient;
            }

            set
            {
                _RegistryClient = value;
            }
        }

        private ResourceManagerClient _ResourceManagerClient;

        public ResourceManagerClient ResourceManagerClient
        {
            get
            {
                if (_ResourceManagerClient == null)
                {
                    _ResourceManagerClient = new ResourceManagerClient(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _ResourceManagerClient;
            }

            set
            {
                _ResourceManagerClient = value;
            }
        }
    }
}
