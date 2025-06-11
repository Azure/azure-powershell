---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragetaskassignmentinstancesreport
schema: 2.0.0
---

# Get-AzStorageTaskAssignmentInstancesReport

## SYNOPSIS
Fetch the report summary of a single storage task assignment's instances

## SYNTAX

### List (Default)
```
Get-AzStorageTaskAssignmentInstancesReport -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Maxpagesize <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzStorageTaskAssignmentInstancesReport -AccountName <String> -ResourceGroupName <String>
 -StorageTaskAssignmentName <String> [-SubscriptionId <String[]>] [-Filter <String>] [-Maxpagesize <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageTaskAssignmentInstancesReport -InputObject <IStorageIdentity> [-Filter <String>]
 [-Maxpagesize <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityStorageAccount
```
Get-AzStorageTaskAssignmentInstancesReport -StorageAccountInputObject <IStorageIdentity>
 -StorageTaskAssignmentName <String> [-Filter <String>] [-Maxpagesize <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Fetch the report summary of a single storage task assignment's instances

## EXAMPLES

### Example 1: List the reports of a task assignment in an account
```powershell
Get-AzStorageTaskAssignmentInstancesReport -AccountName myaccount -ResourceGroupName myresourcegroup -StorageTaskAssignmentName mytaskassignment
```

```output
FinishTime             : 2024-07-02T08:19:51.9238839Z
Id                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment/reports/instance1
Name                   : instance1
ObjectFailedCount      : 0
ObjectsOperatedOnCount : 0
ObjectsSucceededCount  : 0
ObjectsTargetedCount   : 0
RunResult              : Succeeded
RunStatusEnum          : Finished
RunStatusError         : 0x0
StartTime              : 2024-07-02T08:10:55.0000000Z
StorageAccountId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount
SummaryReportPath      : https://myaccount.blob.core.windows.net/testc2/mytask/assignment1/2024-07-02T08:11:20/SummaryReport.json
TaskAssignmentId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment
TaskId                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TaskVersion            : 1
Type                   : Microsoft.Storage/storageAccounts/storageTaskAssignments/reports
```

This command lists the reports of task assignment "mytaskassignment".

### Example 2: List the reports of all storage task assignments and instances in an account
```powershell
Get-AzStorageTaskAssignmentInstancesReport -AccountName myaccount -ResourceGroupName myresourcegroup
```

```output
FinishTime             : 2024-07-03T08:19:23.1774164Z
Id                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/reports/instance1
Name                   : instance1
ObjectFailedCount      : 0
ObjectsOperatedOnCount : 0
ObjectsSucceededCount  : 0
ObjectsTargetedCount   : 0
RunResult              : Succeeded
RunStatusEnum          : Finished
RunStatusError         : 0x0
StartTime              : 2024-07-03T08:10:11.0000000Z
StorageAccountId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount
SummaryReportPath      : https://myaccount.blob.core.windows.net/testc2/mytask/mytaskassignment/2024-07-03T08:10:41/SummaryReport.json
TaskAssignmentId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment
TaskId                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TaskVersion            : 1
Type                   : Microsoft.Storage/storageAccounts/reports

FinishTime             : 2024-07-02T08:19:51.9238839Z
Id                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/reports/instance2
Name                   : instance2
ObjectFailedCount      : 0
ObjectsOperatedOnCount : 0
ObjectsSucceededCount  : 0
ObjectsTargetedCount   : 0
RunResult              : Succeeded
RunStatusEnum          : Finished
RunStatusError         : 0x0
StartTime              : 2024-07-02T08:10:55.0000000Z
StorageAccountId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount
SummaryReportPath      : https://myaccount.blob.core.windows.net/testc2/mytaskassignment2/assignment1/2024-07-02T08:11:20/SummaryReport.json
TaskAssignmentId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment2
TaskId                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TaskVersion            : 1
Type                   : Microsoft.Storage/storageAccounts/reports
```

This command lists the reports of all storage task assignments and instances under storage account "myaccount".

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
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

### -Filter
Optional.
When specified, it can be used to query using reporting properties.
See [Constructing Filter Strings](https://learn.microsoft.com/rest/api/storageservices/querying-tables-and-entities#constructing-filter-strings) for details.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
Optional, specifies the maximum number of storage task assignment instances to be included in the list response.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: GetViaIdentityStorageAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageTaskAssignmentName
The name of the storage task assignment within the specified resource group.
Storage task assignment names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityStorageAccount
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageTaskReportInstance

## NOTES

## RELATED LINKS

