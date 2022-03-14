---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/remove-azmanagedcassandradatacenter
schema: 2.0.0
---

# Remove-AzManagedCassandraDataCenter

## SYNOPSIS
Deletes a Azure Managed Instances for Apache Cassandra data center.

## SYNTAX

### NameParameterSet (Default)
```
Remove-AzManagedCassandraDataCenter 
 -ResourceGroupName <String> 
 -ClusterName <String>
 -DataCenterName <String>
 [-AsJob]
 [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzManagedCassandraDataCenter 
 -ResourceId <String> 
 [-AsJob]
 [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ObjectParameterSet
```
Remove-AzManagedCassandraDataCenter 
 -InputObject <PSDataCenterResource> 
 [-AsJob]
 [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzManagedCassandraDataCenter** cmdlet deletes a managed Cassandra data center.

## EXAMPLES

### Example 1
```powershell
Remove-AzManagedCassandraDataCenter `
 -ResourceGroupName {resourceGroupName} `
 -ClusterName {clusterName}
 -DataCenterName {dataCenterName}
```

### Example 2
```powershell
Remove-AzManagedCassandraDataCenter -ResourceId {dataCenterResourceId}
```

### Example 3
```powershell
$dataCenterResource | Remove-AzManagedCassandraDataCenter
```

## PARAMETERS

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

### -DataCenterName
Name of the managed Cassandra data center.

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

### -InputObject
Managed Cassandra data center object

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSDataCenterResource
Parameter Sets: ObjectParameterSet
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

### -ResourceId
Resource id of the managed Cassandra DataCenter.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSDataCenterResource

## OUTPUTS

## NOTES

## RELATED LINKS
