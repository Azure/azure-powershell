---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbsqlvectorindex
schema: 2.0.0
---

# New-AzCosmosDBSqlVectorIndex

## SYNOPSIS
Creates a new CosmosDB Sql VectorIndex object. 

## SYNTAX

```
New-AzCosmosDBSqlVectorIndex -Path <String> -Type <String> -QuantizationByteSize <Int64> -IndexingSearchListSize <Int64> -VectorIndexShardKey <String[]> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDBSqlVectorIndex** cmdlet creates a new object of type PSSqlVectorIndex.

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBSqlVectorIndex -Path "/vector1" -Type "flat"
```

```output
Path Type
---- ----
/vector1   flat
```

### Example 2
```powershell
New-AzCosmosDBSqlVectorIndex -Path "/vector1" -Type "flat" -QuantizationByteSize 128 -IndexingSearchListSize 50 -VectorIndexShardKey "shard1","shard2"
```

```output
Path       Type     QuantizationByteSize IndexingSearchListSize VectorIndexShardKey
----       ----     --------------------- ---------------------- -------------------
/vector1   flat     128                   50                     shard1, shard2
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

### -Path
The path to the vector field in the document.

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

### -Type
The index type of the vector. Currently, flat, diskANN, and quantizedFlat are supported.

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

### -QuantizationByteSize
The number of bytes used in product quantization of the vectors. A larger value may result in better recall for vector searches at the expense of latency. This is only applicable for the quantizedFlat and diskANN vector index types.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IndexingSearchListSize
This is the size of the candidate list of approximate neighbors stored while building the DiskANN index as part of the optimization processes. Large values may improve recall at the expense of latency. This is only applicable for the diskANN vector index type.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VectorIndexShardKey
Array of shard keys for the vector index. This is only applicable for the quantizedFlat and diskANN vector index types.

```yaml
Type: System.Collections.Generic.IList[string]
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlVectorIndex

## NOTES

## RELATED LINKS
