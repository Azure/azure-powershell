---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragetaskassignment
schema: 2.0.0
---

# Get-AzStorageTaskAssignment

## SYNOPSIS
Get the storage task assignment properties

## SYNTAX

### List (Default)
```
Get-AzStorageTaskAssignment -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageTaskAssignment -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityStorageAccount
```
Get-AzStorageTaskAssignment -Name <String> -StorageAccountInputObject <IStorageIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageTaskAssignment -InputObject <IStorageIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the storage task assignment properties

## EXAMPLES

### Example 1: Get a task assignment
```powershell
Get-AzStorageTaskAssignment -ResourceGroupName myresourcegroup -AccountName myaccount -Name myassignment
```

```output
Description                     : This is a task assignment
Enabled                         : True
EndBy                           : 7/2/2025 6:17:38 AM
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/myassignment
Interval                        : 1
IntervalUnit                    : days
Name                            : myassignment
ProvisioningState               : Succeeded
ReportPrefix                    : testc1
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
StartFrom                       : 7/2/2024 6:17:38 AM
StartOn                         :
TargetExcludePrefix             : {}
TargetPrefix                    : {test}
TaskId                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mystoragetask1
TriggerType                     : OnSchedule
Type                            : Microsoft.Storage/storageAccounts/storageTaskAssignments
```

This command gets the task assignment "myassignment" under storage account "myaccount".

### Example 2: List task assignments under a storage account
```powershell
Get-AzStorageTaskAssignment -ResourceGroupName myresourcegroup -AccountName myaccount
```

```output
Name              ResourceGroupName
----              -----------------
assignment1       myresourcegroup
assignment2       myresourcegroup
assignment3       myresourcegroup
```

This command lists task assignments under the storage account "myaccount".

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: List, Get
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

### -Name
The name of the storage task assignment within the specified resource group.
Storage task assignment names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityStorageAccount
Aliases: StorageTaskAssignmentName

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
Parameter Sets: List, Get
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Optional, specifies the maximum number of storage task assignment Ids to be included in the list response.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases: Maxpagesize

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
