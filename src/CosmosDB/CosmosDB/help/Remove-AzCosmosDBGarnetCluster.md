---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/remove-azcosmosdbgarnetcluster
schema: 2.0.0
---

# Remove-AzCosmosDBGarnetCluster

## SYNOPSIS
Deletes an Azure Cosmos DB Garnet cache cluster.

## SYNTAX

### ByNameParameterSet (Default)
```
Remove-AzCosmosDBGarnetCluster -ResourceGroupName <String> -ClusterName <String> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Remove-AzCosmosDBGarnetCluster -ResourceId <String> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Remove-AzCosmosDBGarnetCluster -InputObject <PSGarnetClusterResource> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzCosmosDBGarnetCluster** cmdlet deletes a Garnet cache cluster.

## EXAMPLES

### Example 1
```powershell
Remove-AzCosmosDBGarnetCluster `
 -ResourceGroupName "resourceGroupName" `
 -ClusterName "clusterName"
```

### Example 2
```powershell
Remove-AzCosmosDBGarnetCluster -ResourceId "/subscriptions/<subscriptionId>/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/garnetClusters/clusterName"
```

### Example 3
```powershell
$cluster | Remove-AzCosmosDBGarnetCluster -PassThru
```

## PARAMETERS

### -AsJob
Runs the cmdlet in the background.

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

### -ClusterName
Name of the Garnet cache cluster.

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

### -InputObject
Garnet cache cluster object to delete.

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

### -PassThru
Returns **True** if the delete operation succeeds.

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

### -ResourceGroupName
Name of the resource group.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSGarnetClusterResource

## OUTPUTS

### System.Void

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzCosmosDBGarnetCluster](./Get-AzCosmosDBGarnetCluster.md)

[New-AzCosmosDBGarnetCluster](./New-AzCosmosDBGarnetCluster.md)

[Update-AzCosmosDBGarnetCluster](./Update-AzCosmosDBGarnetCluster.md)
