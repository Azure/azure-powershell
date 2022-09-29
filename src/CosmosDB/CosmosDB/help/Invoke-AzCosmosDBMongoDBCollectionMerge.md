---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# Invoke-AzCosmosDBMongoDBCollectionMerge

## SYNOPSIS
Invoke Merge for the specified MongoDB collection.

## SYNTAX

### ByNameParameterSet (Default)
```
Invoke-AzCosmosDBMongoDBCollectionMerge -ResourceGroupName <String> [-Name <String>] [-Force]
 [-DefaultProfile <IAzureContextContainer>] -AccountName <String> -DatabaseName <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Invoke-AzCosmosDBMongoDBCollectionMerge [-Name <String>] -ParentObject <PSSqlDatabaseGetResults> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Invoke-AzCosmosDBMongoDBCollectionMerge [-Name <String>] -InputObject <PSSqlContainerGetResults> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet merges the partitions of a MongoDB collection.

## EXAMPLES

### Example 1
```powershell
Invoke-AzCosmosDBMongoDBCollectionMerge -ResourceGroupName "resourceGroupName" -AccountName "accountName" -DatabaseName "databaseName" -Name "name"
```

```output
Id                  StorageInKB
---                 ------------
targetpartition0    100
targetpartition1    100
targetpartition2    100
targetpartition3    100
```

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
Database name.

```yaml
Type: System.String
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Skips prompt Confirmation of the command.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Mongo Collection object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlContainerGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Collection name.

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

### -ParentObject
Mongo Database object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults
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
Type: System.String
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlContainerGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSPhysicalPartitionStorageInfo

## NOTES

## RELATED LINKS
