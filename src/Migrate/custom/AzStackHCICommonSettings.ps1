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

$DynamicMemoryConfig = @{
    MaximumMemoryInMegaByte      = 1048576; # 1TB
    MinimumMemoryInMegaByte      = 1024; # 1GB
    TargetMemoryBufferPercentage = 20; # 20%
}