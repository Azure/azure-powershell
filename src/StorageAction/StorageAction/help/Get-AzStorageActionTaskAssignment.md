---
external help file: Az.StorageAction-help.xml
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/az.storageaction/get-azstorageactiontaskassignment
schema: 2.0.0
---

# Get-AzStorageActionTaskAssignment

## SYNOPSIS
Lists Resource IDs of the Storage Task Assignments associated with this Storage Task.

## SYNTAX

```
Get-AzStorageActionTaskAssignment -ResourceGroupName <String> -StorageTaskName <String>
 [-SubscriptionId <String[]>] [-Maxpagesize <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists Resource IDs of the Storage Task Assignments associated with this Storage Task.

## EXAMPLES

### Example 1: Lists all the storage tasks
```powershell
Get-AzStorageActionTaskAssignment -ResourceGroupName group001 -StorageTaskName mytask1 | Format-List
```

```output
Id : subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/group001/providers/microsoft.storage/storageaccounts/account001/storagetaskassignments/testassign1

Id : subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/group001/providers/microsoft.storage/storageaccounts/account001/storagetaskassignments/testassign2
```

This command lists all the storage task assignments.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskAssignment

## NOTES

## RELATED LINKS
