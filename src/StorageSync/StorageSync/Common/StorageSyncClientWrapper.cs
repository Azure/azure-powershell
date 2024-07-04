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
using Microsoft.Azure.Commands.StorageSync.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users.Models;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Rest.Azure.OData;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// Class StorageSyncClientWrapper.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Interfaces.IStorageSyncClientWrapper" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Interfaces.IStorageSyncClientWrapper" />
    public class StorageSyncClientWrapper : IStorageSyncClientWrapper
    {
        /// <summary>
        /// The azure cloud kailani application identifier
        /// TODO : Az.StorageSync Remove KailaniAppId(s) from Cmdlet code https://github.com/Azure/azure-powershell/issues/8652
        /// </summary>
        private static Guid AzureCloudKailaniAppId = new Guid("9469b9f5-6722-4481-a2b2-14ed560b706f");

        /// <summary>
        /// The azure us government kailani application identifier
        /// </summary>

        private static Guid AzureUSGovernmentKailaniAppId = new Guid("ce88d19b-f69a-4c2e-ac8a-d1aa9db611e8");

        /// <summary>
        /// The built in role definition identifier
        /// </summary>
        public const string BuiltInRoleDefinitionId = "c12c1c16-33a1-487b-954d-41c89c60f349";

        /// <summary>
        /// Gets or sets the storage sync management client.
        /// </summary>
        /// <value>The storage sync management client.</value>
        public IStorageSyncManagementClient StorageSyncManagementClient { get; set; }

        /// <summary>
        /// Gets or sets the storage sync resource manager.
        /// </summary>
        /// <value>The storage sync resource manager.</value>
        public IStorageSyncResourceManager StorageSyncResourceManager { get; set; }

        /// <summary>
        /// Gets or sets the authorization management client.
        /// </summary>
        /// <value>The authorization management client.</value>
        public IAuthorizationManagementClient AuthorizationManagementClient { get; set; }

        /// <summary>
        /// Gets or sets the resource management client.
        /// </summary>
        /// <value>The resource management client.</value>
        public IResourceManagementClient ResourceManagementClient { get; set; }

        /// <summary>
        /// Gets or sets the Microsoft Graph Client.
        /// </summary>
        /// <value>The Microsoft Graph client.</value>
        public MicrosoftGraphClient MicrosoftGraphClient { get; set; }

        /// <summary>
        /// Gets or sets the verbose logger.
        /// </summary>
        /// <value>The verbose logger.</value>
        public Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Gets or sets the error logger.
        /// </summary>
        /// <value>The error logger.</value>
        public Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncClientWrapper" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="microsoftGraphClient">The active directory client.</param>
        public StorageSyncClientWrapper(IAzureContext context, MicrosoftGraphClient microsoftGraphClient)
                : this(AzureSession.Instance.ClientFactory.CreateArmClient<StorageSyncManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                      AzureSession.Instance.ClientFactory.CreateArmClient<AuthorizationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                      AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
            MicrosoftGraphClient = microsoftGraphClient;

            if (AzureSession.Instance.TryGetComponent(StorageSyncConstants.StorageSyncResourceManager, out IStorageSyncResourceManager storageSyncResourceManager))
            {
                StorageSyncResourceManager = storageSyncResourceManager;
            }
            else
            {
                StorageSyncResourceManager = new StorageSyncResourceManager();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncClientWrapper" /> class.
        /// </summary>
        /// <param name="storageSyncManagementClient">The storage sync management client.</param>
        /// <param name="authorizationManagementClient">The authorization management client.</param>
        /// <param name="resourceManagementClient">The resource management client.</param>
        public StorageSyncClientWrapper(
            IStorageSyncManagementClient storageSyncManagementClient,
            AuthorizationManagementClient authorizationManagementClient,
            ResourceManagementClient resourceManagementClient)
        {
            StorageSyncManagementClient = storageSyncManagementClient;
            AuthorizationManagementClient = authorizationManagementClient;
            ResourceManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// The afs agent installer path
        /// </summary>
        private string _afsAgentInstallerPath;

        /// <summary>
        /// Gets the AFS Agent Installer Path
        /// </summary>
        /// <value>The afs agent installer path.</value>
        public string AfsAgentInstallerPath
        {
            get
            {
                if (_afsAgentInstallerPath == null)
                {
                    if (!StorageSyncResourceManager.TryGetAfsAgentInstallerPath(out string afsAgentInstallerPath))
                    {
                        ErrorLogger.Invoke($"AFS Agent Registrykey {StorageSyncConstants.AfsAgentInstallerPathRegistryKeyValueName} Value: {StorageSyncConstants.AfsAgentInstallerPathRegistryKeyValueName} not found in registry.");
                    }
                    else
                    {
                        _afsAgentInstallerPath = afsAgentInstallerPath;
                    }
                }
                return _afsAgentInstallerPath;
            }
        }

        /// <summary>
        /// Gets the current application identifier.
        /// </summary>
        /// <value>The current application identifier.</value>
        public Guid CurrentApplicationId
        {
            get
            {
                    switch (AzureRmProfileProvider.Instance?.Profile?.DefaultContext?.Environment?.Name)
                    {
                        case EnvironmentName.AzureUSGovernment:
                            return AzureUSGovernmentKailaniAppId;
                        default:
                            return AzureCloudKailaniAppId;
                    }
            }
        }

        /// <summary>
        /// The afs agent version
        /// </summary>
        private string _afsAgentVersion;

        /// <summary>
        /// Gets the AFS Agent Version
        /// </summary>
        /// <value>The afs agent version.</value>
        public string AfsAgentVersion
        {
            get
            {
                if (_afsAgentVersion == null)
                {
                    if (!StorageSyncResourceManager.TryGetAfsAgentVersion(out string afsAgentVersion))
                    {
                        ErrorLogger.Invoke($"AFS Agent Registrykey {StorageSyncConstants.AfsAgentVersionRegistryKeyValueName} Value: {StorageSyncConstants.AfsAgentVersionRegistryKeyValueName} not found in registry.");
                    }
                    else
                    {
                        _afsAgentVersion = afsAgentVersion;
                    }
                }
                return _afsAgentVersion;
            }
        }

        /// <summary>
        /// Ensures the service principal.
        /// </summary>
        /// <returns>PSADServicePrincipal.</returns>
        public MicrosoftGraphServicePrincipal GetServicePrincipalOrNull()
        {
            string applicationId = CurrentApplicationId.ToString();
            // TODO: Remove this call once Az Powershell supports MSGraphClient in Test framework.
            MicrosoftGraphServicePrincipal servicePrincipal = this.StorageSyncResourceManager.GetServicePrincipalOrNull();

            if (servicePrincipal == null)
            {
                var oDataQuery = new ODataQuery<MicrosoftGraphServicePrincipal>(sp => sp.AppId == applicationId);
                servicePrincipal = MicrosoftGraphClient.FilterServicePrincipals(oDataQuery).FirstOrDefault();
            }
            return servicePrincipal;
        }


        /// <summary>
        /// Ensures the role assignment.
        /// </summary>
        /// <param name="serverPrincipal">The server principal.</param>
        /// <param name="storageAccountSubscriptionId">The storage account subscription identifier.</param>
        /// <param name="storageAccountResourceId">The storage account resource identifier.</param>
        /// <returns>RoleAssignment.</returns>
        public RoleAssignment EnsureRoleAssignment(MicrosoftGraphServicePrincipal serverPrincipal, string storageAccountSubscriptionId, string storageAccountResourceId)
        {
            string currentSubscriptionId = AuthorizationManagementClient.SubscriptionId;
            bool hasMismatchSubscription = currentSubscriptionId != storageAccountSubscriptionId;

            try
            {
                if(hasMismatchSubscription)
                {
                    AuthorizationManagementClient.SubscriptionId = storageAccountSubscriptionId;
                }

                var resourceIdentifier = new ResourceIdentifier(storageAccountResourceId);
                string roleDefinitionScope = "/";
                RoleDefinition roleDefinition = AuthorizationManagementClient.RoleDefinitions.Get(roleDefinitionScope, BuiltInRoleDefinitionId);

                var serverPrincipalId = serverPrincipal.Id.ToString();
                var roleAssignments = AuthorizationManagementClient.RoleAssignments
                    .ListForResource(
                    resourceIdentifier.ResourceGroupName,
                    ResourceIdentifier.GetProviderFromResourceType(resourceIdentifier.ResourceType),
                    resourceIdentifier.ParentResource ?? "/",
                    ResourceIdentifier.GetTypeFromResourceType(resourceIdentifier.ResourceType),
                    resourceIdentifier.ResourceName,
                    odataQuery: new ODataQuery<RoleAssignmentFilter>(f => f.AssignedTo(serverPrincipalId)));
                var roleAssignmentScope = storageAccountResourceId;
                Guid roleAssignmentId = StorageSyncResourceManager.GetGuid();

                RoleAssignment roleAssignment = roleAssignments.FirstOrDefault();
                if (roleAssignment == null)
                {
                    VerboseLogger.Invoke(StorageSyncResources.CreateRoleAssignmentMessage);
                    var createParameters = new RoleAssignmentCreateParameters
                    {
                        Properties = new RoleAssignmentProperties
                        {
                            PrincipalId = serverPrincipalId,
                            RoleDefinitionId = AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromSubscriptionAndIdAsGuid(resourceIdentifier.Subscription, BuiltInRoleDefinitionId)
                        }
                    };

                    roleAssignment = AuthorizationManagementClient.RoleAssignments.Create(roleAssignmentScope, roleAssignmentId.ToString(), createParameters);
                    StorageSyncResourceManager.Wait();

                }

                return roleAssignment;
            }
            finally
            {
                if (hasMismatchSubscription)
                {
                    AuthorizationManagementClient.SubscriptionId = currentSubscriptionId;
                }
            }
        }

        /// <summary>
        /// This function will invoke the registration and continue operation with a success function call.
        /// </summary>
        /// <param name="currentSubscriptionId">Current SubscriptionId in Azure Context</param>
        /// <param name="resourceProviderNamespace">Resource provider name</param>
        /// <param name="subscription">subscription</param>
        /// <returns>true if request was successfully made. else false</returns>
        public bool TryRegisterProvider(string currentSubscriptionId, string resourceProviderNamespace, string subscription)
        {
            try
            {
                ResourceManagementClient.SubscriptionId = subscription;
                ResourceManagementClient.Providers.RegisterAsync(resourceProviderNamespace);
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
            finally
            {
                ResourceManagementClient.SubscriptionId = currentSubscriptionId;
            }
        }
    }
}