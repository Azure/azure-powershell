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

using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Interface IConverter
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>System.Object.</returns>
        object Convert(object resource);
    }

    /// <summary>
    /// Interface IConverter
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter" />
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter" />
    public interface IConverter<P, T> : IConverter
        where P : class, new()
        where T : class, new()

        //where P : PSResourceBase
        //where T : StorageSyncModels.Resource
    {
        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>P.</returns>
        P Convert(T resource);

        /// <summary>
        /// Converts the specified ps resource.
        /// </summary>
        /// <param name="psResource">The ps resource.</param>
        /// <returns>T.</returns>
        T Convert(P psResource);

    }

    /// <summary>
    /// Class ConverterBase.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter{P, T}" />
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter{P, T}" />
    public abstract class ConverterBase<P, T> : IConverter<P, T>
        //where P : PSResourceBase, new()
        //where T : StorageSyncModels.Resource, new()
        where P : class, new()
        where T : class, new()
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterBase{P, T}"/> class.
        /// </summary>
        public ConverterBase()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>T.</returns>
        protected abstract T Transform(P source);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>P.</returns>
        protected abstract P Transform(T source);

        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>P.</returns>
        public P Convert(T resource)
        {
            if (resource != null)
            {
                return Transform(resource);
            }

            return default(P);

        }

        /// <summary>
        /// Converts the specified ps resource.
        /// </summary>
        /// <param name="psResource">The ps resource.</param>
        /// <returns>T.</returns>
        public T Convert(P psResource)
        {
            if (psResource != null)
            {
                return Transform(psResource);
            }

            return default(T);

        }

        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>System.Object.</returns>
        public object Convert(object resource)
        {
            if(resource is P)
            {
                return Convert(resource as P);
            }

            return Convert(resource as T);
        }
    }

    /// <summary>
    /// Class StorageSyncServiceConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSStorageSyncService, Microsoft.Azure.Management.StorageSync.Models.StorageSyncService}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSStorageSyncService, Microsoft.Azure.Management.StorageSync.Models.StorageSyncService}" />
    public class StorageSyncServiceConverter : ConverterBase<PSStorageSyncService, StorageSyncModels.StorageSyncService>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncServiceConverter"/> class.
        /// </summary>
        public StorageSyncServiceConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.StorageSyncService.</returns>
        protected override StorageSyncModels.StorageSyncService Transform(PSStorageSyncService source) => new StorageSyncModels.StorageSyncService(source.Location, source.ResourceId, source.StorageSyncServiceName, StorageSyncConstants.StorageSyncServiceType, source.Tags);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSStorageSyncService.</returns>
        protected override PSStorageSyncService Transform(StorageSyncModels.StorageSyncService source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSStorageSyncService()
            {
                ResourceId = source.Id,
                StorageSyncServiceName = source.Name,
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Location = source.Location,
                Tags = source.Tags,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.StorageSyncServiceType
            };
        }
    }

    /// <summary>
    /// Class SyncGroupConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncGroup, Microsoft.Azure.Management.StorageSync.Models.SyncGroup}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncGroup, Microsoft.Azure.Management.StorageSync.Models.SyncGroup}" />
    public class SyncGroupConverter : ConverterBase<PSSyncGroup, StorageSyncModels.SyncGroup>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncGroupConverter"/> class.
        /// </summary>
        public SyncGroupConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.SyncGroup.</returns>
        protected override StorageSyncModels.SyncGroup Transform(PSSyncGroup source) => new StorageSyncModels.SyncGroup(source.ResourceId,source.SyncGroupName,source.Type);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSyncGroup.</returns>
        protected override PSSyncGroup Transform(StorageSyncModels.SyncGroup source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSSyncGroup()
            {
                ResourceId = source.Id,
                SyncGroupName = source.Name,
                StorageSyncServiceName= resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName,0),
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.SyncGroupType,
                UniqueId = source.UniqueId,
                SyncGroupStatus = source.SyncGroupStatus
            };
        }
    }

    /// <summary>
    /// Class RegisteredServerConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSRegisteredServer, Microsoft.Azure.Management.StorageSync.Models.RegisteredServer}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSRegisteredServer, Microsoft.Azure.Management.StorageSync.Models.RegisteredServer}" />
    public class RegisteredServerConverter : ConverterBase<PSRegisteredServer, StorageSyncModels.RegisteredServer>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredServerConverter"/> class.
        /// </summary>
        public RegisteredServerConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.RegisteredServer.</returns>
        protected override StorageSyncModels.RegisteredServer Transform(PSRegisteredServer source)
        {
            return new StorageSyncModels.RegisteredServer(source.ResourceId,
                source.ServerName,
                StorageSyncConstants.RegisteredServerType,
                source.ServerCertificate,
                source.AgentVersion,
                source.ServerOSVersion,
                source.ServerManagementErrorCode,
                source.LastHeartBeat,
                source.ProvisioningState,
                source.ServerRole,
                source.ClusterId,
                source.ClusterName,
                source.ServerId,
                source.StorageSyncServiceUid,
                source.LastWorkflowId,
                source.LastOperationName,
                source.DiscoveryEndpointUri,
                source.ResourceLocation,
                source.ServiceLocation,
                source.FriendlyName,
                source.ManagementEndpointUri,
                source.MonitoringConfiguration);
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSRegisteredServer.</returns>
        protected override PSRegisteredServer Transform(StorageSyncModels.RegisteredServer source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSRegisteredServer()
            {
                ResourceId = source.Id,
                StorageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0),
                ServerName = source.Name,
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.RegisteredServerType,
                AgentVersion = source.AgentVersion,
                ClusterId = source.ClusterId?.Trim('"'),
                ProvisioningState = source.ProvisioningState,
                ClusterName = source.ClusterName,
                DiscoveryEndpointUri = source.DiscoveryEndpointUri?.Trim('"'),
                FriendlyName = source.FriendlyName,
                LastHeartBeat = source.LastHeartBeat?.Trim('"'),
                LastOperationName = source.LastOperationName,
                LastWorkflowId = source.LastWorkflowId?.Trim('"'),
                ManagementEndpointUri = source.ManagementEndpointUri?.Trim('"'),
                ResourceLocation = source.ResourceLocation,
                ServerCertificate = source.ServerCertificate?.Trim('"'),
                ServerId = source.ServerId?.Trim('"'),
                ServerManagementErrorCode = source.ServerManagementErrorCode,
                ServerOSVersion = source.ServerOSVersion,
                ServerRole = source.ServerRole,
                ServiceLocation = source.ServiceLocation,
                StorageSyncServiceUid = source.StorageSyncServiceUid?.Trim('"'),
                MonitoringConfiguration = source.MonitoringConfiguration
            };
        }
    }

    /// <summary>
    /// Class CloudEndpointConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint, Microsoft.Azure.Management.StorageSync.Models.CloudEndpoint}" />
    public class CloudEndpointConverter : ConverterBase<PSCloudEndpoint, StorageSyncModels.CloudEndpoint>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEndpointConverter"/> class.
        /// </summary>
        public CloudEndpointConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudEndpoint.</returns>
        protected override StorageSyncModels.CloudEndpoint Transform(PSCloudEndpoint source) => new StorageSyncModels.CloudEndpoint(source.ResourceId, source.CloudEndpointName, source.Type, source.StorageAccountResourceId, source.StorageAccountShareName, source.StorageAccountTenantId, friendlyName: source.FriendlyName);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudEndpoint.</returns>
        protected override PSCloudEndpoint Transform(StorageSyncModels.CloudEndpoint source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSCloudEndpoint()
            {
                ResourceId = source.Id,
                CloudEndpointName = source.Name,
                SyncGroupName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0),
                StorageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1),
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.CloudEndpointType,
                FriendlyName=source.FriendlyName,
                StorageAccountResourceId=source.StorageAccountResourceId,
                StorageAccountShareName =source.StorageAccountShareName,
                StorageAccountTenantId = source.StorageAccountTenantId?.Trim('"'),
                BackupEnabled = System.Convert.ToBoolean(source.BackupEnabled),
                LastWorkflowId = source.LastWorkflowId,
                LastOperationName = source.LastOperationName,
                PartnershipId = source.PartnershipId,
                ProvisioningState =source.ProvisioningState,
            };
        }
    }

    /// <summary>
    /// Class ServerEndpointConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSServerEndpoint, Microsoft.Azure.Management.StorageSync.Models.ServerEndpoint}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSServerEndpoint, Microsoft.Azure.Management.StorageSync.Models.ServerEndpoint}" />
    public class ServerEndpointConverter : ConverterBase<PSServerEndpoint, StorageSyncModels.ServerEndpoint>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEndpointConverter"/> class.
        /// </summary>
        public ServerEndpointConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpoint.</returns>
        protected override StorageSyncModels.ServerEndpoint Transform(PSServerEndpoint source)
        {
            return new StorageSyncModels.ServerEndpoint(source.ResourceId,
                source.ServerEndpointName,
                source.Type,
                source.ServerLocalPath, 
                source.CloudTiering,
                source.VolumeFreeSpacePercent,
                source.TierFilesOlderThanDays,
                source.FriendlyName, 
                source.ServerResourceId, 
                source.ProvisioningState, 
                source.LastWorkflowId, 
                source.LastOperationName, 
                new StorageSyncModels.ServerEndpointHealth(
                    source.SyncStatus?.DownloadHealth,
                    source.SyncStatus?.UploadHealth,
                    source.SyncStatus?.CombinedHealth,
                    source.SyncStatus?.LastUpdatedTimestamp,
                    null));
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpoint.</returns>
        protected override PSServerEndpoint Transform(StorageSyncModels.ServerEndpoint source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSServerEndpoint()
            {
                ResourceId = source.Id,
                SyncGroupName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0),
                StorageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1),
                ServerEndpointName = source.Name,
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.ServerEndpointType,
                ServerLocalPath = source.ServerLocalPath,
                ServerResourceId = source.ServerResourceId,
                ProvisioningState = source.ProvisioningState,
                SyncStatus = new ServerEndpointHealthConvertor().Convert(source.SyncStatus),
                FriendlyName = source.FriendlyName,
                LastOperationName = source.LastOperationName,
                LastWorkflowId = source.LastWorkflowId,
                CloudTiering = source.CloudTiering,
                VolumeFreeSpacePercent = source.VolumeFreeSpacePercent,
                TierFilesOlderThanDays = source.TierFilesOlderThanDays
            };
        }
    }

    /// <summary>
    /// Class ServerEndpointHealthConvertor.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSServerEndpointHealth, Microsoft.Azure.Management.StorageSync.Models.ServerEndpointHealth}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSServerEndpointHealth, Microsoft.Azure.Management.StorageSync.Models.ServerEndpointHealth}" />
    public class ServerEndpointHealthConvertor : ConverterBase<PSServerEndpointHealth, StorageSyncModels.ServerEndpointHealth>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointHealth.</returns>
        protected override StorageSyncModels.ServerEndpointHealth Transform(PSServerEndpointHealth source) => new StorageSyncModels.ServerEndpointHealth(
            source.DownloadHealth,
            source.UploadHealth,
            source.CombinedHealth,
            source.LastUpdatedTimestamp,
            new SyncSessionStatusConvertor().Convert(source.UploadStatus),
            new SyncSessionStatusConvertor().Convert(source.DownloadStatus),
            new SyncProgressStatusConvertor().Convert(source.CurrentProgress),
            source.OfflineDataTransferStatus);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointHealth.</returns>
        protected override PSServerEndpointHealth Transform(StorageSyncModels.ServerEndpointHealth source)
        {
            return new PSServerEndpointHealth()
            {
                DownloadHealth = source.DownloadHealth,
                UploadHealth = source.UploadHealth,
                CombinedHealth = source.CombinedHealth,
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                UploadStatus = new SyncSessionStatusConvertor().Convert(source.UploadStatus),
                DownloadStatus = new SyncSessionStatusConvertor().Convert(source.DownloadStatus),
                CurrentProgress = new SyncProgressStatusConvertor().Convert(source.CurrentProgress),
                OfflineDataTransferStatus = source.OfflineDataTransferStatus
            };
        }
    }

    /// <summary>
    /// Class SyncSessionStatusConvertor.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncSessionStatus, Microsoft.Azure.Management.StorageSync.Models.SyncSessionStatus}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncSessionStatus, Microsoft.Azure.Management.StorageSync.Models.SyncSessionStatus}" />
    public class SyncSessionStatusConvertor : ConverterBase<PSSyncSessionStatus, StorageSyncModels.SyncSessionStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.SyncSessionStatus.</returns>
        protected override StorageSyncModels.SyncSessionStatus Transform(PSSyncSessionStatus source) => new StorageSyncModels.SyncSessionStatus(
            source.LastSyncResult, source.LastSyncTimestamp, source.LastSyncSuccessTimestamp, source.LastSyncPerItemErrorCount);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSyncSessionStatus.</returns>
        protected override PSSyncSessionStatus Transform(StorageSyncModels.SyncSessionStatus source)
        {
            return new PSSyncSessionStatus()
            {
                LastSyncResult = source.LastSyncResult,
                LastSyncTimestamp = source.LastSyncTimestamp,
                LastSyncSuccessTimestamp = source.LastSyncSuccessTimestamp,
                LastSyncPerItemErrorCount = source.LastSyncPerItemErrorCount
            };
        }
    }

    /// <summary>
    /// Class SyncProgressStatusConvertor.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncProgressStatus, Microsoft.Azure.Management.StorageSync.Models.SyncProgressStatus}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncProgressStatus, Microsoft.Azure.Management.StorageSync.Models.SyncProgressStatus}" />
    public class SyncProgressStatusConvertor : ConverterBase<PSSyncProgressStatus, StorageSyncModels.SyncProgressStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.SyncProgressStatus.</returns>
        protected override StorageSyncModels.SyncProgressStatus Transform(PSSyncProgressStatus source) => new StorageSyncModels.SyncProgressStatus(
            source.ProgressTimestamp, source.SyncDirection, source.PerItemErrorCount, source.AppliedItemCount, source.TotalItemCount, source.AppliedBytes,source.TotalBytes);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSyncProgressStatus.</returns>
        protected override PSSyncProgressStatus Transform(StorageSyncModels.SyncProgressStatus source)
        {
            return new PSSyncProgressStatus()
            {
                AppliedBytes = source.AppliedBytes,
                AppliedItemCount=source.AppliedItemCount,
                PerItemErrorCount=source.PerItemErrorCount,
                ProgressTimestamp = source.ProgressTimestamp,
                SyncDirection = source.SyncDirection,
                TotalBytes = source.TotalBytes,
                TotalItemCount=source.TotalItemCount
            };
        }
    }
}
