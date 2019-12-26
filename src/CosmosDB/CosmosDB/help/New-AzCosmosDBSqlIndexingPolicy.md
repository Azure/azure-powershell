---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/en-us/powershell/module/az.cosmosdb/new-azcosmosdbsqlindexingpolicy
schema: 2.0.0
---

# New-AzCosmosDBSqlIndexingPolicy

## SYNOPSIS
Creates a new CosmosDB Sql IndexingPolicy object.

## SYNTAX

```
New-AzCosmosDBSqlIndexingPolicy [-IncludedPath <String[]>] [-ExcludedPath <String[]>] [-Automatic <Boolean>]
 [-IndexingMode <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDBSqlIndexingPolicy** cmdlet creates a new object of type PSSqlIndexingPolicy.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzCosmosDBSqlIndexingPolicy -IncludedPath {includedPath1},{includedPath2},{includedPath3} -ExcludedPath {excludedPath1},{excludedPath2},{excludedPath3} -IndexingMode {indexingMode}

Automatic IndexingMode IncludedPaths                                    ExcludedPaths
--------- ------------ -------------                                    -------------
          k            {includedPath1, includedPath2, includedPath3}    {excludedPath1}

```

## PARAMETERS

### -Automatic
Bool to indicate if the indexing policy is automatic

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
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

### -ExcludedPath
Array of strings containing excludedPath(Specifies a path within a JSON document to be excluded in the Azure Cosmos DB service.)  elements.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedPath
Array of strings containing includedPath (Specifies a path within a JSON document to be included in the Azure Cosmos DB service.) elements.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IndexingMode
indicates the indexing mode.
Possible values include: 'Consistent', 'Lazy', 'None'

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlIndexingPolicy

## NOTES

## RELATED LINKS
