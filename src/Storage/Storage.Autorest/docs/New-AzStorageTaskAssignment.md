---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azstoragetaskassignment
schema: 2.0.0
---

# New-AzStorageTaskAssignment

## SYNOPSIS
Asynchronously create a new storage task assignment sub-resource with the specified parameters.
If a storage task assignment is already created and a subsequent create request is issued with different properties, the storage task assignment properties will be updated.
If a storage task assignment is already created and a subsequent create request is issued with the exact same set of properties, the request will succeed.

## SYNTAX

```
New-AzStorageTaskAssignment -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Description <String> -Enabled -ReportPrefix <String> -TaskId <String> -TriggerType <String>
 [-SubscriptionId <String>] [-EndBy <DateTime>] [-Interval <Int32>] [-IntervalUnit <String>]
 [-StartFrom <DateTime>] [-StartOn <DateTime>] [-TargetExcludePrefix <String[]>] [-TargetPrefix <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously create a new storage task assignment sub-resource with the specified parameters.
If a storage task assignment is already created and a subsequent create request is issued with different properties, the storage task assignment properties will be updated.
If a storage task assignment is already created and a subsequent create request is issued with the exact same set of properties, the request will succeed.

## EXAMPLES

### Example 1: Create a task assignment that runs once 
```powershell
$taskid = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask"
New-AzStorageTaskAssignment -ResourceGroupName myresourcegroup -AccountName myaccount -name mytaskassignment -TaskId $taskid -ReportPrefix "test" -TriggerType RunOnce -StartOn (Get-Date).ToUniversalTime() -Description "task assignment" -Enabled:$false
```

```output
Description                     : task assignment
Enabled                         : False
EndBy                           :
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment
Interval                        :
IntervalUnit                    :
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
StartFrom                       :
StartOn                         : 7/2/2024 4:39:15 AM
TargetExcludePrefix             :
TargetPrefix                    :
TaskId                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TriggerType                     : RunOnce
Type                            : Microsoft.Storage/storageAccounts/storageTaskAssignments
```

This command creates a task assignment that runs once.

### Example 2: Create a task assignment that runs on schedule
```powershell
$start = Get-Date -Year 2024 -Month 8 -Day 7 -Hour 1 -Minute 30
$end = Get-Date -Year 2024 -Month 12 -Day 25 -Hour 2 -Minute 45
$taskid = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask"
New-AzStorageTaskAssignment -accountname myaccount -name mytaskassignment -resourcegroupname myresourcegroup -TaskId $taskid -ReportPrefix test -StartFrom $start.ToUniversalTime() -TriggerType OnSchedule -Interval 10 -IntervalUnit Days -Description "my task assignment" -Enabled:$false -EndBy $end.ToUniversalTime()
```

```output
Description                     : my task assignment
Enabled                         : False
EndBy                           : 12/24/2024 6:45:03 PM
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/myassignment
Interval                        : 10
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
TaskId                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/
                                  mytask
TriggerType                     : OnSchedule
Type                            : Microsoft.Storage/storageAccounts/storageTaskAssignments
```

This command creates a task assignment that runs every 10 days from 8/6/2024 5:30:39 PM to 12/24/2024 6:45:03 PM.

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

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

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndBy
When to end task execution.
This is a required field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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

### -Interval
Run interval of task execution.
This is a required field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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
This is a required field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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
Parameter Sets: (All)
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
The container prefix for the location of storage task assignment report

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -StartFrom
When to start task execution.
This is a required field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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
This is a required field when ExecutionTrigger.properties.type is 'RunOnce'; this property should not be present when ExecutionTrigger.properties.type is 'OnSchedule'

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

### -SubscriptionId
The ID of the target subscription.

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

### -TaskId
Id of the corresponding storage task

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

### -TriggerType
The trigger type of the storage task assignment execution

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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageTaskAssignment

## NOTES

## RELATED LINKS

