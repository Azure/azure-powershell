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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public abstract class ContainerRegistryCmdletBase : AzureRMCmdlet
    {
        protected const string ContainerRegistryNoun = "AzureRmContainerRegistry";
        protected const string ContainerRegistryCredentialNoun = ContainerRegistryNoun + "Credential";
        protected const string ContainerRegistryNameAvailabilityNoun = "AzureRmContainerRegistryNameAvailability";
        protected const string ContainerRegistryReplicationNoun = "AzureRmContainerRegistryReplication";
        protected const string ContainerRegistryWebhookNoun = "AzureRmContainerRegistryWebhook";
        protected const string ContainerRegistryWebhookEventNoun = "AzureRmContainerRegistryWebhookEvent";

        protected const string ContainerRegistryNameAlias = "ContainerRegistryName";
        protected const string RegistryNameAlias = "RegistryName";
        protected const string ResourceNameAlias = "ResourceName";
        protected const string ReplicationNameAlias = "ReplicationName";
        protected const string ReplicationLocationAlias = "ReplicationLocation";
        protected const string ResourceIdAlias = "Id";

        protected const string WebhookNameAlias = "WebhookName";
        protected const string WebhookActionsAlias = "WebhookActions";
        protected const string WebhookUriAlias = "WebhookUri";
        protected const string WebhookHeadersAlias = "WebhookHeaders";
        protected const string WebhookStatusAlias = "WebhookStatus";
        protected const string WebhookScopeAlias = "WebhookScope";
        protected const string WebhookLocationAlias = "WebhookLocation";

        protected const string ContainerRegistrySkuAlias = "ContainerRegistrySku";
        protected const string RegistrySkuAlias = "RegistrySku";

        protected const string TagsAlias = "Tags";
        protected const string EnableAdminAlias = "EnableAdmin";
        protected const string DisableAdminAlias = "DisableAdmin";

        protected const string ListRegistriesParameterSet = "ListRegistriesParameterSet";
        protected const string RegistryNameParameterSet = "RegistryNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string NameResourceGroupParameterSet = "NameResourceGroupParameterSet";
        protected const string RegistryObjectParameterSet = "RegistryObjectParameterSet";
        protected const string ReplicationObjectParameterSet = "ReplicationObjectParameterSet";
        protected const string WebhookObjectParameterSet = "WebhookObjectParameterSet";
        protected const string EnableAdminUserByResourceNameParameterSet = "EnableAdminUserByResourceNameParameterSet";
        protected const string DisableAdminUserByResourceNameParameterSet = "DisableAdminUserByResourceNameParameterSet";
        protected const string EnableAdminUserByResourceIdParameterSet = "EnableAdminUserByResourceIdParameterSet";
        protected const string DisableAdminUserByResourceIdParameterSet = "DisableAdminUserByResourceIdParameterSet";
        protected const string ListWebhookByNameResourceGroupParameterSet = "ListWebhookByNameResourceGroupParameterSet";
        protected const string ListWebhookByRegistryObjectParameterSet = "ListWebhookByRegistryObjectParameterSet";
        protected const string ShowWebhookByNameResourceGroupParameterSet = "ShowWebhookByNameResourceGroupParameterSet";
        protected const string ShowWebhookByRegistryObjectParameterSet = "ShowWebhookByRegistryObjectParameterSet";
        protected const string ListWebhookEventsByNameResourceGroupParameterSet = "ListWebhookEventsByNameResourceGroupParameterSet";
        protected const string ListWebhookEventsByWebhookObjectParameterSet = "ListWebhookEventsByWebhookObjectParameterSet";
        protected const string ShowReplicationByNameResourceGroupParameterSet = "ShowReplicationByNameResourceGroupParameterSet";
        protected const string ShowReplicationByRegistryObjectParameterSet = "ShowReplicationByRegistryObjectParameterSet";
        protected const string ListReplicationByNameResourceGroupParameterSet = "ListReplicationByNameResourceGroupParameterSet";
        protected const string ListReplicationByRegistryObjectParameterSet = "ListReplicationByRegistryObjectParameterSet";
        protected const string ImportImageByResourceId = "ImportImageByResourceId";
        protected const string ImportImageByResourceIdWithCredential = "ImportImageByResourceIdWithCredential";
        protected const string ImportImageByRegistryUri = "ImportImageByRegistryUri";
        protected const string ImportImageByRegistryUriWithCredential = "ImportImageByRegistryUriWithCredential";
        protected const string AddNetworkRuleWithInputObject = "AddNetworkRuleWithInputObject";
        protected const string AddNetworkRuleWithoutInputObject = "AddAddNetworkRuleWithoutInputObject";
        protected const string ByVirtualNetworkRule = "ByVirtualNetworkRule";
        protected const string ByIPRule = "ByIPRule";


        protected const string InvalidRegistryResourceIdErrorMessage = "This is an invalid container registry resource id";
        protected const string InvalidRegistryOrWebhookResourceIdErrorMessage = "This is an invalid container registry resource id or webhook resource id";
        protected const string InvalidWebhookResourceIdErrorMessage = "This is an invalid webhook resource id";
        protected const string InvalidRegistryOrReplicationResourceIdErrorMessage = "This is an invalid container registry resource id or replication resource id";
        protected const string InvalidReplicationResourceIdErrorMessage = "This is an invalid replication resource id";

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
                    _RegistryClient = new ContainerRegistryClient(DefaultContext)
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
                    _ResourceManagerClient = new ResourceManagerClient(DefaultContext)
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

        private const string _acrTokenCacheKey = "AcrTokenCacheKey";
        private ContainerRegistryDataPlaneClient _RegistryDataPlaneClient;
        public ContainerRegistryDataPlaneClient RegistryDataPlaneClient
        {
            get
            {
                if (_RegistryDataPlaneClient == null)
                {
                    _RegistryDataPlaneClient = new ContainerRegistryDataPlaneClient(DefaultContext, _acrTokenCacheKey)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _RegistryDataPlaneClient;
            }

            set
            {
                _RegistryDataPlaneClient = value;
            }
        }

        protected void WriteInvalidResourceIdError(string msg)
        {
            WriteError(new ErrorRecord(new PSArgumentException(msg, "ResourceId"), string.Empty, ErrorCategory.InvalidArgument, null));
        }
    }
}
