---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbtablebackupinformation
schema: 2.0.0
---

# Get-AzCosmosDBTableBackupInformation

## SYNOPSIS
Retrieves the latest restorable timestamp for a table.

## SYNTAX

```
Get-AzCosmosDBTableBackupInformation -ResourceGroupName <String> -AccountName <String> -Name <String>
 -Location <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves the latest restorable timestamp for a table. This is the latest timestamp upto which user can successfully restore this table.

## EXAMPLES

### Example 1
```powershell
Get-AzCosmosDBTableBackupInformation -ResourceGroupName CosmosDBResourceGroup3668 -AccountName pitr-table-stage-source -Name TestTable1 -Location "EAST US 2"
```

```output
LatestRestorableTimestamp
-------------------------
1623032210
```

Retrieves the latest restorable timestamp for a table. This is the latest timestamp upto which user can successfully restore this table.

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Name of the Location in string.

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

### -Name
Name of the Table.

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
Name of resource group.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.Restore.PSTableBackupInformation

## NOTES

## RELATED LINKS
