---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/resume-azcosmosdbcopyjob
schema: 2.0.0
---

# Resume-AzCosmosDBCopyJob

## SYNOPSIS
Resumes a paused Azure Cosmos DB container copy job.

## SYNTAX

### ByNameParameterSet (Default)
```
Resume-AzCosmosDBCopyJob -ResourceGroupName <String> -AccountName <String> -JobName <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Resume-AzCosmosDBCopyJob -JobName <String> -ParentObject <PSDatabaseAccountGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Resumes an Azure Cosmos DB container copy job that was previously paused using Suspend-AzCosmosDBCopyJob.

## EXAMPLES

### Example 1: Resume a paused copy job
```powershell
Resume-AzCosmosDBCopyJob -ResourceGroupName "myRG" -AccountName "myAccount" -JobName "myJob"
```

Resumes the specified paused copy job.

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
Name of the Copy Job.

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
Name of the resource group containing the Cosmos DB account.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseAccountGetResults

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[New-AzCosmosDBCopyJob](New-AzCosmosDBCopyJob.md)

[Get-AzCosmosDBCopyJob](Get-AzCosmosDBCopyJob.md)

[Complete-AzCosmosDBCopyJob](Complete-AzCosmosDBCopyJob.md)

[Stop-AzCosmosDBCopyJob](Stop-AzCosmosDBCopyJob.md)

[Suspend-AzCosmosDBCopyJob](Suspend-AzCosmosDBCopyJob.md)
