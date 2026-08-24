---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbgarnetcluster
schema: 2.0.0
---

# New-AzCosmosDBGarnetCluster

## SYNOPSIS
Creates a new Azure Cosmos DB Garnet cache cluster.

## SYNTAX

```
New-AzCosmosDBGarnetCluster -ResourceGroupName <String> -ClusterName <String> -Location <String>
 [-SubnetId <String>] [-ReplicationFactor <Int32>] [-ShardCount <Int32>] [-NodeSku <String>]
 [-AvailabilityZone <Boolean>] [-AuthenticationMethod <String>] [-PersistenceMode <String>]
 [-Extension <String[]>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDBGarnetCluster** cmdlet creates a new Garnet cache cluster.

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBGarnetCluster `
 -ResourceGroupName "resourceGroupName" `
 -ClusterName "clusterName" `
 -Location "eastus" `
 -AuthenticationMethod "Entra"
```

### Example 2
```powershell
$tags = @{
    Environment = "Test"
    Team = "Cache"
}

New-AzCosmosDBGarnetCluster `
 -ResourceGroupName "resourceGroupName" `
 -ClusterName "clusterName" `
 -Location "eastus" `
 -SubnetId "/subscriptions/<subscriptionId>/resourceGroups/network-rg/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1" `
 -ReplicationFactor 3 `
 -ShardCount 2 `
 -NodeSku "Standard_DS14_v2" `
 -AvailabilityZone $true `
 -AuthenticationMethod "Entra" `
 -PersistenceMode "AofAndRdb" `
 -Extension "extensionA","extensionB" `
 -Tag $tags
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

### -AvailabilityZone
Indicates whether Availability Zone support is enabled for the Garnet cluster.

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

### -ClusterName
Name of the Garnet cache cluster.

```yaml
Type: System.String
Parameter Sets: (All)
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
Extensions to add to the Garnet cluster.

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

### -Location
Azure region where the Garnet cache cluster is created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeSku
Virtual Machine SKU used for the cluster.

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

### -ReplicationFactor
Number of copies of data maintained by the cluster.

```yaml
Type: System.Nullable`1[System.Int32]
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShardCount
Number of shards in the cluster.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Resource ID of the subnet used by the cluster management service.

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

### -Tag
Hashtable of tags to associate with the Garnet cluster resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSGarnetClusterResource

## NOTES

## RELATED LINKS

[Get-AzCosmosDBGarnetCluster](./Get-AzCosmosDBGarnetCluster.md)

[Update-AzCosmosDBGarnetCluster](./Update-AzCosmosDBGarnetCluster.md)

[Remove-AzCosmosDBGarnetCluster](./Remove-AzCosmosDBGarnetCluster.md)
