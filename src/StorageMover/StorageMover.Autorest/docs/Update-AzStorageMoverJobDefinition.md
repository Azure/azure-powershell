---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemoverjobdefinition
schema: 2.0.0
---

# Update-AzStorageMoverJobDefinition

## SYNOPSIS
Update properties for a Job Definition resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] [-AgentName <String>] [-Connection <String[]>]
 [-CopyMode <String>] [-DataIntegrityValidation <String>] [-Description <String>] [-ExecutionTimeHour <Int32>]
 [-ExecutionTimeMinute <Single>] [-ScheduleCronExpression <String>] [-ScheduleDaysOfMonth <Int32[]>]
 [-ScheduleDaysOfWeek <String[]>] [-ScheduleEndDate <DateTime>] [-ScheduleFrequency <String>]
 [-ScheduleIsActive] [-ScheduleStartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverJobDefinition -InputObject <IStorageMoverIdentity> [-AgentName <String>]
 [-Connection <String[]>] [-CopyMode <String>] [-DataIntegrityValidation <String>] [-Description <String>]
 [-ExecutionTimeHour <Int32>] [-ExecutionTimeMinute <Single>] [-ScheduleCronExpression <String>]
 [-ScheduleDaysOfMonth <Int32[]>] [-ScheduleDaysOfWeek <String[]>] [-ScheduleEndDate <DateTime>]
 [-ScheduleFrequency <String>] [-ScheduleIsActive] [-ScheduleStartDate <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProjectExpanded
```
Update-AzStorageMoverJobDefinition -Name <String> -ProjectInputObject <IStorageMoverIdentity>
 [-AgentName <String>] [-Connection <String[]>] [-CopyMode <String>] [-DataIntegrityValidation <String>]
 [-Description <String>] [-ExecutionTimeHour <Int32>] [-ExecutionTimeMinute <Single>]
 [-ScheduleCronExpression <String>] [-ScheduleDaysOfMonth <Int32[]>] [-ScheduleDaysOfWeek <String[]>]
 [-ScheduleEndDate <DateTime>] [-ScheduleFrequency <String>] [-ScheduleIsActive]
 [-ScheduleStartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityStorageMoverExpanded
```
Update-AzStorageMoverJobDefinition -Name <String> -ProjectName <String>
 -StorageMoverInputObject <IStorageMoverIdentity> [-AgentName <String>] [-Connection <String[]>]
 [-CopyMode <String>] [-DataIntegrityValidation <String>] [-Description <String>] [-ExecutionTimeHour <Int32>]
 [-ExecutionTimeMinute <Single>] [-ScheduleCronExpression <String>] [-ScheduleDaysOfMonth <Int32[]>]
 [-ScheduleDaysOfWeek <String[]>] [-ScheduleEndDate <DateTime>] [-ScheduleFrequency <String>]
 [-ScheduleIsActive] [-ScheduleStartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update properties for a Job Definition resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update a job definition
```powershell
Update-AzStorageMoverJobDefinition -Name myJob -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Description "Update Description"
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  : Update description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob
LatestJobRunName             : 12345678-1234-1234-1234-111111111111
LatestJobRunResourceId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob/jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
LatestJobRunStatus           : Queued
Name                         : myJob
ProvisioningState            : Succeeded
SourceName                   : nfsEndpoint1
SourceResourceId             :
SourceSubpath                :
SystemDataCreatedAt          : 7/28/2022 5:47:29 AM
SystemDataCreatedBy          : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 3:09:15 AM
SystemDataLastModifiedBy     : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataLastModifiedByType : Application
TargetName                   : containerEndpoint1
TargetResourceId             :
TargetSubpath                :
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command updates the description of a job definition.

## PARAMETERS

### -AgentName
Name of the Agent to assign for new Job Runs of this Job Definition.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Connection
List of connections associated to this job

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CopyMode
Strategy to use for copy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataIntegrityValidation
Data Integrity Validation mode.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
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

### -Description
A description for the Job Definition.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExecutionTimeHour
The hour element of the time.
Allowed values range from 0 (start of the selected day) to 24 (end of the selected day).
Hour value 24 cannot be combined with any other minute value but 0.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExecutionTimeMinute
The minute element of the time.
Allowed values are 0 and 30.
If not specified, its value defaults to 0.

```yaml
Type: System.Single
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
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

### -Name
The name of the Job Definition resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: JobDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: UpdateViaIdentityProjectExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
The name of the Project resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityStorageMoverExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleCronExpression
Optional CRON expression for advanced scheduling

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDaysOfMonth
Days of the month for monthly schedules

```yaml
Type: System.Int32[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDaysOfWeek
Days of the week for weekly schedules

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleEndDate
End time of the schedule (in UTC)

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleFrequency
Type of schedule — Monthly, Weekly, or Daily

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleIsActive
Whether the schedule is currently active

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleStartDate
Specific one-time execution date and time

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProjectExpanded, UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMoverInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: UpdateViaIdentityStorageMoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageMoverName
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IJobDefinition

## NOTES

## RELATED LINKS

