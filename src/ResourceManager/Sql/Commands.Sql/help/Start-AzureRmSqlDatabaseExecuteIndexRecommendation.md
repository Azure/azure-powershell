---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
ms.assetid: 0EA0B131-A3D0-43CA-8517-9E724A11B04F
online version: 
schema: 2.0.0
---

# Start-AzureRmSqlDatabaseExecuteIndexRecommendation

## SYNOPSIS
Starts the workflow that runs a recommended index operation.

## SYNTAX

```
Start-AzureRmSqlDatabaseExecuteIndexRecommendation -ServerName <String> -DatabaseName <String>
 -IndexRecommendationName <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmSqlDatabaseExecuteIndexRecommendation** cmdlet starts the workflow that runs a recommended index operation for an Azure SQL Database.

## EXAMPLES

### Example 1: Run an index recommendation
```
PS C:\>Start-AzureRmSqlDatabaseExecuteIndexRecommendation -ResourceGroup "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -IndexRecommendationName "INDEX_NAME"
```

This command runs an index recommendation.

## PARAMETERS

### -DatabaseName
Specifies the name of the database for which this cmdlet starts the workflow.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IndexRecommendationName
Specifies the name of the index recommendation that this cmdlet runs.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group to which the server is assigned.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
Specifies the server that hosts the database for which this cmdlet starts a workflow.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmSqlDatabaseIndexRecommendations](./Get-AzureRmSqlDatabaseIndexRecommendations.md)

[Stop-AzureRmSqlDatabaseExecuteIndexRecommendation](./Stop-AzureRmSqlDatabaseExecuteIndexRecommendation.md)

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)


