$AzLocalInstanceTypes = @{
    HyperVToAzLocal = "HyperVToAzStackHCI";
    VMwareToAzLocal = "VMwareToAzStackHCI";
}

# Fabric instances
$FabricInstanceTypes = @{
    HyperVInstance     = "HyperVMigrate";
    VMwareInstance     = "VMwareMigrate";
    AzLocalInstance = "AzStackHCI";
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
    AzLocal              = "2021-09-01-preview";
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

# Selection state for VM NIC
$VMNicSelection = @{
    SelectedByUser = "SelectedByUser";
    NotSelected    = "NotSelected";
}

$PowerStatus = @{
    OffVMware = "OFF";
    OnVMWare = "ON";
    OffHyperV = "PowerOff";
    OnHyperV = "Running";
}

$HighAvailability = @{
    NO = "No";
    YES = "Yes";
}

$VMwareToolsStatus = @{
    NotRunning = "NotRunning";
    OK = "OK";
    NotInstalled = "NotInstalled";
}

$VmReplicationValidationMessage = "Replication could not be initiated. Please ensure the necessary changes are made, and allow up to 30 minutes before re-trying."
$VmReplicationValidationMessages = @{
    VmPoweredOff            = "The VM is currently powered off. $VmReplicationValidationMessage";
    AlreadyInReplication    = "The VM is already in replication. $VmReplicationValidationMessage";
    VmWareToolsNotInstalled = "VMware tools not installed on VM. $VmReplicationValidationMessage";
    VmWareToolsNotRunning   = "VMware tools not running on VM. $VmReplicationValidationMessage";
    VmNotHighlyAvailable    = "VM not highly available. $VmReplicationValidationMessage";
    OsTypeNotFound          = "Hyper-V Integration Services not running on VM. $VmReplicationValidationMessage";
}