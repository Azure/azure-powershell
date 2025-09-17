$AzLocalInstanceTypes = @{
    HyperVToAzLocal = "HyperVToAzStackHCI";
    VMwareToAzLocal = "VMwareToAzStackHCI";
}

# Fabric instances
$FabricInstanceTypes = @{
    HyperVInstance = "HyperVMigrate";
    VMwareInstance = "VMwareMigrate";
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

$OsTypes = @{
    LinuxGuest = "linuxguest";
    WindowsGuest = "windowsguest";
    OtherGuestFamily = "otherguestfamily";
}

$VmReplicationValidationMessage = "Replication could not be initiated. Please ensure the necessary changes are made, and allow up to 30 minutes before re-trying."
$VmReplicationValidationMessages = @{
    VmPoweredOff            = "The VM is currently powered off. $VmReplicationValidationMessage";
    AlreadyInReplication    = "The VM is already in replication. $VmReplicationValidationMessage";
    VmNotHighlyAvailable    = "VM not highly available. $VmReplicationValidationMessage";
    HyperVIntegrationServicesNotRunning = "Hyper-V Integration Services are not running on VM. $VmReplicationValidationMessage";
    VmWareToolsNotInstalled = "VMware Tools are not installed on the VM. To preserve static IPs during migration, install VMware Tools and wait up to 30 minutes for the system to detect the changes.";
    VmWareToolsNotRunning   = "VMware Tools are not running on the VM. To preserve static IPs during migration, ensure VMware Tools are running and wait up to 30 minutes for the system to detect the changes.";
    OsTypeNotSupported      = "The VM OS type could not be identified. For custom Windows or Linux builds, run: `Set-AzMigrateLocalServerReplication -TargetObjectID <ProtectedItemId> -OsType <OsType>` to specify the OS type before migration.";
}

$ArcResourceBridgeValidationMessages = @{
    NotRunning = "Arc Resource Bridge is offline. To continue, bring the Arc Resource Bridge online. Wait a few minutes for the status to update and retry.";
    NoClusters = "There are no Azure Local clusters found in the selected resource group."
}

$IdFormats = @{
    ResourceGroupArmIdTemplate  = "/subscriptions/{0}/resourceGroups/{1}"
    MachineArmIdTemplate        = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.OffAzure/{2}/{3}/machines/{4}"
    StoragePathArmIdTemplate    = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.AzureStackHCI/storageContainers/{2}"
    LogicalNetworkArmIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.AzureStackHCI/logicalnetworks/{2}"
    MigrateProjectArmIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Migrate/MigrateProjects/{2}"
    ProtectedItemArmIdTemplate  = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DataReplication/replicationVaults/{2}/protectedItems/{3}"
}

$TargetVMCPUCores = @{
    Min = 1
    Max = 64
}

$TargetVMRamInMB = @{
    Gen1Min = 512
    Gen1Max = 1048576 # 1 TB
    Gen2Min = 32
    Gen2Max = 12582912 # 12 TB
}