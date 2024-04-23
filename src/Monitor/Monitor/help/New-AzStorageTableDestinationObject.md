---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azstoragetabledestinationobject
schema: 2.0.0
---

# New-AzStorageTableDestinationObject

## SYNOPSIS
Create an in-memory object for StorageTableDestination.

## SYNTAX

```
New-AzStorageTableDestinationObject [-Name <String>] [-StorageAccountResourceId <String>] [-TableName <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageTableDestination.

## EXAMPLES

### Example 1: Create storage table destination object
```powershell
New-AzStorageTableDestinationObject -TableName table1 -StorageAccountResourceId /subscriptions/ee63c5dc-9b88-42e3-8070-944a5226aea3/resourceGroups/rightregion/providers/Microsoft.Storage/storageAccounts/bar1 -Name storageAccountDestination2
```

```output
Name                       StorageAccountResourceId                                                                                                        TableName
----                       ------------------------                                                                                                        ---------
storageAccountDestination2 /subscriptions/ee63c5dc-9b88-42e3-8070-944a5226aea3/resourceGroups/rightregion/providers/Microsoft.Storage/storageAccounts/bar1 table1
```

This command creates a storage table destination object.

## PARAMETERS

### -Name
A friendly name for the destination.
        This name should be unique across all destinations (regardless of type) within the data collection rule.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountResourceId
The resource ID of the storage account.

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

### -TableName
The name of the Storage Table.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.StorageTableDestination

## NOTES

## RELATED LINKS
