---
external help file: Microsoft.Azure.Commands.MachineLearningCompute.dll-Help.xml
Module Name: AzureRM.MachineLearningCompute
online version: 
schema: 2.0.0
---

# Remove-AzureRmMlOpCluster

## SYNOPSIS
Removes an operationalization cluster.

## SYNTAX

### Remove an operationalization cluster from cmdlet input parameters.
```
Remove-AzureRmMlOpCluster -ResourceGroupName <String> -Name <String> [-WhatIf] [-Confirm]
```

### Remove an operationalization cluster from an OperationalizationCluster instance definition.
```
Remove-AzureRmMlOpCluster -InputObject <PSOperationalizationCluster> [-WhatIf] [-Confirm]
```

### Remove an operationalization cluster from an Azure resouce id.
```
Remove-AzureRmMlOpCluster -ResourceId <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
Removes an operationalization cluster. Some resources associated with the cluster might not all be removed. For example, the Azure container service will get removed, but the associated VMs do not. The storage account, container registry, and application insights are not removed for diagnostic information.

## EXAMPLES

### Example 1
```
PS C:\> Remove-AzureRmMlOpCluster -ResourceGroupName my-group -Name my-cluster
```

### Example 2
```
PS C:\> Get-AzureRmMlOpCluster -ResourceGroupName my-group -Name my-cluster | Remove-AzureRmMlOpCluster 
```

## PARAMETERS

### -InputObject
The operationalization cluster object.

```yaml
Type: PSOperationalizationCluster
Parameter Sets: Remove an operationalization cluster from an OperationalizationCluster instance definition.
Aliases: Cluster

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
The name of the operationalization cluster.

```yaml
Type: String
Parameter Sets: Remove an operationalization cluster from cmdlet input parameters.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group for the operationalization cluster.

```yaml
Type: String
Parameter Sets: Remove an operationalization cluster from cmdlet input parameters.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure resource id for the operationalization cluster.

```yaml
Type: String
Parameter Sets: Remove an operationalization cluster from an Azure resouce id.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

## INPUTS

### Microsoft.Azure.Commands.MachineLearningCompute.Models.PSOperationalizationCluster
### System.String


## OUTPUTS

### System.Void


## NOTES

## RELATED LINKS

