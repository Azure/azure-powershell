---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/update-azmanagedcassandradatacenter
schema: 2.0.0
---

# Update-AzManagedCassandraDataCenter

## SYNOPSIS
Update an existing Azure Managed Instances for Apache Cassandra data center.

## SYNTAX

### NameParameterSet (Default)
```
Update-AzManagedCassandraDataCenter 
 -ResourceGroupName <String> 
 -ClusterName <String>
 -DataCenterName <String>
 [-NodeCount <int>]
 [-Tag <Hashtable>]
 [-Base64EncodedCassandraYamlFragment <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzManagedCassandraDataCenter 
 -ResourceId <String> 
 [-NodeCount <int>]
 [-Tag <Hashtable>]
 [-Base64EncodedCassandraYamlFragment <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ObjectParameterSet
```
Update-AzManagedCassandraDataCenter 
 -InputObject <PSDataCenterResource> 
 [-NodeCount <int>]
 [-Tag <Hashtable>]
 [-Base64EncodedCassandraYamlFragment <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ParentObjectParameterSet
```
Update-AzManagedCassandraDataCenter 
 -ParentObject <PSClusterResource>
 -DataCenterName <String>
 [-NodeCount <int>]
 [-Tag <Hashtable>]
 [-Base64EncodedCassandraYamlFragment <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzManagedCassandraDataCenter** cmdlet updates an existing managed Cassandra data center.

## EXAMPLES

### Example 1
```powershell
Update-AzManagedCassandraDataCenter `
 -ResourceGroupName {resourceGroupName} `
 -ClusterName {clusterName} `
 -DataCenterName {dataCenterName} `
 -NodeCount {N}
```

## PARAMETERS

### -Base64EncodedCassandraYamlFragment
Fragment of configuration to include in `cassandra.yaml` on nodes of this data center, Base64 encoded.

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

### -ClusterName
Name of the managed Cassandra cluster.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
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

### -NodeCount
The number of nodes to create in this data center.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: 3
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Cassandra cluster object to create a data center in.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource
Parameter Sets: ParentObjectParameterSet
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
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Hashtable of tags to set on the data center resource.

```yaml
Type: System.Hashtable
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource

### Microsoft.Azure.Commands.CosmosDB.Models.PSDataCenterResource

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSDataCenterResource

## NOTES

## RELATED LINKS
