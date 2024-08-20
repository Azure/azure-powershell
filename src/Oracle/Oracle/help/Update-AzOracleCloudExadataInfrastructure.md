---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/update-azoraclecloudexadatainfrastructure
schema: 2.0.0
---

# Update-AzOracleCloudExadataInfrastructure

## SYNOPSIS
Update a CloudExadataInfrastructure

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOracleCloudExadataInfrastructure -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ComputeCount <Int32>] [-CustomerContact <ICustomerContact[]>] [-DisplayName <String>]
 [-MaintenanceWindowCustomActionTimeoutInMin <Int32>] [-MaintenanceWindowDaysOfWeek <IDayOfWeek[]>]
 [-MaintenanceWindowHoursOfDay <Int32[]>] [-MaintenanceWindowIsCustomActionTimeoutEnabled]
 [-MaintenanceWindowIsMonthlyPatchingEnabled] [-MaintenanceWindowLeadTimeInWeek <Int32>]
 [-MaintenanceWindowMonth <IMonth[]>] [-MaintenanceWindowPatchingMode <String>]
 [-MaintenanceWindowPreference <String>] [-MaintenanceWindowWeeksOfMonth <Int32[]>] [-StorageCount <Int32>]
 [-Tag <Hashtable>] [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzOracleCloudExadataInfrastructure -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzOracleCloudExadataInfrastructure -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOracleCloudExadataInfrastructure -InputObject <IOracleIdentity> [-ComputeCount <Int32>]
 [-CustomerContact <ICustomerContact[]>] [-DisplayName <String>]
 [-MaintenanceWindowCustomActionTimeoutInMin <Int32>] [-MaintenanceWindowDaysOfWeek <IDayOfWeek[]>]
 [-MaintenanceWindowHoursOfDay <Int32[]>] [-MaintenanceWindowIsCustomActionTimeoutEnabled]
 [-MaintenanceWindowIsMonthlyPatchingEnabled] [-MaintenanceWindowLeadTimeInWeek <Int32>]
 [-MaintenanceWindowMonth <IMonth[]>] [-MaintenanceWindowPatchingMode <String>]
 [-MaintenanceWindowPreference <String>] [-MaintenanceWindowWeeksOfMonth <Int32[]>] [-StorageCount <Int32>]
 [-Tag <Hashtable>] [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a CloudExadataInfrastructure

## EXAMPLES

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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeCount
The number of compute servers for the cloud Exadata infrastructure.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerContact
The list of customer email addresses that receive information from Oracle about the specified OCI Database service resource.
Oracle uses these email addresses to send notifications about planned and unplanned software maintenance updates, information about system hardware, and other information needed by administrators.
Up to 10 email addresses can be added to the customer contacts for a cloud Exadata infrastructure instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.ICustomerContact[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DisplayName
The name for the Exadata infrastructure.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowCustomActionTimeoutInMin
Determines the amount of time the system will wait before the start of each database server patching operation.
Custom action timeout is in minutes and valid value is between 15 to 120 (inclusive).

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowDaysOfWeek
Days during the week when maintenance should be performed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDayOfWeek[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowHoursOfDay
The window of hours during the day when maintenance should be performed.
The window is a 4 hour slot.
Valid values are - 0 - represents time slot 0:00 - 3:59 UTC - 4 - represents time slot 4:00 - 7:59 UTC - 8 - represents time slot 8:00 - 11:59 UTC - 12 - represents time slot 12:00 - 15:59 UTC - 16 - represents time slot 16:00 - 19:59 UTC - 20 - represents time slot 20:00 - 23:59 UTC

```yaml
Type: System.Int32[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowIsCustomActionTimeoutEnabled
If true, enables the configuration of a custom action timeout (waiting period) between database server patching operations.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowIsMonthlyPatchingEnabled
is Monthly Patching Enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowLeadTimeInWeek
Lead time window allows user to set a lead time to prepare for a down time.
The lead time is in weeks and valid value is between 1 to 4.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowMonth
Months during the year when maintenance should be performed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMonth[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowPatchingMode
Cloud Exadata infrastructure node patching method.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowPreference
The maintenance window scheduling preference.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowWeeksOfMonth
Weeks during the month when maintenance should be performed.
Weeks start on the 1st, 8th, 15th, and 22nd days of the month, and have a duration of 7 days.
Weeks start and end based on calendar dates, not days of the week.
For example, to allow maintenance during the 2nd week of the month (from the 8th day to the 14th day of the month), use the value 2.
Maintenance cannot be scheduled for the fifth week of months that contain more than 28 days.
Note that this parameter works in conjunction with the daysOfWeek and hoursOfDay parameters to allow you to specify specific days of the week and hours that maintenance will be performed.

```yaml
Type: System.Int32[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
CloudExadataInfrastructure name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: Cloudexadatainfrastructurename

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageCount
The number of storage servers for the cloud Exadata infrastructure.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
CloudExadataInfrastructure zones

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.ICloudExadataInfrastructure

## NOTES

## RELATED LINKS
