---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/get-azmanagedcassandracluster
schema: 2.0.0
---

# Get-AzManagedCassandraCluster

## SYNOPSIS
Gets a Azure Managed Instances for Apache Cassandra cluster.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzManagedCassandraCluster [-ResourceGroupName <String>] [-ClusterName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzManagedCassandraCluster -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzManagedCassandraCluster -InputObject <PSClusterResource> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagedCassandraCluster** cmdlet fetches the properties of an existing managed Cassandra cluster.

## EXAMPLES

### Example 1
```powershell
Get-AzManagedCassandraCluster -ResourceGroupName "resourceGroupName" -ClusterName "clusterName"
```

### Example 2
```powershell
Get-AzManagedCassandraCluster -ResourceId "resourceId"
```

### Example 3
```powershell
$clusterResource | Get-AzManagedCassandraCluster
```

## PARAMETERS

### -ClusterName
Name of the managed Cassandra cluster.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
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

### -InputObject
Managed Cassandra Cluster object

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource
Parameter Sets: ByObjectParameterSet
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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource id of the managed Cassandra cluster.

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSClusterResource

## NOTES

## RELATED LINKS
