### Example 1: When there is only OS disk
```powershell
PS C:\> New-AzMigrateServerReplication -VMwareMachineId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.OffAzure/VMwareSites/AzMigratePWSHTc8d1site/machines/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f" -LicenseType NoLicenseType -TargetResourceGroupId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/AzMigratePWSHtargetRG" -TargetNetworkId  "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/AzMigratePWSHtargetRG/providers/Microsoft.Network/virtualNetworks/AzMigrateTargetNetwork" -TargetSubnetName default -TargetVMName "prsadhu-TestVM" -DiskType "Standard_LRS" -OSDiskID "6000C299-343d-7bcd-c05e-a94bd63316dd"

AllowedOperation            : {DisableMigration, TestMigrate, Migrate}
CurrentJobId                : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServ
                              ices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationJobs/None
CurrentJobName              : None
CurrentJobStartTime         : 1/1/53 1:01:01 AM
EventCorrelationId          : d8b110c6-3be9-4798-b2d4-9a1cd068adfb
Health                      : Normal
HealthError                 : {101883a0-23f7-538a-bbd5-6d8b4fa900e2}
Id                          : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServ
                              ices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationFabrics/AzMigratePWSHTc8d1replicationfabric/replicationProtectionCont
                              ainers/AzMigratePWSHTc8d1replicationcontainer/replicationMigrationItems/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-
                              e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f
LastTestMigrationStatus     :
LastTestMigrationTime       :
Location                    :
MachineName                 : prsadhu-TestVM
MigrationState              : Replicating
MigrationStateDescription   : Ready to migrate
Name                        : bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f
PolicyFriendlyName          : migrateAzMigratePWSHTc8d1sitepolicy
PolicyId                    : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServ
                              ices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationPolicies/migrateAzMigratePWSHTc8d1sitepolicy
ProviderSpecificDetail      : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtMigrationDetails
TestMigrateState            : None
TestMigrateStateDescription : None
Type                        : Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationMigrationItems
```

This is for the scenario, when there is only one single disk that has to be protected.

### Example 2: When there are multiple disks
```powershell
PS C:\> $OSDisk = New-AzMigrateDiskMapping -DiskID '6000C299-343d-7bcd-c05e-a94bd63316dd' -DiskType 'Standard_LRS' -IsOSDisk 'true'
PS C:\> $DataDisk = New-AzMigrateDiskMapping -DiskID '7000C299-343d-7bcd-c05e-a94bd63316dd' -DiskType 'Standard_LRS' -IsOSDisk 'false'
PS C:\> $DisksToInclude += $OSDisk
PS C:\> $DisksToInclude += $DataDisk
PS C:\> New-AzMigrateServerReplication -VMwareMachineId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.OffAzure/VMwareSites/AzMigratePWSHTc8d1site/machines/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f" -LicenseType NoLicenseType -TargetResourceGroupId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/AzMigratePWSHtargetRG" -TargetNetworkId  "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/AzMigratePWSHtargetRG/providers/Microsoft.Network/virtualNetworks/AzMigrateTargetNetwork" -TargetSubnetName default -TargetVMName "prsadhu-TestVM" -DiskToInclude $DisksToInclude -PerformAutoResync true

AllowedOperation            : {DisableMigration, TestMigrate, Migrate}
CurrentJobId                : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServ
                              ices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationJobs/None
CurrentJobName              : None
CurrentJobStartTime         : 1/1/53 1:01:01 AM
EventCorrelationId          : d8b110c6-3be9-4798-b2d4-9a1cd068adfb
Health                      : Normal
HealthError                 : {101883a0-23f7-538a-bbd5-6d8b4fa900e2}
Id                          : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServ
                              ices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationFabrics/AzMigratePWSHTc8d1replicationfabric/replicationProtectionCont
                              ainers/AzMigratePWSHTc8d1replicationcontainer/replicationMigrationItems/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-
                              e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f
LastTestMigrationStatus     :
LastTestMigrationTime       :
Location                    :
MachineName                 : prsadhu-TestVM
MigrationState              : Replicating
MigrationStateDescription   : Ready to migrate
Name                        : bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f
PolicyFriendlyName          : migrateAzMigratePWSHTc8d1sitepolicy
PolicyId                    : /Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServ
                              ices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationPolicies/migrateAzMigratePWSHTc8d1sitepolicy
ProviderSpecificDetail      : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtMigrationDetails
TestMigrateState            : None
TestMigrateStateDescription : None
Type                        : Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationMigrationItems
```

This is for the scenario, when there are multiple disks that has to be protected.

