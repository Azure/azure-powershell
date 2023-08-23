$AzMigrateSupportedScenarios = @{
    agentlessVMware = "agentlessVMware";
    AzStackHCI      = "AzStackHCI";
}

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
    MaxMemoryInMB = 1048576;
    MinMemoryInMB = 1024;
    TargetMemoryBufferPercentage = 20;
}

$StorageContainerQuery = "resources
| where type == 'microsoft.extendedlocation/customlocations'
| mv-expand ClusterId = properties['clusterExtensionIds']
| extend ClusterId = toupper(tostring(ClusterId))
| extend CustomLocation = toupper(tostring(id))
| project ClusterId, CustomLocation
| join (
kubernetesconfigurationresources
| where type == 'microsoft.kubernetesconfiguration/extensions'
| where properties['ConfigurationSettings']['HCIClusterID'] =~ '{0}'
| project ClusterId = id
| extend ClusterId = toupper(tostring(ClusterId))
) on ClusterId
| join (
resources
| where type == 'microsoft.azurestackhci/storagecontainers'
| extend CustomLocation = toupper(tostring(extendedLocation['name']))
| extend AvailableSizeMB = properties['status']['availableSizeMB']
| extend  ContainerSizeMB = properties['status']['containerSizeMB']
) on CustomLocation
| project-away ClusterId, CustomLocation"


$VirtualSwitchQuery = "resources
| where type == 'microsoft.extendedlocation/customlocations'
| mv-expand ClusterId = properties['clusterExtensionIds']
| extend ClusterId = toupper(tostring(ClusterId))
| extend CustomLocation = toupper(tostring(id))
| project ClusterId, CustomLocation
| join (
kubernetesconfigurationresources
| where type == 'microsoft.kubernetesconfiguration/extensions'
| where properties['ConfigurationSettings']['HCIClusterID'] =~ '{0}'
| project ClusterId = id
| extend ClusterId = toupper(tostring(ClusterId))
) on ClusterId
| join (
resources
| where type == 'microsoft.azurestackhci/virtualnetworks'
| extend CustomLocation = toupper(tostring(extendedLocation['name']))
) on CustomLocation
| project-away ClusterId, CustomLocation, ClusterId1, CustomLocation1"