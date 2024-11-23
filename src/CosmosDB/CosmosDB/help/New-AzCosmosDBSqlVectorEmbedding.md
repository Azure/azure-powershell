---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbsqlincludedpath
schema: 2.0.0
---

# New-AzCosmosDBSqlVectorEmbedding

## SYNOPSIS
Creates a new object of type PSVectorEmbedding. It can be passed as a parameter value for Set-AzCosmosDBSqlContainer.

## SYNTAX

```
New-AzCosmosDBSqlVectorEmbedding [-Path <String>] [-DataType <String>] [-DistanceFunction <String>] [-Dimensions  <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Object corresponding to Sql API's VectorEmbedding.

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBSqlVectorEmbedding -Path "/vector1" -DataType "float32" -DistanceFunction "dotproduct" -Dimensions 200
```

```output
Path DataType DistanceFunction Dimensions
---- -------- ---------------- ----------
/vector1    float32     dotproduct      200
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
### -DataType
Indicates the data type of vector.

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

### -DistanceFunction
The distance function to use for distance calculation in between vectors.

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

### -Dimensions
The number of dimensions in the vector.

```yaml
Type: System.Int32
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSIncludedPath

## NOTES

## RELATED LINKS
