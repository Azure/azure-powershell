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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

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

        private bool? isRunningInTest;
        public bool IsRunningInTest
        {
            get
            {
                if (!isRunningInTest.HasValue)
                {
                    string mode = System.Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
                    isRunningInTest = "Playback".Equals(mode, StringComparison.OrdinalIgnoreCase);
                }
                return isRunningInTest.Value;
            }
        }

        private Guid? subscriptionId;
        public Guid? SubscriptionId
        {
            get
            {
                if (subscriptionId == null)
                {
                    IAzureContext context = null;
                    bool hasAzureContext = TryGetDefaultContext(out context);
                    if (hasAzureContext && !string.IsNullOrEmpty(context.Subscription?.Id))
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
