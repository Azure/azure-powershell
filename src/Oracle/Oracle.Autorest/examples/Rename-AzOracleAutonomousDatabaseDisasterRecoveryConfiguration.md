### Example 1: change an Autonomous Database Disaster recovery configurations resource
```powershell
$subscriptionId = "00000000-0000-0000-0000-000000000000"
$resourceGroup = "PowerShellTestRg"
$autonomousdatabasename = "databasedb1"

Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration -autonomousdatabasename $autonomousdatabasename -ResourceGroupName $resourceGroup -DisasterRecoveryType "Adg"
```

```output
id                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg000/providers/Oracle.Database/autonomousDatabases/databasedb1
type                        : Oracle.Database/autonomousDatabases
location                    : eastus
tags.tagK1                  : tagV1
autonomousDatabaseId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg000/providers/Oracle.Database/autonomousDatabases/databasedb1
actualUsedDataStorageSizeInTbs: null
autonomousMaintenanceScheduleType: Regular
characterSet                : AL32UTF8
ncharacterSet               : AL16UTF16
computeCount                : 2.0
computeModel                : ECPU
cpuCoreCount                : 1
customerContacts            : null
dataStorageSizeInGbs        : 1024
dataStorageSizeInTbs        : 1
databaseEdition             : EnterpriseEdition
dataBaseType                : Regular
dbVersion                   : 19c
displayName                 : example_autonomous_databasedb1
isAutoScalingEnabled        : false
isAutoScalingForStorageEnabled: false
failedDataRecoveryInSeconds : null
isLocalDataGuardEnabled     : false
isRemoteDataGuardEnabled    : true
timeDisasterRecoveryRoleChanged: 2024-07-30T18:22:10.970Z
timeDataGuardRoleChanged    : 2024-07-30T18:22:10.970Z
timeLocalDataGuardEnabled   : 2024-07-04T01:02:36.782Z
localDisasterRecoveryType   : BackupBased
localAdgAutoFailoverMaxDataLossLimit: null
remoteDisasterRecoveryConfiguration.disasterRecoveryType: BackupBased
remoteDisasterRecoveryConfiguration.isReplicateAutomaticBackups: false
remoteDisasterRecoveryConfiguration.isSnapshotStandby: null
remoteDisasterRecoveryConfiguration.timeSnapshotStandbyEnabledTill: null
role                        : BackupCopy
peerDbIds                   : ocid1.bbbbb
localStandbyDb              : null
isMtlsConnectionRequired    : true
licenseModel                : BringYourOwnLicense
lifecycleState              : Updating
lifecycleDetails            : null
privateEndpointIp           : null
privateEndpointLabel        : null
subnetId                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg000/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1
vnetId                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg000/providers/Microsoft.Network/virtualNetworks/vnet1
provisioningState           : Provisioning
ociUrl                      : https://fake
timeCreated                 : 2024-01-20T21:20:08.070Z
timeOfLastFailover          : null
timeOfLastSwitchover        : null
timeMaintenanceBegin        : null
timeMaintenanceEnd          : null
usedDataStorageSizeInGbs    : null
usedDataStorageSizeInTbs    : null
ocid                        : ocid1..aaaaa
```

Change an Autonomous Database Disaster recovery configuration.
For more information, execute `Get-Help Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration`.
