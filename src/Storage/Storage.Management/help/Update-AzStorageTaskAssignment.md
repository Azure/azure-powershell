---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/update-azstoragetaskassignment
schema: 2.0.0
---

# Update-AzStorageTaskAssignment

## SYNOPSIS
Update storage task assignment properties

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageTaskAssignment -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Description <String>] [-Enabled] [-EndBy <DateTime>] [-Interval <Int32>]
 [-IntervalUnit <String>] [-ReportPrefix <String>] [-StartFrom <DateTime>] [-StartOn <DateTime>]
 [-TargetExcludePrefix <String[]>] [-TargetPrefix <String[]>] [-TriggerType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityStorageAccountExpanded
```
Update-AzStorageTaskAssignment -Name <String> -StorageAccountInputObject <IStorageIdentity>
 [-Description <String>] [-Enabled] [-EndBy <DateTime>] [-Interval <Int32>] [-IntervalUnit <String>]
 [-ReportPrefix <String>] [-StartFrom <DateTime>] [-StartOn <DateTime>] [-TargetExcludePrefix <String[]>]
 [-TargetPrefix <String[]>] [-TriggerType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageTaskAssignment -InputObject <IStorageIdentity> [-Description <String>] [-Enabled]
 [-EndBy <DateTime>] [-Interval <Int32>] [-IntervalUnit <String>] [-ReportPrefix <String>]
 [-StartFrom <DateTime>] [-StartOn <DateTime>] [-TargetExcludePrefix <String[]>] [-TargetPrefix <String[]>]
 [-TriggerType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update storage task assignment properties

## EXAMPLES

### Example 1: Update a task assignment
```powershell
$start = Get-Date -Year 2024 -Month 8 -Day 7 -Hour 1 -Minute 30
$end = Get-Date -Year 2024 -Month 12 -Day 25 -Hour 2 -Minute 45
Update-AzStorageTaskAssignment -accountname myaccount -name mytaskassignment -resourcegroupname myresourcegroup -StartFrom $start.ToUniversalTime() -EndBy $end.ToUniversalTime() -Interval 7 -Description "update task assignment" -Enabled
```

```output
Description                     : update task assignment
Enabled                         : True
EndBy                           : 12/24/2024 6:45:03 PM
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment
Interval                        : 7
IntervalUnit                    : days
Name                            : mytaskassignment
ProvisioningState               : Succeeded
ReportPrefix                    : test
ResourceGroupName               : myresourcegroup
RunStatusEnum                   :
RunStatusError                  :
RunStatusFinishTime             :
RunStatusObjectFailedCount      :
RunStatusObjectsOperatedOnCount :
RunStatusObjectsSucceededCount  :
RunStatusObjectsTargetedCount   :
RunStatusRunResult              :
RunStatusStartTime              :
RunStatusStorageAccountId       :
RunStatusSummaryReportPath      :
RunStatusTaskAssignmentId       :
RunStatusTaskId                 :
RunStatusTaskVersion            :
StartFrom                       : 8/6/2024 5:30:39 PM
StartOn                         :
TargetExcludePrefix             :
TargetPrefix                    :
TaskId                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TriggerType                     : OnSchedule
Type                            : Microsoft.Storage/storageAccounts/storageTaskAssignments
```

This command updates the interval, start time, end time, and description of a task assignment, and enables the task assignment.

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
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
Text that describes the purpose of the storage task assignment

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

### -Enabled
Whether the storage task assignment is enabled or not

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

### -EndBy
When to end task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Interval
Run interval of task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntervalUnit
Run interval unit of task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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
The name of the storage task assignment within the specified resource group.
Storage task assignment names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityStorageAccountExpanded
Aliases: StorageTaskAssignmentName

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

### -ReportPrefix
The prefix of the storage task assignment report

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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartFrom
When to start task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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

### -StartOn
When to start task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'RunOnce'; this property should not be present when ExecutionTrigger.properties.type is 'OnSchedule'

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

### -StorageAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: UpdateViaIdentityStorageAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetExcludePrefix
List of object prefixes to be excluded from task execution.
If there is a conflict between include and exclude prefixes, the exclude prefix will be the determining factor

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

### -TargetPrefix
Required list of object prefixes to be included for task execution

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

### -TriggerType
The trigger type of the storage task assignment execution

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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageTaskAssignment

## NOTES

## RELATED LINKS
