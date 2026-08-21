---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbgarnetcluster
schema: 2.0.0
---

# Get-AzCosmosDBGarnetCluster

## SYNOPSIS
Gets an Azure Cosmos DB Garnet cache cluster.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBGarnetCluster [-ResourceGroupName <String>] [-ClusterName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzCosmosDBGarnetCluster -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzCosmosDBGarnetCluster -InputObject <PSGarnetClusterResource> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzCosmosDBGarnetCluster** cmdlet retrieves an existing Garnet cache cluster.
If you specify both **ResourceGroupName** and **ClusterName**, the cmdlet gets a specific cluster.
If you specify only **ResourceGroupName**, the cmdlet lists all Garnet clusters in that resource group.
If you specify neither parameter, the cmdlet lists all Garnet clusters in the current subscription.

## EXAMPLES

### Example 1
```powershell
Get-AzCosmosDBGarnetCluster -ResourceGroupName "resourceGroupName" -ClusterName "clusterName"
```

### Example 2
```powershell
Get-AzCosmosDBGarnetCluster -ResourceGroupName "resourceGroupName"
```

### Example 3
```powershell
Get-AzCosmosDBGarnetCluster
```

### Example 4
```powershell
Get-AzCosmosDBGarnetCluster -ResourceId "/subscriptions/<subscriptionId>/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/garnetClusters/clusterName"
```

### Example 5
```powershell
$cluster | Get-AzCosmosDBGarnetCluster
```

## PARAMETERS

### -ClusterName
Name of the Garnet cache cluster.

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
Garnet cache cluster object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSGarnetClusterResource
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group. If **ClusterName** is omitted, all Garnet clusters in the resource group are returned.

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
Resource ID of the Garnet cache cluster.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSGarnetClusterResource

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSGarnetClusterResource

## NOTES

## RELATED LINKS

[New-AzCosmosDBGarnetCluster](./New-AzCosmosDBGarnetCluster.md)

[Update-AzCosmosDBGarnetCluster](./Update-AzCosmosDBGarnetCluster.md)

[Remove-AzCosmosDBGarnetCluster](./Remove-AzCosmosDBGarnetCluster.md)
