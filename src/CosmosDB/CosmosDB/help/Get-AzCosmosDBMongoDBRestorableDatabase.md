---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# Get-AzCosmosDBMongoDBRestorableDatabase

## SYNOPSIS
Gets the list of all the restorable Azure Cosmos DB MongoDB databases available under the restorable account.

## SYNTAX

```
Get-AzCosmosDBMongoDBRestorableDatabase -LocationName <String> -DatabaseAccountInstanceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of all the restorable Azure Cosmos DB MongoDB databases available under the restorable account.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DatabaseAccountInstanceId
The instance Id of the CosmosDB database account.
(This is returned as a part of database account properties).

```yaml
Type: String
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationName
Name of the Location in string.

```yaml
Type: String
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

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableMongodbDatabaseGetResult

## NOTES

## RELATED LINKS
