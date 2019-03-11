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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.StorageSync.Common.Converters;
using Microsoft.Azure.Commands.StorageSync.Common.Exceptions;
using Microsoft.Azure.Commands.StorageSync.Interfaces;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// Interface IStorageSyncClientCmdlet
    /// </summary>
    public interface IStorageSyncClientCmdlet
    {
        /// <summary>
        /// Gets or sets the storage sync client wrapper.
        /// </summary>
        /// <value>The storage sync client wrapper.</value>
        IStorageSyncClientWrapper StorageSyncClientWrapper { get; set;}
    }

    /// <summary>
    /// Class StorageSyncClientCmdletBase.
    /// Implements the <see cref="Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory.ActiveDirectoryBaseCmdlet" />
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.IStorageSyncClientCmdlet" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory.ActiveDirectoryBaseCmdlet" />
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.IStorageSyncClientCmdlet" />
    public abstract class StorageSyncClientCmdletBase : ActiveDirectoryBaseCmdlet, IStorageSyncClientCmdlet
    {
        /// <summary>
        /// The production arm service host
        /// </summary>
        public const string ProductionArmServiceHost = "https://management.azure.com";

        /// <summary>
        /// The start time
        /// </summary>
        protected DateTime StartTime;

        /// <summary>
        /// The storage sync client wrapper
        /// </summary>
        private IStorageSyncClientWrapper storageSyncClientWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncClientCmdletBase" /> class.
        /// </summary>
        public StorageSyncClientCmdletBase()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        protected virtual void InitializeComponent()
        {
            DefaultProfile.DefaultContext.Tenant.Id = StorageSyncClientWrapper.StorageSyncResourceManager.GetTenantId() ?? DefaultProfile.DefaultContext.Tenant.Id;
        }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        protected virtual string Target { get; set; }

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected virtual string ActionMessage { get; set; }

        /// <summary>
        /// Gets the subscription identifier.
        /// </summary>
        /// <value>The subscription identifier.</value>
        public Guid SubscriptionId => DefaultProfile.DefaultContext.Subscription.GetId();

        /// <summary>
        /// Gets or sets the storage sync client wrapper.
        /// </summary>
        /// <value>The storage sync client wrapper.</value>
        public IStorageSyncClientWrapper StorageSyncClientWrapper
        {
            get
            {
                if (storageSyncClientWrapper == null)
                {
                    storageSyncClientWrapper = new StorageSyncClientWrapper(DefaultProfile.DefaultContext, ActiveDirectoryClient);
                }

                storageSyncClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                storageSyncClientWrapper.ErrorLogger = WriteErrorWithTimestamp;
                return storageSyncClientWrapper;
            }

            set { storageSyncClientWrapper = value; }
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            StartTime = DateTime.Now;
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Executes the client action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <exception cref="Microsoft.Azure.Commands.StorageSync.Common.Exceptions.StorageSyncCloudException">
        /// </exception>
        protected void ExecuteClientAction(Action action)
        {
            try
            {
                action();
            }
            catch (StorageSyncModels.StorageSyncErrorException ex)
            {
                throw new StorageSyncCloudException(ex);
            }
            catch (Rest.Azure.CloudException ex)
            {
                throw new StorageSyncCloudException(ex);
            }
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resource">The resource.</param>
        protected void WriteObject(StorageSyncModels.StorageSyncService resource)
        {
            WriteObject(new StorageSyncServiceConverter().Convert(resource));
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resources">The resources.</param>
        protected void WriteObject(IEnumerable<StorageSyncModels.StorageSyncService> resources)
        {
            WriteObject(resources.Select(new StorageSyncServiceConverter().Convert), true);
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resource">The resource.</param>
        protected void WriteObject(StorageSyncModels.SyncGroup resource)
        {
            WriteObject(new SyncGroupConverter().Convert(resource));
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resources">The resources.</param>
        protected void WriteObject(IEnumerable<StorageSyncModels.SyncGroup> resources)
        {
            WriteObject(resources.Select(new SyncGroupConverter().Convert), true);
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resource">The resource.</param>
        protected void WriteObject(StorageSyncModels.RegisteredServer resource)
        {
            WriteObject(new RegisteredServerConverter().Convert(resource));
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resources">The resources.</param>
        protected void WriteObject(IEnumerable<StorageSyncModels.RegisteredServer> resources)
        {
            WriteObject(resources.Select(new RegisteredServerConverter().Convert), true);
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resource">The resource.</param>
        protected void WriteObject(StorageSyncModels.CloudEndpoint resource)
        {
            WriteObject(new CloudEndpointConverter().Convert(resource));
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resources">The resources.</param>
        protected void WriteObject(IEnumerable<StorageSyncModels.CloudEndpoint> resources)
        {
            WriteObject(resources.Select(new CloudEndpointConverter().Convert), true);
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resource">The resource.</param>
        protected void WriteObject(StorageSyncModels.ServerEndpoint resource)
        {
            WriteObject(new ServerEndpointConverter().Convert(resource));
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="resources">The resources.</param>
        protected void WriteObject(IEnumerable<StorageSyncModels.ServerEndpoint> resources)
        {
            WriteObject(resources.Select(new ServerEndpointConverter().Convert), true);
        }
    }
}
