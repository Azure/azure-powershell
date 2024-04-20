---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azstorageblobdestinationobject
schema: 2.0.0
---

# New-AzStorageBlobDestinationObject

## SYNOPSIS
Create an in-memory object for StorageBlobDestination.

## SYNTAX

```
New-AzStorageBlobDestinationObject [-ContainerName <String>] [-Name <String>]
 [-StorageAccountResourceId <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageBlobDestination.

## EXAMPLES

### Example 1: Create storage blob destination object
```powershell
New-AzStorageBlobDestinationObject -ContainerName "my-logs" -StorageAccountResourceId /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/sa-rg/providers/Microsoft.Storage/storageAccounts/rightregion:westus:sa-name1 -Name storageAccountDestination1
```

```output
ContainerName Name                       StorageAccountResourceId
------------- ----                       ------------------------
my-logs       storageAccountDestination1 /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/sa-rg/providers/Microsoft.Storage/storageAccounts/rightregion:westus:sa-name1
```

This command creates a storage blob destination object.

## PARAMETERS

### -ContainerName
The container name of the Storage Blob.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.StorageBlobDestination

## NOTES

## RELATED LINKS
