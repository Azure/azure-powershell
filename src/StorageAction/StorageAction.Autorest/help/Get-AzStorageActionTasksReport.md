---
external help file:
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/az.storageaction/get-azstorageactiontasksreport
schema: 2.0.0
---

# Get-AzStorageActionTasksReport

## SYNOPSIS
Fetch the storage tasks run report summary for each assignment.

## SYNTAX

```
Get-AzStorageActionTasksReport -ResourceGroupName <String> -StorageTaskName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Maxpagesize <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Fetch the storage tasks run report summary for each assignment.

## EXAMPLES

### Example 1: Get report
```powershell
Get-AzStorageActionTasksReport -ResourceGroupName group001 -StorageTaskName mytask1 | Format-List
```

```output
FinishTime                   : 2024-02-28T10:16:58.9261483Z
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1/reports/instance1
Name                         : instance1
ObjectFailedCount            : 0
ObjectsOperatedOnCount       : 0
ObjectsSucceededCount        : 0
ObjectsTargetedCount         : 1
RunResult                    : Succeeded
RunStatusEnum                : Finished
RunStatusError               : 0x0
StartTime                    : 2024-02-28T10:07:53.0000000Z
StorageAccountId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001
SummaryReportPath            : https://account001.blob.core.windows.net/rrrr/mytask1/testassign1/2024-02-28T10:08:00/SummaryReport.json
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TaskAssignmentId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001/storageTaskAssignments/testassign1
TaskId                       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1 
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks/reports

FinishTime                   : 2024-02-28T10:31:54.7848950Z
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1/reports/instance2
Name                         : instance2
ObjectFailedCount            : 0
ObjectsOperatedOnCount       : 0
ObjectsSucceededCount        : 0
ObjectsTargetedCount         : 1
RunResult                    : Succeeded
RunStatusEnum                : Finished
RunStatusError               : 0x0
StartTime                    : 2024-02-28T10:21:53.0000000Z
StorageAccountId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001
SummaryReportPath            : https://account001.blob.core.windows.net/rrrr/mytask1/testassign2/2024-02-28T10:22:05/SummaryReport.json
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TaskAssignmentId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001/storageTaskAssignments/testassign2
TaskId                       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1 
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks/reports
```

This command get assignments report.

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

### -Filter
Optional.
When specified, it can be used to query using reporting properties.

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

### -Maxpagesize
Optional, specifies the maximum number of Storage Task Assignment Resource IDs to be included in the list response.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageTaskName
The name of the storage task within the specified resource group.
Storage task names must be between 3 and 18 characters in length and use numbers and lower-case letters only.

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
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskReportInstance

## NOTES

## RELATED LINKS

