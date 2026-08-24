---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbgarnetcluster
schema: 2.0.0
---

# Update-AzCosmosDBGarnetCluster

## SYNOPSIS
Updates an existing Azure Cosmos DB Garnet cache cluster.

## SYNTAX

### ByNameParameterSet (Default)
```
Update-AzCosmosDBGarnetCluster -ResourceGroupName <String> -ClusterName <String>
 [-AuthenticationMethod <String>] [-Extension <String[]>]
 [-PersistenceMode <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Update-AzCosmosDBGarnetCluster -ResourceId <String>
 [-AuthenticationMethod <String>] [-Extension <String[]>]
 [-PersistenceMode <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBGarnetCluster -InputObject <PSGarnetClusterResource>
 [-AuthenticationMethod <String>] [-Extension <String[]>]
 [-PersistenceMode <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzCosmosDBGarnetCluster** cmdlet updates properties of an existing Garnet cache cluster, including extensions, authentication method, and persistence mode.

## EXAMPLES

### Example 1
```powershell
Update-AzCosmosDBGarnetCluster `
 -ResourceGroupName "resourceGroupName" `
 -ClusterName "clusterName" `
 -AuthenticationMethod "Entra" `
 -PersistenceMode "AofAndRdb"
```

### Example 2
```powershell
Update-AzCosmosDBGarnetCluster `
 -ResourceId "/subscriptions/<subscriptionId>/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/garnetClusters/clusterName" `
 -Extension "extensionA","extensionB"
```

### Example 3
```powershell
$cluster | Update-AzCosmosDBGarnetCluster -PersistenceMode "None"
```

## PARAMETERS

### -AuthenticationMethod
The authentication method used for the Garnet cluster. Acceptable value: `Entra`.

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

### -Extension
Extensions to add or update on the Garnet cluster.

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

### -PersistenceMode
The persistence mode for the Garnet cluster. Acceptable values: `None`, `AofAndRdb`.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSGarnetClusterResource

## NOTES

## RELATED LINKS

[Get-AzCosmosDBGarnetCluster](./Get-AzCosmosDBGarnetCluster.md)

[New-AzCosmosDBGarnetCluster](./New-AzCosmosDBGarnetCluster.md)

[Remove-AzCosmosDBGarnetCluster](./Remove-AzCosmosDBGarnetCluster.md)
