---
external help file:
Module Name: Az.Maintenance
online version: https://docs.microsoft.com/en-us/powershell/module/az.maintenance/new-azmaintenanceconfiguration
schema: 2.0.0
---

# New-AzMaintenanceConfiguration

## SYNOPSIS
Create or Update configuration record

## SYNTAX

```
New-AzMaintenanceConfiguration -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 [-ExtensionProperty <Hashtable>] [-InstallPatchRebootSetting <RebootOptions>]
 [-LinuxParameterClassificationsToInclude <String[]>] [-LinuxParameterPackageNameMasksToExclude <String[]>]
 [-LinuxParameterPackageNameMasksToInclude <String[]>] [-Location <String>]
 [-MaintenanceScope <MaintenanceScope>] [-MaintenanceWindowDuration <String>]
 [-MaintenanceWindowExpirationDateTime <String>] [-MaintenanceWindowRecurEvery <String>]
 [-MaintenanceWindowStartDateTime <String>] [-MaintenanceWindowTimeZone <String>] [-Namespace <String>]
 [-Tag <Hashtable>] [-TaskPostTask <ITaskProperties[]>] [-TaskPreTask <ITaskProperties[]>]
 [-Visibility <Visibility>] [-WindowParameterClassificationsToInclude <String[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create or Update configuration record

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ExtensionProperty
Gets or sets extensionProperties of the maintenanceConfiguration

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstallPatchRebootSetting
Possible reboot preference as defined by the user based on which it would be decided to reboot the machine or not after the patch operation is completed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Support.RebootOptions
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxParameterClassificationsToInclude
Classification category of patches to be patched

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxParameterPackageNameMasksToExclude
Package names to be excluded for patching.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxParameterPackageNameMasksToInclude
Package names to be included for patching.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Gets or sets location of the resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceScope
Gets or sets maintenanceScope of the configuration

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Support.MaintenanceScope
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowDuration
Duration of the maintenance window in HH:mm format.
If not provided, default value will be used based on maintenance scope provided.
Example: 05:00.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowExpirationDateTime
Effective expiration date of the maintenance window in YYYY-MM-DD hh:mm format.
The window will be created in the time zone provided and adjusted to daylight savings according to that time zone.
Expiration date must be set to a future date.
If not provided, it will be set to the maximum datetime 9999-12-31 23:59:59.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowRecurEvery
Rate at which a Maintenance window is expected to recur.
The rate can be expressed as daily, weekly, or monthly schedules.
Daily schedule are formatted as recurEvery: [Frequency as integer]['Day(s)'].
If no frequency is provided, the default frequency is 1.
Daily schedule examples are recurEvery: Day, recurEvery: 3Days.
Weekly schedule are formatted as recurEvery: [Frequency as integer]['Week(s)'] [Optional comma separated list of weekdays Monday-Sunday].
Weekly schedule examples are recurEvery: 3Weeks, recurEvery: Week Saturday,Sunday.
Monthly schedules are formatted as [Frequency as integer]['Month(s)'] [Comma separated list of month days] or [Frequency as integer]['Month(s)'] [Week of Month (First, Second, Third, Fourth, Last)] [Weekday Monday-Sunday] [Optional Offset(No.
of days)].
Offset value must be between -6 to 6 inclusive.
Monthly schedule examples are recurEvery: Month, recurEvery: 2Months, recurEvery: Month day23,day24, recurEvery: Month Last Sunday, recurEvery: Month Fourth Monday, recurEvery: Month Last Sunday Offset-3, recurEvery: Month Third Sunday Offset6.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowStartDateTime
Effective start date of the maintenance window in YYYY-MM-DD hh:mm format.
The start date can be set to either the current date or future date.
The window will be created in the time zone provided and adjusted to daylight savings according to that time zone.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowTimeZone
Name of the timezone.
List of timezones can be obtained by executing [System.TimeZoneInfo]::GetSystemTimeZones() in PowerShell.
Example: Pacific Standard Time, UTC, W.
Europe Standard Time, Korea Standard Time, Cen.
Australia Standard Time.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Gets or sets namespace of the resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
Maintenance Configuration Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Gets or sets tags of the resource

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskPostTask
List of post tasks.
e.g.
[{'source' :'runbook', 'taskScope': 'Resource', 'parameters': { 'arg1': 'value1'}}]
To construct, see NOTES section for TASKPOSTTASK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Models.Api20210901Preview.ITaskProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskPreTask
List of pre tasks.
e.g.
[{'source' :'runbook', 'taskScope': 'Global', 'parameters': { 'arg1': 'value1'}}]
To construct, see NOTES section for TASKPRETASK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Models.Api20210901Preview.ITaskProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Visibility
Gets or sets the visibility of the configuration.
The default value is 'Custom'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Support.Visibility
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterClassificationsToInclude
Classification category of patches to be patched

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterExcludeKbsRequiringReboot
Exclude patches which need reboot

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

### -WindowParameterKbNumbersToExclude
Windows KBID to be excluded for patching.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterKbNumbersToInclude
Windows KBID to be included for patching.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Models.Api20210901Preview.IMaintenanceConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


TASKPOSTTASK <ITaskProperties[]>: List of post tasks. e.g. [{'source' :'runbook', 'taskScope': 'Resource', 'parameters': { 'arg1': 'value1'}}]
  - `[Parameter <ITaskPropertiesParameters>]`: Gets or sets the parameters of the task.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Source <String>]`: Gets or sets the name of the runbook.
  - `[TaskScope <TaskScope?>]`: Global Task execute once when schedule trigger. Resource task execute for each VM.

TASKPRETASK <ITaskProperties[]>: List of pre tasks. e.g. [{'source' :'runbook', 'taskScope': 'Global', 'parameters': { 'arg1': 'value1'}}]
  - `[Parameter <ITaskPropertiesParameters>]`: Gets or sets the parameters of the task.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Source <String>]`: Gets or sets the name of the runbook.
  - `[TaskScope <TaskScope?>]`: Global Task execute once when schedule trigger. Resource task execute for each VM.

## RELATED LINKS

