---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/update-azoracleautonomousdatabase
schema: 2.0.0
---

# Update-AzOracleAutonomousDatabase

## SYNOPSIS
Update a AutonomousDatabase

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AdminPassword <SecureString>] [-AutonomousMaintenanceScheduleType <String>]
 [-BackupRetentionPeriodInDay <Int32>] [-ComputeCount <Single>] [-CpuCoreCount <Int32>]
 [-CustomerContact <ICustomerContact[]>] [-DataStorageSizeInGb <Int32>] [-DataStorageSizeInTb <Int32>]
 [-DatabaseEdition <String>] [-DayOfWeekName <String>] [-DisplayName <String>] [-IsAutoScalingEnabled]
 [-IsAutoScalingForStorageEnabled] [-IsLocalDataGuardEnabled] [-IsMtlsConnectionRequired]
 [-LicenseModel <String>] [-LocalAdgAutoFailoverMaxDataLossLimit <Int32>] [-LongTermBackupScheduleIsDisabled]
 [-LongTermBackupScheduleRepeatCadence <String>] [-LongTermBackupScheduleRetentionPeriodInDay <Int32>]
 [-LongTermBackupScheduleTimeOfBackup <DateTime>] [-OpenMode <String>] [-PeerDbId <String>]
 [-PermissionLevel <String>] [-Role <String>] [-ScheduledStartTime <String>] [-ScheduledStopTime <String>]
 [-Tag <Hashtable>] [-WhitelistedIP <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOracleAutonomousDatabase -InputObject <IOracleIdentity> [-AdminPassword <SecureString>]
 [-AutonomousMaintenanceScheduleType <String>] [-BackupRetentionPeriodInDay <Int32>] [-ComputeCount <Single>]
 [-CpuCoreCount <Int32>] [-CustomerContact <ICustomerContact[]>] [-DataStorageSizeInGb <Int32>]
 [-DataStorageSizeInTb <Int32>] [-DatabaseEdition <String>] [-DayOfWeekName <String>] [-DisplayName <String>]
 [-IsAutoScalingEnabled] [-IsAutoScalingForStorageEnabled] [-IsLocalDataGuardEnabled]
 [-IsMtlsConnectionRequired] [-LicenseModel <String>] [-LocalAdgAutoFailoverMaxDataLossLimit <Int32>]
 [-LongTermBackupScheduleIsDisabled] [-LongTermBackupScheduleRepeatCadence <String>]
 [-LongTermBackupScheduleRetentionPeriodInDay <Int32>] [-LongTermBackupScheduleTimeOfBackup <DateTime>]
 [-OpenMode <String>] [-PeerDbId <String>] [-PermissionLevel <String>] [-Role <String>]
 [-ScheduledStartTime <String>] [-ScheduledStopTime <String>] [-Tag <Hashtable>] [-WhitelistedIP <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a AutonomousDatabase

## EXAMPLES

### Example 1: Update an Autonomous Database resource
```powershell
$tagHashTable = @{'tagName'="tagValue"}
Update-AzOracleAutonomousDatabase -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Tag $tagHashTable
```

```output
...
Name                                          : OFakePowerShellTestAdbs
NcharacterSet                                 : AL16UTF16
NextLongTermBackupTimeStamp                   : 
OciUrl                                        : https://cloud.oracle.com/db/adbs/ocid1.autonomousdatabase.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuuwov4vm626yj46caifxh4le5uoxa?region=us-ashburn-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..a
                                                aaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                          : ocid1.autonomousdatabase.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuuwov4vm626yj46caifxh4le5uoxa
OpenMode                                      : ReadWrite
OperationsInsightsStatus                      : 
PeerDbId                                      : 
PeerDbIds                                     : 
PermissionLevel                               : 
PrivateEndpoint                               : byui3zo3.adb.us-ashburn-1.oraclecloud.com
PrivateEndpointIP                             : 10.0.1.51
PrivateEndpointLabel                          : byui3zo3
Property                                      : {
                                                  ...
                                                }
ProvisionableCpu                              : 
ProvisioningState                             : Succeeded
ResourceGroupName                             : PowerShellTestRg
Role                                          : 
ScheduledOperationScheduledStartTime          : 
ScheduledOperationScheduledStopTime           : 
ServiceConsoleUrl                             : 
SqlWebDeveloperUrl                            : 
SubnetId                                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subnets/delegated
SupportedRegionsToCloneTo                     : 
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 15:41:08
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
Tag                                           : {
                                                  "tagName": "tagValue"
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
TimeDataGuardRoleChanged                      : 
TimeDeletionOfFreeAutonomousDatabase          : 
TimeLocalDataGuardEnabled                     : Fri Jul 05 13:44:40 UTC 2024
TimeMaintenanceBegin                          : 07/07/2024 09:00:00
TimeMaintenanceEnd                            : 07/07/2024 11:00:00
TimeOfLastFailover                            : 
TimeOfLastRefresh                             : 
TimeOfLastRefreshPoint                        : 
TimeOfLastSwitchover                          : 
TimeReclamationOfFreeAutonomousDatabase       : 
Type                                          : oracle.database/autonomousdatabases
UsedDataStorageSizeInGb                       : 
UsedDataStorageSizeInTb                       : 
VnetId                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
WhitelistedIP                                 :
```

Update an Autonomous Database resource.
For more information, execute `Get-Help Update-AzOracleAutonomousDatabase`.

## PARAMETERS

### -AdminPassword
Admin password.

```yaml
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AutonomousMaintenanceScheduleType
The maintenance schedule type of the Autonomous Database Serverless.

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

### -BackupRetentionPeriodInDay
Retention period, in days, for long-term backups

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

### -ComputeCount
The compute amount (CPUs) available to the database.

```yaml
Type: System.Single
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CpuCoreCount
The number of CPU cores to be made available to the database.

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
Customer Contacts.

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

### -DatabaseEdition
The Oracle Database Edition that applies to the Autonomous databases.

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

### -DataStorageSizeInGb
The size, in gigabytes, of the data volume that will be created and attached to the database.

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

### -DataStorageSizeInTb
The quantity of data in the database, in terabytes.

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

### -DayOfWeekName
Name of the day of the week.

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
The user-friendly name for the Autonomous Database.

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

### -IsAutoScalingEnabled
Indicates if auto scaling is enabled for the Autonomous Database CPU core count.

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

### -IsAutoScalingForStorageEnabled
Indicates if auto scaling is enabled for the Autonomous Database storage.

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

### -IsLocalDataGuardEnabled
Indicates whether the Autonomous Database has local or called in-region Data Guard enabled.

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

### -IsMtlsConnectionRequired
Specifies if the Autonomous Database requires mTLS connections.

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

### -LicenseModel
The Oracle license model that applies to the Oracle Autonomous Database.
The default is LICENSE_INCLUDED.

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

### -LocalAdgAutoFailoverMaxDataLossLimit
Parameter that allows users to select an acceptable maximum data loss limit in seconds, up to which Automatic Failover will be triggered when necessary for a Local Autonomous Data Guard

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

### -LongTermBackupScheduleIsDisabled
Indicates if the long-term backup schedule should be deleted.
The default value is `FALSE`.

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

### -LongTermBackupScheduleRepeatCadence
The frequency of the long-term backup schedule

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

### -LongTermBackupScheduleRetentionPeriodInDay
Retention period, in days, for backups.

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

### -LongTermBackupScheduleTimeOfBackup
The timestamp for the long-term backup schedule.
For a MONTHLY cadence, months having fewer days than the provided date will have the backup taken on the last day of that month.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The database name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: Autonomousdatabasename

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

### -OpenMode
Indicates the Autonomous Database mode.

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

### -PeerDbId
The database OCID of the Disaster Recovery peer database, which is located in a different region from the current peer database.

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

### -PermissionLevel
The Autonomous Database permission level.

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

### -Role
The Data Guard role of the Autonomous Container Database or Autonomous Database, if Autonomous Data Guard is enabled.

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

### -ScheduledStartTime
auto start time.
value must be of ISO-8601 format HH:mm

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

### -ScheduledStopTime
auto stop time.
value must be of ISO-8601 format HH:mm

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

### -WhitelistedIP
The client IP access control list (ACL).
This is an array of CIDR notations and/or IP addresses.
Values should be separate strings, separated by commas.
Example: ['1.1.1.1','1.1.1.0/24','1.1.2.25']

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IAutonomousDatabase

## NOTES

## RELATED LINKS
