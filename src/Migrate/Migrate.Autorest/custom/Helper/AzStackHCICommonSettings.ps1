$AzStackHCIInstanceTypes = @{
    HyperVToAzStackHCI = "HyperVToAzStackHCI";
    VMwareToAzStackHCI = "VMwareToAzStackHCI";
}

# Fabric instances
$FabricInstanceTypes = @{
    HyperVInstance     = "HyperVMigrate";
    VMwareInstance     = "VMwareMigrate";
    AzStackHCIInstance = "AzStackHCI";
}

$ReplicationDetails = @{
    PolicyDetails               = @{
        DefaultCrashConsistentFrequencyInMinutes = 60;
        DefaultAppConsistentFrequencyInMinutes   = 240;
        DefaultRecoveryPointHistoryInMinutes     = 4320;
    };
    ReplicationPollDelaySeconds = 180;
    ReplicationTimeoutSeconds   = 1800;
}

$ApiVersions = @{
    ReplicationPolicy    = "2021-02-16-preview";
    ReplicationFabric    = "2021-02-16-preview";
    ReplicationExtension = "2021-02-16-preview";
    StorageAccount       = "2021-09-01";
    HyperVSites          = "2020-01-01";
    ProtectedItem        = "2021-02-16-preview";
    AzStackHCI           = "2021-09-01-preview";
}

# Role definition GUIDs for storage account creation
$RoleDefinitionIds = @{
    ContributorId                = "b24988ac-6180-42a0-ab88-20f7382dd24c";
    StorageBlobDataContributorId = "ba92f5b4-2d11-453d-a403-e96b0029c9fe";
}

$RunAsAccountCredentialTypes = @{
    HyperVFabric     = "HyperVFabric";
    VMwareFabric     = "VMwareFabric";
    DomainCredential = "DomainCredential";
}

$SiteTypes = @{
    HyperVSites = "HyperVSites";
    VMwareSites = "VMwareSites";
}

$RAMConfig = @{
    GbToMb = 1024;
    MinTargetMemoryInMB = 1024; # 1 GB
    MaxTargetMemoryGen1InMB = 1048576; # 1 TB
    MaxTargetMemoryGen2InMB = 12582912; # 12 TB
    DefaultMinDynamicMemoryInMB = 1024; # 1 GB
    DefaultMaxDynamicMemoryInMB = 1048576; # 1 TB
    DefaultTargetMemoryBufferPercentage = 20; # 20 %
    MinTargetMemoryBufferPercentage = 5; # 5 %
    MaxTargetMemoryBufferPercentage = 2000; # 2000 %
}

enum ProvisioningState
{
    Canceled
    Creating
    Deleting
    Deleted
    Failed
    Succeeded
    Updating
}

enum StorageAccountProvisioningState
{
    Creating
    ResolvingDNS
    Succeeded
}