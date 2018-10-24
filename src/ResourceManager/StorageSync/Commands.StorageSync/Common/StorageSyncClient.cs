using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Rest.Azure.OData;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    public interface IStorageSyncClientWrapper
    {
        IAzureContext AzureContext { get; set; }

        ActiveDirectoryClient ActiveDirectoryClient { get; set; }

        IStorageSyncManagementClient StorageSyncManagementClient { get; set; }

        IAuthorizationManagementClient AuthorizationManagementClient { get; set; }
        Action<string> VerboseLogger { get; set; }

        Action<string> ErrorLogger { get; set; }

        PSADServicePrincipal EnsureServicePrincipal();

        RoleAssignment EnsureRoleAssignment(PSADServicePrincipal serverPrincipal,string resourceId);

        string AfsAgentInstallerPath { get; }

        string AfsAgentVersion { get; }
    }

    public class StorageSyncClientWrapper : IStorageSyncClientWrapper
    {
        public static Guid KailaniAppId = new Guid("9469b9f5-6722-4481-a2b2-14ed560b706f");
        public const string BuiltInRoleDefinitionId = "c12c1c16-33a1-487b-954d-41c89c60f349";

        public IStorageSyncManagementClient StorageSyncManagementClient { get; set; }

        public IAuthorizationManagementClient AuthorizationManagementClient { get; set; }

        public ActiveDirectoryClient ActiveDirectoryClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public IAzureContext AzureContext { get; set; }

        public StorageSyncClientWrapper(IAzureContext context, ActiveDirectoryClient activeDirectoryClient)
                : this(
                      AzureSession.Instance.ClientFactory.CreateArmClient<StorageSyncManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                      AzureSession.Instance.ClientFactory.CreateArmClient<AuthorizationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
            AzureContext = context;
            ActiveDirectoryClient = activeDirectoryClient;
        }

        public StorageSyncClientWrapper(IStorageSyncManagementClient storageSyncManagementClient, AuthorizationManagementClient authorizationManagementClient)
        {
            StorageSyncManagementClient = storageSyncManagementClient;
            AuthorizationManagementClient = authorizationManagementClient;
        }

        private string _afsAgentInstallerPath;

        /// <summary>
        /// Gets the AFS Agent Installer Path
        /// </summary>
        /// <returns> Returns AFS Agent Installer Path</returns>
        public string AfsAgentInstallerPath
        {
            get
            {
                if (_afsAgentInstallerPath == null)
                {
                    if (!RegistryUtility.TryGetValue<string>(StorageSyncConstants.AfsAgentInstallerPathRegistryKeyValueName, StorageSyncConstants.AfsAgentRegistryKey, out _afsAgentInstallerPath, RegistryValueKind.String, RegistryValueOptions.None))
                    {
                        ErrorLogger.Invoke($"AFS Agent Registrykey {StorageSyncConstants.AfsAgentInstallerPathRegistryKeyValueName} Value: {StorageSyncConstants.AfsAgentInstallerPathRegistryKeyValueName} not found in registry.");
                    }
                }
                return _afsAgentInstallerPath;
            }
        }

        private string _afsAgentVersion;

        /// <summary>
        /// Gets the AFS Agent Version
        /// </summary>
        /// <returns> Returns AFS Agent Version</returns>
        public string AfsAgentVersion
        {
            get
            {
                if (_afsAgentVersion == null)
                {
                    if (!RegistryUtility.TryGetValue<string>(StorageSyncConstants.AfsAgentVersionRegistryKeyValueName, StorageSyncConstants.AfsAgentRegistryKey, out _afsAgentVersion, RegistryValueKind.String, RegistryValueOptions.None))
                    {
                        ErrorLogger.Invoke($"AFS Agent Registrykey {StorageSyncConstants.AfsAgentVersionRegistryKeyValueName} Value: {StorageSyncConstants.AfsAgentVersionRegistryKeyValueName} not found in registry.");
                    }
                }
                return _afsAgentVersion;
            }
        }

        public PSADServicePrincipal EnsureServicePrincipal()
        {
            if (KailaniAppId == Guid.Empty)
            {
                throw new PSArgumentException($"Invalid Argument {nameof(KailaniAppId)}", nameof(KailaniAppId));
            }

            string applicationId = KailaniAppId.ToString();

            var servicePrincipals = ActiveDirectoryClient.FilterServicePrincipals(new ODataQuery<ServicePrincipal>(s => s.AppId == applicationId));

            PSADServicePrincipal servicePrincipal = servicePrincipals.FirstOrDefault();

            if (servicePrincipal == null)
            {
                VerboseLogger.Invoke("Creating Service Principal...");

                SecureString Password = Guid.NewGuid().ToString().ConvertToSecureString();

                // Create an application and get the applicationId
                var passwordCredential = new PSADPasswordCredential()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    KeyId = Guid.NewGuid(),
                    Password = SecureStringExtensions.ConvertToString(Password)
                };

                var createParameters = new CreatePSServicePrincipalParameters
                {
                    ApplicationId = KailaniAppId,
                    AccountEnabled = true,
                    PasswordCredentials = new PSADPasswordCredential[]
                     {
                        passwordCredential
                     }
                };

                servicePrincipal = ActiveDirectoryClient.CreateServicePrincipal(createParameters);
                VerboseLogger.Invoke("Created Service Principal");
            }

            return servicePrincipal;
        }


        public RoleAssignment EnsureRoleAssignment(PSADServicePrincipal serverPrincipal, string resourceId)
        {
            var resourceIdentifier = new ResourceIdentifier(resourceId);

            if (string.IsNullOrEmpty(resourceIdentifier?.ResourceName))
            {
                throw new PSArgumentException($"Invalid resource ID format: {resourceId}");
            }

            string roleDefinitionScope = "/";
            RoleDefinition roleDefinition = AuthorizationManagementClient.RoleDefinitions.Get(roleDefinitionScope, BuiltInRoleDefinitionId);

            if (roleDefinition == null)
            {
                throw new PSArgumentException("Cannot get RoleDefinition");
            }

            var serverPrincipalId = serverPrincipal.Id.ToString();

            var roleAssignments = AuthorizationManagementClient.RoleAssignments
                .ListForResource(
                resourceIdentifier.ResourceGroupName,
                ResourceIdentifier.GetProviderFromResourceType(resourceIdentifier.ResourceType),
                resourceIdentifier.ParentResource ?? "/",
                ResourceIdentifier.GetTypeFromResourceType(resourceIdentifier.ResourceType),
                resourceIdentifier.ResourceName,
                odataQuery: new ODataQuery<RoleAssignmentFilter>(f => f.AssignedTo(serverPrincipalId)));
            RoleAssignment roleAssignment = roleAssignments.FirstOrDefault();

            var roleAssignmentScope = resourceId;
            string roleAssignmentId = Guid.NewGuid().ToString();

            if (roleAssignment == null)
            {
                VerboseLogger.Invoke("Creating Role Assignment...");

                var createParameters = new RoleAssignmentCreateParameters
                {
                    PrincipalId = serverPrincipalId,
                    RoleDefinitionId = AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromSubscriptionAndIdAsGuid(resourceIdentifier.Subscription, BuiltInRoleDefinitionId)
                };

                roleAssignment = AuthorizationManagementClient.RoleAssignments.Create(roleAssignmentScope, roleAssignmentId, createParameters);

                VerboseLogger.Invoke("Created Role Assignment");
            }

            return roleAssignment;
        }
    }
}