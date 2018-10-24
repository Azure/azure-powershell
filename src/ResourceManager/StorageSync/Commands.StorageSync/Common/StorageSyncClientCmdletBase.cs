using Microsoft.Azure.Commands.StorageSync.Common.Converters;
using Microsoft.Azure.Commands.StorageSync.Common.Exceptions;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Authorization.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    public interface IStorageSyncClientCmdlet
    {
        IStorageSyncClientWrapper StorageSyncClientWrapper { get; set;}
    }

    public abstract class StorageSyncClientCmdletBase : ActiveDirectoryBaseCmdlet, IStorageSyncClientCmdlet
    {
        public const string ProductionArmServiceHost = "https://management.azure.com";

        protected DateTime StartTime;

        private IStorageSyncClientWrapper storageSyncClientWrapper;

        public StorageSyncClientCmdletBase()
        {
            InitializeComponent();

        }

        protected virtual void InitializeComponent()
        {
        }

        private Guid? subscriptionId;
        public Guid? SubscriptionId
        {
            get
            {
                if (subscriptionId == null)
                {
                    if (TryGetDefaultContext(out IAzureContext context) && !string.IsNullOrEmpty(context.Subscription?.Id))
                    {
                        subscriptionId = context.Subscription.GetId();
                    }
                }
                return subscriptionId;
            }
        }

        public IStorageSyncClientWrapper StorageSyncClientWrapper
        {
            get
            {
                if (storageSyncClientWrapper == null)
                {
                    storageSyncClientWrapper = new StorageSyncClientWrapper(DefaultProfile.DefaultContext, ActiveDirectoryClient);
                }

                this.storageSyncClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                this.storageSyncClientWrapper.ErrorLogger = WriteErrorWithTimestamp;
                return storageSyncClientWrapper;
            }

            set { storageSyncClientWrapper = value; }
        }

        public override void ExecuteCmdlet()
        {
            /*
            // Test Get Service Principal
            string applicationId = "9469b9f5-6722-4481-a2b2-14ed560b706f";
            string subscriptionId = "1d16f9b3-bbe3-48d4-930a-27a74dca003b";

            Rest.Azure.OData.ODataQuery<ServicePrincipal> odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.AppId == applicationId);
            var serverPrincipals = ActiveDirectoryClient.FilterServicePrincipals(odataQuery);
            WriteObject(serverPrincipals.Count());

            var serverPrincipal = serverPrincipals.First();

            SecureString Password = Guid.NewGuid().ToString().ConvertToSecureString();

            // Create an application and get the applicationId
            var passwordCredential = new PSADPasswordCredential()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                KeyId = Guid.NewGuid(),
                Password = SecureStringExtensions.ConvertToString(Password)
            };


            //string DisplayName = Guid.NewGuid().ToString();
            //var identifierUri = "http://" + DisplayName;

            //CreatePSApplicationParameters appParameters = new CreatePSApplicationParameters
            //{
            //    DisplayName = DisplayName,
            //    IdentifierUris = new[] { identifierUri },
            //    HomePage = identifierUri,
            //    PasswordCredentials = new PSADPasswordCredential[]
            //        {
            //            passwordCredential
            //        }
            //};

            //var application = ActiveDirectoryClient.CreateApplication(appParameters);

            //CreatePSServicePrincipalParameters createParameters = new CreatePSServicePrincipalParameters
            //{
            //    ApplicationId = application.ApplicationId, //Guid.Parse(applicationId),
            //    AccountEnabled = true,
            //    PasswordCredentials = new PSADPasswordCredential[]
            //     {
            //        passwordCredential
            //     }
            //};

            //var servicePrincipal = ActiveDirectoryClient.CreateServicePrincipal(createParameters);

            string storageAccountResourceId = "/subscriptions/1d16f9b3-bbe3-48d4-930a-27a74dca003b/resourceGroups/sasdkwestcentralus/providers/Microsoft.Storage/storageAccounts/sasdkwestcentralus";
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(storageAccountResourceId);

            string BuiltInRoleDefinitionId = "c12c1c16-33a1-487b-954d-41c89c60f349";
            string scope = $@"subscriptions/{subscriptionId}";
            var roledefinition = this.StorageSyncClientWrapper.AuthorizationManagementClient.RoleDefinitions.Get("/", BuiltInRoleDefinitionId);

            var serverPrincipalId = serverPrincipal.Id.ToString();
            var odataQuery2 = new Rest.Azure.OData.ODataQuery<RoleAssignmentFilter>(f => f.AssignedTo(serverPrincipalId));

            var roleAssignments = this.StorageSyncClientWrapper.AuthorizationManagementClient.RoleAssignments
                .ListForResource(
                resourceIdentifier.ResourceGroupName,
                ResourceIdentifier.GetProviderFromResourceType(resourceIdentifier.ResourceType),
                resourceIdentifier.ParentResource ?? "/",
                ResourceIdentifier.GetTypeFromResourceType(resourceIdentifier.ResourceType),
                resourceIdentifier.ResourceName,
                odataQuery: odataQuery2);

            PSADServicePrincipal servicePrincipal = this.StorageSyncClientWrapper.EnsureServicePrincipal();

            if(servicePrincipal == null)
            {
                throw new PSArgumentException("Invalid Service Principal");
            }

            RoleAssignment roleAssignment = StorageSyncClientWrapper.EnsureRoleAssignment(servicePrincipal, storageAccountResourceId);
            if (roleAssignment == null)
            {
                throw new PSArgumentException("Invalid Role Assignment");
            }
            */
            StartTime = DateTime.Now;
            base.ExecuteCmdlet();
        }

        protected void ExecuteClientAction(Action action)
        {
            try
            {
                action();
            }
            catch (StorageSyncModels.StorageSyncErrorException ex)
            {
                try
                {
                    base.EndProcessing();
                }
                catch
                {
                    // Ignore exceptions during end processing
                }

                throw new StorageSyncCloudException(ex);
            }
            catch (Rest.Azure.CloudException ex)
            {
                try
                {
                    base.EndProcessing();
                }
                catch
                {
                    // Ignore exceptions during end processing
                }

                throw new StorageSyncCloudException(ex);
            }
            catch (Exception ex)
            {
                try
                {
                    base.EndProcessing();
                }
                catch
                {
                    // Ignore exceptions during end processing
                }

                throw new StorageSyncServerException(ex.Message, ex);
            }
        }

        protected void WriteObject(StorageSyncModels.StorageSyncService resource)
        {
            WriteObject(new StorageSyncServiceConverter().Convert(resource));
        }

        protected void WriteObject(IEnumerable<StorageSyncModels.StorageSyncService> resources)
        {
            WriteObject(resources.Select(new StorageSyncServiceConverter().Convert), true);
        }

        protected void WriteObject(StorageSyncModels.SyncGroup resource)
        {
            WriteObject(new SyncGroupConverter().Convert(resource));
        }

        protected void WriteObject(IEnumerable<StorageSyncModels.SyncGroup> resources)
        {
            WriteObject(resources.Select(new SyncGroupConverter().Convert), true);
        }

        protected void WriteObject(StorageSyncModels.RegisteredServer resource)
        {
            WriteObject(new RegisteredServerConverter().Convert(resource));
        }

        protected void WriteObject(IEnumerable<StorageSyncModels.RegisteredServer> resources)
        {
            WriteObject(resources.Select(new RegisteredServerConverter().Convert), true);
        }

        protected void WriteObject(StorageSyncModels.CloudEndpoint resource)
        {
            WriteObject(new CloudEndpointConverter().Convert(resource));
        }

        protected void WriteObject(IEnumerable<StorageSyncModels.CloudEndpoint> resources)
        {
            WriteObject(resources.Select(new CloudEndpointConverter().Convert), true);
        }

        protected void WriteObject(StorageSyncModels.ServerEndpoint resource)
        {
            WriteObject(new ServerEndpointConverter().Convert(resource));
        }

        protected void WriteObject(IEnumerable<StorageSyncModels.ServerEndpoint> resources)
        {
            WriteObject(resources.Select(new ServerEndpointConverter().Convert), true);
        }
    }
}
