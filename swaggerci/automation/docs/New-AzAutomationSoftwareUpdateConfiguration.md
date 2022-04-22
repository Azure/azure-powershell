---
external help file:
Module Name: Az.Automation
online version: https://docs.microsoft.com/en-us/powershell/module/az.automation/new-azautomationsoftwareupdateconfiguration
schema: 2.0.0
---

# New-AzAutomationSoftwareUpdateConfiguration

## SYNOPSIS
Create a new software update configuration with the name given in the URI.

## SYNTAX

```
New-AzAutomationSoftwareUpdateConfiguration -AutomationAccountName <String> -Name <String>
 -ResourceGroupName <String> -UpdateConfigurationOperatingSystem <OperatingSystemType>
 [-SubscriptionId <String>] [-ClientRequestId <String>] [-AdvancedScheduleMonthDay <Int32[]>]
 [-AdvancedScheduleMonthlyOccurrence <IAdvancedScheduleMonthlyOccurrence[]>]
 [-AdvancedScheduleWeekDay <String[]>] [-Code <String>] [-LinuxExcludedPackageNameMask <String[]>]
 [-LinuxIncludedPackageClassification <LinuxUpdateClasses>] [-LinuxIncludedPackageNameMask <String[]>]
 [-LinuxRebootSetting <String>] [-Message <String>] [-PostTaskParameter <Hashtable>]
 [-PostTaskSource <String>] [-PreTaskParameter <Hashtable>] [-PreTaskSource <String>]
 [-ScheduleInfoCreationTime <DateTime>] [-ScheduleInfoDescription <String>]
 [-ScheduleInfoExpiryTime <DateTime>] [-ScheduleInfoExpiryTimeOffsetMinute <Double>]
 [-ScheduleInfoFrequency <ScheduleFrequency>] [-ScheduleInfoInterval <Int64>] [-ScheduleInfoIsEnabled]
 [-ScheduleInfoLastModifiedTime <DateTime>] [-ScheduleInfoNextRun <DateTime>]
 [-ScheduleInfoNextRunOffsetMinute <Double>] [-ScheduleInfoStartTime <DateTime>]
 [-ScheduleInfoTimeZone <String>] [-TargetAzureQuery <IAzureQueryProperties[]>]
 [-TargetNonAzureQuery <INonAzureQueryProperties[]>] [-UpdateConfigurationAzureVirtualMachine <String[]>]
 [-UpdateConfigurationDuration <TimeSpan>] [-UpdateConfigurationNonAzureComputerName <String[]>]
 [-WindowExcludedKbNumber <String[]>] [-WindowIncludedKbNumber <String[]>]
 [-WindowIncludedUpdateClassification <WindowsUpdateClasses>] [-WindowRebootSetting <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new software update configuration with the name given in the URI.

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

### -AdvancedScheduleMonthDay
Days of the month that the job should execute on.
Must be between 1 and 31.

```yaml
Type: System.Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdvancedScheduleMonthlyOccurrence
Occurrences of days within a month.
To construct, see NOTES section for ADVANCEDSCHEDULEMONTHLYOCCURRENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20190601.IAdvancedScheduleMonthlyOccurrence[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdvancedScheduleWeekDay
Days of the week that the job should execute on.

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

### -AutomationAccountName
The name of the automation account.

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

### -ClientRequestId
Identifies this specific client request.

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

### -Code
Error code

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

### -LinuxExcludedPackageNameMask
packages excluded from the software update configuration.

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

### -LinuxIncludedPackageClassification
Update classifications included in the software update configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Support.LinuxUpdateClasses
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxIncludedPackageNameMask
packages included from the software update configuration.

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

### -LinuxRebootSetting
Reboot setting for the software update configuration.

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

### -Message
Error message indicating why the operation failed.

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

### -Name
The name of the software update configuration to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SoftwareUpdateConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PostTaskParameter
Gets or sets the parameters of the task.

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

### -PostTaskSource
Gets or sets the name of the runbook.

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

### -PreTaskParameter
Gets or sets the parameters of the task.

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

### -PreTaskSource
Gets or sets the name of the runbook.

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
Name of an Azure Resource group.

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

### -ScheduleInfoCreationTime
Gets or sets the creation time.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoDescription
Gets or sets the description.

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

### -ScheduleInfoExpiryTime
Gets or sets the end time of the schedule.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoExpiryTimeOffsetMinute
Gets or sets the expiry time's offset in minutes.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoFrequency
Gets or sets the frequency of the schedule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Support.ScheduleFrequency
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoInterval
Gets or sets the interval of the schedule.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoIsEnabled
Gets or sets a value indicating whether this schedule is enabled.

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

### -ScheduleInfoLastModifiedTime
Gets or sets the last modified time.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoNextRun
Gets or sets the next run time of the schedule.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoNextRunOffsetMinute
Gets or sets the next run time's offset in minutes.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoStartTime
Gets or sets the start time of the schedule.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInfoTimeZone
Gets or sets the time zone of the schedule.

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

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
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

### -TargetAzureQuery
List of Azure queries in the software update configuration.
To construct, see NOTES section for TARGETAZUREQUERY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20190601.IAzureQueryProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetNonAzureQuery
List of non Azure queries in the software update configuration.
To construct, see NOTES section for TARGETNONAZUREQUERY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20190601.INonAzureQueryProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateConfigurationAzureVirtualMachine
List of azure resource Ids for azure virtual machines targeted by the software update configuration.

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

### -UpdateConfigurationDuration
Maximum time allowed for the software update configuration run.
Duration needs to be specified using the format PT[n]H[n]M[n]S as per ISO8601

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateConfigurationNonAzureComputerName
List of names of non-azure machines targeted by the software update configuration.

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

### -UpdateConfigurationOperatingSystem
operating system of target machines

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Support.OperatingSystemType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowExcludedKbNumber
KB numbers excluded from the software update configuration.

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

### -WindowIncludedKbNumber
KB numbers included from the software update configuration.

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

### -WindowIncludedUpdateClassification
Update classification included in the software update configuration.
A comma separated string with required values

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automation.Support.WindowsUpdateClasses
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowRebootSetting
Reboot setting for the software update configuration.

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

### Microsoft.Azure.PowerShell.Cmdlets.Automation.Models.Api20190601.ISoftwareUpdateConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ADVANCEDSCHEDULEMONTHLYOCCURRENCE <IAdvancedScheduleMonthlyOccurrence[]>: Occurrences of days within a month.
  - `[Day <ScheduleDay?>]`: Day of the occurrence. Must be one of monday, tuesday, wednesday, thursday, friday, saturday, sunday.
  - `[Occurrence <Int32?>]`: Occurrence of the week within the month. Must be between 1 and 5

TARGETAZUREQUERY <IAzureQueryProperties[]>: List of Azure queries in the software update configuration.
  - `[Location <String[]>]`: List of locations to scope the query to.
  - `[Scope <String[]>]`: List of Subscription or Resource Group ARM Ids.
  - `[TagSettingFilterOperator <TagOperators?>]`: Filter VMs by Any or All specified tags.
  - `[TagSettingTag <ITagSettingsPropertiesTags>]`: Dictionary of tags with its list of values.
    - `[(Any) <String[]>]`: This indicates any property can be added to this object.

TARGETNONAZUREQUERY <INonAzureQueryProperties[]>: List of non Azure queries in the software update configuration.
  - `[FunctionAlias <String>]`: Log Analytics Saved Search name.
  - `[WorkspaceId <String>]`: Workspace Id for Log Analytics in which the saved Search is resided.

## RELATED LINKS

