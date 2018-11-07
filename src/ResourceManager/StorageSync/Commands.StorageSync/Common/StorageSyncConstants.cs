using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    public class StorageSyncConstants
    {
        public const string ProductName = "StorageSync";
        public const string ProductPrefix = AzureRMConstants.AzureRMPrefix + ProductName;
        public const string ResourceProvider = "Microsoft" + "." + ProductName;
        public const string StorageAccountResourceProvider = "Microsoft.Storage";

        public const string ProvidersTypeName = "providers";
        public const string ResourceGroupTypeName = "resourceGroups";
        public const string SubscriptionTypeName = "subscriptions";
        public const string StorageSyncServiceTypeName = "storageSyncServices";
        public const string SyncGroupTypeName =  "syncGroups";
        public const string RegisteredServerTypeName = "registeredServers";
        public const string ServerEndpointTypeName = "serverEndpoints";
        public const string CloudEndpointTypeName = "cloudEndpoints";

        public const string StorageSyncServiceType = ResourceProvider + "/" + StorageSyncServiceTypeName;
        public const string SyncGroupType = StorageSyncServiceType + "/" + SyncGroupTypeName;
        public const string RegisteredServerType = StorageSyncServiceType + "/" + RegisteredServerTypeName;
        public const string ServerEndpointType = SyncGroupType + "/" + ServerEndpointTypeName;
        public const string CloudEndpointType = SyncGroupType + "/" + CloudEndpointTypeName;
        public const string StorageAccountType = "Microsoft.Storage/storageAccounts";

        public const string CloudTieringOn = "on";
        public const string CloudTieringOff = "off";

        public const string AfsAgentRegistryKey = @"SOFTWARE\Microsoft\Azure\StorageSync\Agent";

        public const string AfsAgentInstallerPathRegistryKeyValueName = "InstallDir";

        public const string AfsAgentVersionRegistryKeyValueName = "Version";

        public const string MonitoringAgentDirectoryName = @"MAAgent\Monitoring";

        public const string FileSyncSvcName = "FileSyncSvc";

    }

    public class StorageSyncAliases
    {
        public const string TagsAlias = "Tags";

        public const string ParentNameAlias = "ParentName";

        public const string StorageSyncServiceNameAlias = "StorageSyncServiceName";
        public const string SyncGroupNameAlias = "SyncGroupName";
        public const string RegisteredServerNameAlias = "RegisteredServerName";
        public const string ServerNameAlias = "ServerName";
        public const string CloudEndpointNameAlias = "CloudEndpointName";
        public const string ServerEndpointNameAlias = "ServerEndpointName";

        public const string StorageSyncServiceAlias = "StorageSyncService";
        public const string SyncGroupAlias = "SyncGroup";
        public const string RegisteredServerAlias = "RegisteredServer";
        public const string ServerAlias = "Server";
        public const string CloudEndpointAlias = "CloudEndpoint";
        public const string ServerEndpointAlias = "ServerEndpoint";

        public const string StorageSyncServiceIdAlias = "StorageSyncServiceId";
        public const string SyncGroupIdAlias = "SyncGroupId";
        public const string RegisteredServerIdAlias = "RegisteredServerId";
        public const string ServerIdAlias = "ServerId";
        public const string CloudEndpointIdAlias = "CloudEndpointId";
        public const string ServerEndpointIdAlias = "ServerEndpointId";

    }

    public class StorageSyncParameterSets
    {
        public const string ResourceIdParameterSet = "ResourceIdParameterSet";
        public const string StringParameterSet = "StringParameterSet";
        public const string ObjectParameterSet = "ObjectParameterSet";
        public const string ParentStringParameterSet = "ParentStringParameterSet";
        public const string InputObjectParameterSet = "InputObjectParameterSet";
        public const string DefaultParameterSet = "DefaultParameterSet";
    }

    public class StorageSyncNouns
    {
        public const string NounAzureRmStorageSyncService = StorageSyncConstants.ProductPrefix + "Service";
        public const string NounAzureRmStorageSyncGroup = StorageSyncConstants.ProductPrefix + "Group";
        public const string NounAzureRmStorageSyncServer = StorageSyncConstants.ProductPrefix + "Server";
        public const string NounAzureRmStorageSyncCloudEndpoint = StorageSyncConstants.ProductPrefix + "CloudEndpoint";
        public const string NounAzureRmStorageSyncServerEndpoint = StorageSyncConstants.ProductPrefix + "ServerEndpoint";
        public const string NounAzureRmStorageSyncServerConfiguration = StorageSyncConstants.ProductPrefix + "ServerConfiguration";
        public const string NounAzureRmStorageSyncFileRecall = StorageSyncConstants.ProductPrefix + "FileRecall";
        public const string NounAzureRmStorageSyncServerCertificate = NounAzureRmStorageSyncServer + "Certificate";

    }

    public class StorageSyncCmdletNames
    {
        public const string NewAzureRmStorageSyncService = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string NewAzureRmStorageSyncGroup = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        public const string NewAzureRmStorageSyncServer = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        public const string NewAzureRmStorageSyncCloudEndpoint = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        public const string NewAzureRmStorageSyncServerEndpoint = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;

        public const string InvokeAzureRmStorageSyncFileRecall = VerbsLifecycle.Invoke + "-" + StorageSyncNouns.NounAzureRmStorageSyncFileRecall;

        public const string GetAzureRmStorageSyncService = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string GetAzureRmStorageSyncGroup = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        public const string GetAzureRmStorageSyncServer = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        public const string GetAzureRmStorageSyncCloudEndpoint = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        public const string GetAzureRmStorageSyncServerEndpoint = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;

        public const string RemoveAzureRmStorageSyncService = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string RemoveAzureRmStorageSyncGroup = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        public const string RemoveAzureRmStorageSyncCloudEndpoint = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        public const string RemoveAzureRmStorageSyncServerEndpoint = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;

        public const string SetAzureRmStorageSyncService = VerbsCommon.Set + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string SetAzureRmStorageSyncServerEndpoint = VerbsCommon.Set + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;

        public const string UnregisterAzureRmStorageSyncServer = VerbsLifecycle.Unregister + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        public const string RegisterAzureRmStorageSyncServer = VerbsLifecycle.Register + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;

    }

    public class HelpMessages
    {
        public const string AsJobParameter = "Run cmdlet in the background";
        public const string StorageSyncServiceObjectParameter = "StorageSyncService Object, normally passed through the parameter.";
        public const string StorageSyncServiceInputObjectParameter = "StorageSyncService Input Object, normally passed through the pipeline.";
        public const string StorageSyncServiceResourceIdParameter = "StorageSyncService Resource Id";
        public const string StorageSyncServiceParentResourceIdParameter = "StorageSyncService Parent Resource Id";
        public const string StorageSyncServiceNameParameter = "Name of the StorageSyncService.";
        public const string StorageSyncServiceLocationParameter = "Storage Sync Service Location.";
        public const string StorageSyncServiceTagsParameter = "Storage Sync Service Tags.";
        public const string StorageSyncServiceForceParameter = "Force to Delete the Storage Sync Service";
        
        public const string SyncGroupObjectParameter = "SyncGroup Object, normally passed through the parameter.";
        public const string SyncGroupInputObjectParameter = "SyncGroup Input Object";
        public const string SyncGroupResourceIdParameter = "SyncGroup Resource Id";
        public const string SyncGroupParentResourceIdParameter = "SyncGroup Parent Resource Id";
        public const string SyncGroupNameParameter = "Name of the SyncGroup.";
        public const string SyncGroupForceParameter = "Force to Delete the Sync Group";

        public const string RegisteredServerObjectParameter = "RegisteredServer Object, normally passed through the parameter.";
        public const string RegisteredServerInputObjectParameter = "RegisteredServer Input Object, normally passed through the pipeline.";
        public const string RegisteredServerResourceIdParameter = "RegisteredServer Resource Id";
        public const string RegisteredServerNameParameter = "Name of the RegisteredServer.";
        public const string RegisteredServerForceParameter = "Force to Delete the RegisteredServer";

        public const string CloudEndpointObjectParameter = "CloudEndpoint Object, normally passed through the parameter.";
        public const string CloudEndpointInputObjectParameter = "CloudEndpoint Input Object, normally passed through the pipeline.";
        public const string CloudEndpointResourceIdParameter = "CloudEndpoint Resource Id";
        public const string CloudEndpointNameParameter = "Name of the CloudEndpoint.";
        public const string CloudEndpointForceParameter = "Force to Delete the CloudEndpoint";

        public const string StorageAccountShareNameParameter = "Storage Account Share Name (Azure File Share Name)";
        public const string StorageAccountTenantIdParameter = "Storage Account Tenant Id (Company Directory Id)";
        public const string StorageAccountResourceIdParameter = "Storage Account Resource Id";

        public const string ServerEndpointObjectParameter = "ServerEndpoint Object, normally passed through the parameter.";
        public const string ServerEndpointInputObjectParameter = "ServerEndpoint Input Object, normally passed through the pipeline.";
        public const string ServerEndpointResourceIdParameter = "ServerEndpoint Resource Id";
        public const string ServerEndpointNameParameter = "Name of the ServerEndpoint.";
        public const string ServerEndpointForceParameter = "Force to Delete the ServerEndpoint";

        public const string ServerLocalPathParameter = "Server Local Path Parameter";
        public const string CloudTieringParameter = "Cloud Tiering Parameter";
        public const string CloudSeededDataParameter = "Cloud Seeded Data Parameter";
        public const string CloudSeededDataFileShareUriParameter = "Cloud Seeded Data File Share Uri Parameter";
        public const string TierFilesOlderThanDaysParameter = "Tier Files Older Than Days Parameter";
        public const string VolumeFreeSpacePercentParameter = "Volume Free Space Percent Parameter";
        public const string PatternParameter = "Pattern of the file name";
        public const string RecallPathParameter = "Recall path which need to be recalled.";

        public const string ResourceGroupNameParameter = "Resource Group Name.";
    }
}
