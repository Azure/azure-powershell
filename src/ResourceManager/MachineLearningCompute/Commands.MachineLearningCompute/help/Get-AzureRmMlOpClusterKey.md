---
external help file: Microsoft.Azure.Commands.MachineLearningCompute.dll-Help.xml
Module Name: AzureRM.MachineLearningCompute
online version: 
schema: 2.0.0
---

# Get-AzureRmMlOpClusterKey

## SYNOPSIS
Gets the access keys associated with an operationalization cluster.

## SYNTAX

### Get operationalization cluster's keys from cmdlet input parameters.
```
Get-AzureRmMlOpClusterKey -ResourceGroupName <String> -Name <String>
```

### Get operationalization cluster's keys from an OperationalizationCluster instance definition.
```
Get-AzureRmMlOpClusterKey -Cluster <PSOperationalizationCluster>
```

### Get operationalization cluster's keys from an Azure resource id.
```
Get-AzureRmMlOpClusterKey -ResourceId <String>
```

## DESCRIPTION
The keys for the storage account, container registry, and other services associated with the operationalization cluster are not returned when getting the cluster properties. A specific call to retrieve the keys must be made since they are sensitive information.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmMlOpClusterKey -ResourceGroupName my-group -Name my-cluster
```

Returns the secret keys for the services associated with the operationalization cluster.

## PARAMETERS

### -InputObject
The operationalization cluster object.

```yaml
Type: PSOperationalizationCluster
Parameter Sets: Get operationalization cluster's keys from an OperationalizationCluster instance definition.
Aliases: Cluster

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the operationalization cluster.

```yaml
Type: String
Parameter Sets: Get operationalization cluster's keys from cmdlet input parameters.
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
Parameter Sets: Get operationalization cluster's keys from cmdlet input parameters.
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
Parameter Sets: Get operationalization cluster's keys from an Azure resouce id.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Commands.MachineLearningCompute.Models.PSOperationalizationCluster
System.String


## OUTPUTS

### Microsoft.Azure.Commands.MachineLearningCompute.Models.PSOperationalizationClusterCredentials


## NOTES

## RELATED LINKS

