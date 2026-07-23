---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbsqlvectorembeddingpolicy
schema: 2.0.0
---

# New-AzCosmosDBSqlVectorEmbeddingPolicy

## SYNOPSIS
Creates a new CosmosDB Sql VectorEmbeddingPolicy object.

## SYNTAX

```
New-AzCosmosDBSqlVectorEmbeddingPolicy -VectorEmbedding <PSVectorEmbedding[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDBSqlVectorEmbeddingPolicy** cmdlet creates a new object of type PSSqlVectorEmbeddingPolicy.

## EXAMPLES

### Example 1
```powershell
$VectorEmbedding = New-AzCosmosDBSqlVectorEmbedding -Path "/vector1" -DataType "float32" -DistanceFunction "dotproduct" -Dimensions 200
New-AzCosmosDBSqlVectorEmbeddingPolicy -VectorEmbedding $VectorEmbedding
```

```output
VectorEmbeddings    : {Microsoft.Azure.Commands.CosmosDB.Models.PSVectorEmbedding}
```

## PARAMETERS

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

### -VectorEmbedding
Array of objects of type Microsoft.Azure.Commands.CosmosDB.Models.PSSqlVectorEmbedding (Represents a vector embedding. A vector embedding is used to define a vector field in the documents).

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSVectorEmbedding[]
Parameter Sets: (All)
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlVectorEmbeddingPolicy

## NOTES

## RELATED LINKS
