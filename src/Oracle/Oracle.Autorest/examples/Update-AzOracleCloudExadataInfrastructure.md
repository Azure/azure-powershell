### Example 1: Update a Cloud Exadata Infrastructure resource
```powershell
$tagHashTable = @{'tagName'="tagValue"}
Update-AzOracleCloudExadataInfrastructure -Name "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg" -Tag $tagHashTable
```

```output
ActivatedStorageCount                                     : 3
AdditionalStorageCount                                    : 0
AvailableStorageSizeInGb                                  : 0
ComputeCount                                              : 3
CpuCount                                                  : 4
CustomerContact                                           : 
DataStorageSizeInTb                                       : 2
DbNodeStorageSizeInGb                                     : 938
DbServerVersion                                           : 23.1.13.0.0.240410.1
DisplayName                                               : OFake_PowerShellTestExaInfra
EstimatedPatchingTimeEstimatedDbServerPatchingTime        : 
EstimatedPatchingTimeEstimatedNetworkSwitchesPatchingTime : 
EstimatedPatchingTimeEstimatedStorageServerPatchingTime   : 
EstimatedPatchingTimeTotalEstimatedPatchingTime           : 
Id                                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudExadataInfrastructures/OFake_PowerShellTestExaInfra
LastMaintenanceRunId                                      : 
LifecycleDetail                                           : 
LifecycleState                                            : Available
Location                                                  : eastus
MaintenanceWindowCustomActionTimeoutInMin                 : 0
MaintenanceWindowDaysOfWeek                               : 
MaintenanceWindowHoursOfDay                               : 
MaintenanceWindowIsCustomActionTimeoutEnabled             : False
MaintenanceWindowIsMonthlyPatchingEnabled                 : 
MaintenanceWindowLeadTimeInWeek                           : 0
MaintenanceWindowMonth                                    : 
MaintenanceWindowPatchingMode                             : Rolling
MaintenanceWindowPreference                               : NoPreference
MaintenanceWindowWeeksOfMonth                             : 
MaxCpuCount                                               : 378
MaxDataStorageInTb                                        : 192
MaxDbNodeStorageSizeInGb                                  : 6729
MaxMemoryInGb                                             : 4170
MemorySizeInGb                                            : 90
MonthlyDbServerVersion                                    : 
MonthlyStorageServerVersion                               : 
Name                                                      : OFake_PowerShellTestExaInfra
NextMaintenanceRunId                                      : 
OciUrl                                                    : https://cloud.oracle.com/dbaas/cloudExadataInfrastructures/ocid1.cloudexadatainfrastructure.oc1.iad.anuwcljrnirvylqajp6lgcommbx5qbuuk7dsm4y5ioehfdqa6l66htw7mj6q?region=us-ashburn-1&tenant=orps
                                                            andbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                                      : ocid1.cloudexadatainfrastructure.oc1.iad.anuwcljrnirvylqajp6lgcommbx5qbuuk7dsm4y5ioehfdqa6l66htw7mj6q
ProvisioningState                                         : Succeeded
ResourceGroupName                                         : PowerShellTestRg
Shape                                                     : Exadata.X9M
StorageCount                                              : 3
StorageServerVersion                                      : 21.1.0.0.0
SystemDataCreatedAt                                       : 04/07/2024 13:20:00
SystemDataCreatedBy                                       : example@oracle.com
SystemDataCreatedByType                                   : User
SystemDataLastModifiedAt                                  : 06/07/2024 15:35:54
SystemDataLastModifiedBy                                  : example@oracle.com
SystemDataLastModifiedByType                              : User
Tag                                                       : {
                                                              "tagName": "tagValue"
                                                            }
TimeCreated                                               : 2024-07-04T13:20:13.877Z
TotalStorageSizeInGb                                      : 196608
Type                                                      : oracle.database/cloudexadatainfrastructures
Zone                                                      : {2}
```

Update a Cloud Exadata Infrastructure resource.
For more information, execute `Get-Help Update-AzOracleCloudExadataInfrastructure`.