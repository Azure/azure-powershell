---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbcopyjob
schema: 2.0.0
---

# New-AzCosmosDBCopyJob

## SYNOPSIS
Creates a new Azure Cosmos DB container copy job.

## SYNTAX

### SqlParameterSet (Default)
```
New-AzCosmosDBCopyJob -ResourceGroupName <String> -SourceAccountName <String>
 [-DestinationAccountName <String>] [-JobName <String>] -SourceSqlDatabaseName <String>
 -SourceSqlContainerName <String> -DestinationSqlDatabaseName <String> -DestinationSqlContainerName <String>
 [-Mode <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CassandraParameterSet
```
New-AzCosmosDBCopyJob -ResourceGroupName <String> -SourceAccountName <String>
 [-DestinationAccountName <String>] [-JobName <String>] -SourceKeyspaceName <String> -SourceTableName <String>
 -DestinationKeyspaceName <String> -DestinationTableName <String> [-Mode <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MongoParameterSet
```
New-AzCosmosDBCopyJob -ResourceGroupName <String> -SourceAccountName <String>
 [-DestinationAccountName <String>] [-JobName <String>] -SourceMongoDatabaseName <String>
 -SourceCollectionName <String> -DestinationMongoDatabaseName <String> -DestinationCollectionName <String>
 [-Mode <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Azure Cosmos DB container copy job to copy data between containers. Supports SQL (NoSQL), Cassandra, and MongoDB API types. Copy jobs can be within the same account or across accounts, and can run in Online or Offline mode.

## EXAMPLES

### Example 1: Create a SQL (NoSQL) container copy job within the same account
```powershell
New-AzCosmosDBCopyJob -ResourceGroupName "myRG" -SourceAccountName "myAccount" -SourceSqlDatabaseName "sourceDb" -SourceSqlContainerName "sourceContainer" -DestinationSqlDatabaseName "destDb" -DestinationSqlContainerName "destContainer"
```

Creates a copy job to copy data from sourceDb/sourceContainer to destDb/destContainer within the same Cosmos DB account.

### Example 2: Create a cross-account SQL copy job
```powershell
New-AzCosmosDBCopyJob -ResourceGroupName "myRG" -SourceAccountName "sourceAccount" -DestinationAccountName "destAccount" -SourceSqlDatabaseName "sourceDb" -SourceSqlContainerName "sourceContainer" -DestinationSqlDatabaseName "destDb" -DestinationSqlContainerName "destContainer" -Mode "Online"
```

Creates an online copy job to copy data from a source account to a destination account.

### Example 3: Create a Cassandra copy job
```powershell
New-AzCosmosDBCopyJob -ResourceGroupName "myRG" -SourceAccountName "myAccount" -SourceKeyspaceName "sourceKs" -SourceTableName "sourceTable" -DestinationKeyspaceName "destKs" -DestinationTableName "destTable"
```

Creates a copy job for Cassandra API containers.

## PARAMETERS

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

### -DestinationAccountName
Name of the Azure Cosmos DB destination database account.
Defaults to source account if not specified.

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

### -DestinationCollectionName
Name of the destination MongoDB collection.

```yaml
Type: String
Parameter Sets: MongoParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationKeyspaceName
Name of the destination Cassandra keyspace.

```yaml
Type: String
Parameter Sets: CassandraParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationMongoDatabaseName
Name of the destination MongoDB database.

```yaml
Type: String
Parameter Sets: MongoParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationSqlContainerName
Name of the destination container.

```yaml
Type: String
Parameter Sets: SqlParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationSqlDatabaseName
Name of the destination database.

```yaml
Type: String
Parameter Sets: SqlParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationTableName
Name of the destination Cassandra table.

```yaml
Type: String
Parameter Sets: CassandraParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobName
Name of the Copy Job.
A random job name will be generated if not passed.

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

### -Mode
Mode of the copy job.
Possible values: 'Online', 'Offline'.
Default is 'Offline'.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Online, Offline

Required: False
Position: Named
Default value: Offline
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

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

### -SourceAccountName
Name of the Azure Cosmos DB source database account.

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

### -SourceCollectionName
Name of the source MongoDB collection.

```yaml
Type: String
Parameter Sets: MongoParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceKeyspaceName
Name of the source Cassandra keyspace.

```yaml
Type: String
Parameter Sets: CassandraParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceMongoDatabaseName
Name of the source MongoDB database.

```yaml
Type: String
Parameter Sets: MongoParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSqlContainerName
Name of the source container.

```yaml
Type: String
Parameter Sets: SqlParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSqlDatabaseName
Name of the source database.

```yaml
Type: String
Parameter Sets: SqlParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceTableName
Name of the source Cassandra table.

```yaml
Type: String
Parameter Sets: CassandraParameterSet
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSCopyJobGetResults

## NOTES

## RELATED LINKS
