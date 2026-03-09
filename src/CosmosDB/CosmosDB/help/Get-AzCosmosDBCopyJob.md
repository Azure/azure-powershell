---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbcopyjob
schema: 2.0.0
---

# Get-AzCosmosDBCopyJob

## SYNOPSIS
Gets or lists Azure Cosmos DB container copy jobs.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBCopyJob -ResourceGroupName <String> -AccountName <String> [-JobName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBCopyJob [-JobName <String>] -ParentObject <PSDatabaseAccountGetResults>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets a specific copy job by name or lists all copy jobs for a Cosmos DB account.

## EXAMPLES

### Example 1: Get a specific copy job
```powershell
Get-AzCosmosDBCopyJob -ResourceGroupName "myRG" -AccountName "myAccount" -JobName "myJob"
```

Gets the details of the specified copy job.

### Example 2: List all copy jobs
```powershell
Get-AzCosmosDBCopyJob -ResourceGroupName "myRG" -AccountName "myAccount"
```

Lists all copy jobs for the specified Cosmos DB account.

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

```yaml
Type: String
Parameter Sets: ByNameParameterSet
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

### -JobName
Name of the Copy Job. If not specified, all copy jobs for the account are listed.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
CosmosDB Account object

```yaml
Type: PSDatabaseAccountGetResults
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

```yaml
Type: String
Parameter Sets: ByNameParameterSet
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseAccountGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSCopyJobGetResults

## NOTES

## RELATED LINKS
