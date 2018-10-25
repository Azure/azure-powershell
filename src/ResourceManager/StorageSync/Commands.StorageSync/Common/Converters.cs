using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    public interface IConverter
    {
        object Convert(object resource);
    }

    public interface IConverter<P, T> : IConverter
        where P : PSResourceBase
        where T : StorageSyncModels.Resource
    {
        P Convert(T resource);

        T Convert(P psResource);

    }

    public abstract class ConverterBase<P, T> : IConverter<P, T>
        where P : PSResourceBase, new()
        where T : StorageSyncModels.Resource, new()
    {

        public ConverterBase()
        {
        }

        protected abstract T Transform(P source);

        protected abstract P Transform(T source);

        public P Convert(T resource)
        {
            if (resource != null)
            {
                return Transform(resource);
            }

            return default(P);

        }

        public T Convert(P psResource)
        {
            if (psResource != null)
            {
                return Transform(psResource);
            }

            return default(T);

        }

        public object Convert(object resource)
        {
            if(resource is P)
            {
                return Convert(resource as P);
            }

            return Convert(resource as T);
        }
    }

    public class StorageSyncServiceConverter : ConverterBase<PSStorageSyncService, StorageSyncModels.StorageSyncService>
    {

        public StorageSyncServiceConverter()
        {
        }

        protected override StorageSyncModels.StorageSyncService Transform(PSStorageSyncService source) => new StorageSyncModels.StorageSyncService(source.Location, source.ResourceId, source.StorageSyncServiceName, StorageSyncConstants.StorageSyncServiceType, source.Tags);

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

    public class SyncGroupConverter : ConverterBase<PSSyncGroup, StorageSyncModels.SyncGroup>
    {

        public SyncGroupConverter()
        {
        }

        protected override StorageSyncModels.SyncGroup Transform(PSSyncGroup source) => new StorageSyncModels.SyncGroup(source.ResourceId,source.SyncGroupName,source.Type);

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

    public class RegisteredServerConverter : ConverterBase<PSRegisteredServer, StorageSyncModels.RegisteredServer>
    {

        public RegisteredServerConverter()
        {
        }

        protected override StorageSyncModels.RegisteredServer Transform(PSRegisteredServer source)
        {
            return new StorageSyncModels.RegisteredServer(source.ResourceId,
                source.ServerName,
                StorageSyncConstants.RegisteredServerType,
                source.ServerCertificate,
                source.AgentVersion,
                source.ServerOSVersion,
                source.ServerManagementtErrorCode,
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
                source.ManagementEndpointUri);
        }

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
                ServerManagementtErrorCode = source.ServerManagementtErrorCode,
                ServerOSVersion = source.ServerOSVersion,
                ServerRole = source.ServerRole,
                ServiceLocation = source.ServiceLocation,
                StorageSyncServiceUid = source.StorageSyncServiceUid?.Trim('"')
            };
        }
    }

    public class CloudEndpointConverter : ConverterBase<PSCloudEndpoint, StorageSyncModels.CloudEndpoint>
    {

        public CloudEndpointConverter()
        {
        }

        protected override StorageSyncModels.CloudEndpoint Transform(PSCloudEndpoint source) => new StorageSyncModels.CloudEndpoint(source.ResourceId, source.CloudEndpointName, source.Type, source.StorageAccountResourceId, source.StorageAccountShareName, source.StorageAccountTenantId, friendlyName: source.FriendlyName);

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
                BackupEnabled = source.BackupEnabled,
                LastWorkflowId = source.LastWorkflowId,
                LastOperationName = source.LastOperationName,
                PartnershipId = source.PartnershipId,
                ProvisioningState =source.ProvisioningState,
            };
        }
    }

    public class ServerEndpointConverter : ConverterBase<PSServerEndpoint, StorageSyncModels.ServerEndpoint>
    {

        public ServerEndpointConverter()
        {
        }

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
                source.SyncStatus);
        }

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
                SyncStatus = source.SyncStatus,
                FriendlyName = source.FriendlyName,
                LastOperationName = source.LastOperationName,
                LastWorkflowId = source.LastWorkflowId,
                CloudTiering = source.CloudTiering,
                VolumeFreeSpacePercent = source.VolumeFreeSpacePercent,
                TierFilesOlderThanDays = source.TierFilesOlderThanDays
            };
        }
    }
}
