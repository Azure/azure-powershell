---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabasecloudexadatainfrastructure
schema: 2.0.0
---

# Get-AzOracleDatabaseCloudExadataInfrastructure

## SYNOPSIS
Get a CloudExadataInfrastructure

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseCloudExadataInfrastructure [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseCloudExadataInfrastructure -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseCloudExadataInfrastructure -InputObject <IOracleDatabaseIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzOracleDatabaseCloudExadataInfrastructure -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a CloudExadataInfrastructure

## EXAMPLES

### Example 1: Get a list of the Cloud Exadata Infrastructure resources
```powershell
Get-AzOracleDatabaseCloudExadataInfrastructure
```

```output
Location           Name                         SystemDataCreatedAt SystemDataCreatedBy          SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------           ----                         ------------------- -------------------          ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus             OFake_PowerShellTestExaInfra 04/07/2024 13:20:00 example@oracle.com    User                    06/07/2024 11:04:06      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  PowerShellTestRg
eastus             DemoExaInfra                 05/07/2024 08:20:01 eamon.el-homsi@oracle.com    User                    06/07/2024 11:04:07      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  SDKTestRG
germanywestcentral OFake_ppratees_0216_2        16/02/2024 20:24:39 prateek.ps.sharma@oracle.com User                    06/07/2024 11:03:57      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  ObsTestingFra
```

Get a list of the Cloud Exadata Infrastructure resources.
For more information, execute `Get-Help Get-AzOracleDatabaseCloudExadataInfrastructure`.

### Example 2: Get a Cloud Exadata Infrastructure resource by name and resource group name
```powershell
Get-AzOracleDatabaseCloudExadataInfrastructure -Name "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg"
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
Id                                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudExadataInfrastru
                                                            ctures/OFake_PowerShellTestExaInfra
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
OciUrl                                                    : https://cloud.oracle.com/dbaas/cloudExadataInfrastructures/ocid1.cloudexadatainfrastructure.oc1.iad.anuwcljrnirvylqajp6lgcommbx5qbu
                                                            uk7dsm4y5ioehfdqa6l66htw7mj6q?region=us-ashburn-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsa
                                                            e5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                                      : ocid1.cloudexadatainfrastructure.oc1.iad.anuwcljrnirvylqajp6lgcommbx5qbuuk7dsm4y5ioehfdqa6l66htw7mj6q
ProvisioningState                                         : Succeeded
ResourceGroupName                                         : PowerShellTestRg
Shape                                                     : Exadata.X9M
StorageCount                                              : 3
StorageServerVersion                                      : 21.1.0.0.0
SystemDataCreatedAt                                       : 04/07/2024 13:20:00
SystemDataCreatedBy                                       : example@oracle.com
SystemDataCreatedByType                                   : User
SystemDataLastModifiedAt                                  : 06/07/2024 08:49:18
SystemDataLastModifiedBy                                  : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                              : Application
Tag                                                       : {
                                                            }
TimeCreated                                               : 2024-07-04T13:20:13.877Z
TotalStorageSizeInGb                                      : 196608
Type                                                      : oracle.database/cloudexadatainfrastructures
Zone                                                      : {2}
```

Get a Cloud Exadata Infrastructure resource by name.
For more information, execute `Get-Help Get-AzOracleDatabaseCloudExadataInfrastructure`.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
CloudExadataInfrastructure name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Cloudexadatainfrastructurename

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.ICloudExadataInfrastructure

## NOTES

## RELATED LINKS

