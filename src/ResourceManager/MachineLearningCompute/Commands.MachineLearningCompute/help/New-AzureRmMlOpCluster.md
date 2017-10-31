---
external help file: Microsoft.Azure.Commands.MachineLearningCompute.dll-Help.xml
Module Name: AzureRM.MachineLearningCompute
online version: 
schema: 2.0.0
---

# New-AzureRmMlOpCluster

## SYNOPSIS
Creates a new operationalization cluster.

## SYNTAX

### Create a new operationalization cluster from an OperationalizationCluster instance definition.
```
New-AzureRmMlOpCluster -ResourceGroupName <String> -Name <String> -InputObject <PSOperationalizationCluster>
 [-WhatIf] [-Confirm]
```

### Create a new operationalization cluster from cmdlet input parameters.
```
New-AzureRmMlOpCluster -ResourceGroupName <String> -Name <String> -Location <String> -ClusterType <String>
 [-OrchestratorType <String>] [-ServicePrincipalName <String>] [-ServicePrincipalSecret <String>]
 [-Description <String>] [-MasterCount <Int32>] [-AgentCount <Int32>] [-AgentVmSize <String>]
 [-GlobalServiceConfigurationETag <String>] [-SslStatus <String>] [-SslCertificate <String>] [-SslKey <String>]
 [-SslCName <String>] [-StorageAccount <String>] [-AzureContainerRegistry <String>]
 [-GlobalServiceConfigurationAdditionalProperties <Hashtable>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Creates a new operationalization cluster. This will create a cluster object, a container service if needed, application insights, and an azure container registry.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmMlOpCluster -ResourceGroupName my-group -Name my-cluster -Location "East US 2" -ClusterType "ACS" -OrchestratorType "Kubernetes" -ClientId "abc" -Secret "xyz"
```

Creates a new operationalization cluster with azure container service and Kubernetes as the orchestrator.

### Example 2
```
PS C:\> New-AzureRmMlOpCluster -ResourceGroupName my-group -Name my-cluster -Location "East US 2" -ClusterType "Local"
```

Creates a new operationalization cluster locally. This creates an azure container registry, application insights, and storage account, but does not create a container service.

## PARAMETERS

### -AgentCount
The number of agent nodes in the ACS cluster.

```yaml
Type: Int32
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentVmSize
The number of agent nodes in the ACS cluster.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureContainerRegistry
The URI to the azure container registry to use instead of creating one.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The operationalization cluster properties.

```yaml
Type: PSOperationalizationCluster
Parameter Sets: Create a new operationalization cluster from an OperationalizationCluster instance definition.
Aliases: Cluster

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterType
The operationalization cluster type.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The number of master nodes in the ACS cluster.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GlobalServiceConfigurationAdditionalProperties
Additional properties for the global service configuration.

```yaml
Type: Hashtable
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GlobalServiceConfigurationETag
The configuration ETag for updates.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The operationalization cluster's location.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MasterCount
The number of master nodes in the ACS cluster.

```yaml
Type: Int32
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

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
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrchestratorType
The ACS cluster's orchestrator type.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group for the operationalization cluster.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientId
The ACS cluster's orchestrator service principal id.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Secret
The ACS cluster's orchestrator service principal secret.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslCName
The CName for the SSL certificate.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslCertificate
The SSL certificate data in PEM format encoded as base64 string.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslKey
The SSL key data in PEM format encoded as base64 string.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslStatus
SSL status.
Possible values are 'Enabled' and 'Disabled'.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccount
The URI to the storage account to use instead of creating one.

```yaml
Type: String
Parameter Sets: Create a new operationalization cluster from cmdlet input parameters.
Aliases: 

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

### None


## OUTPUTS

### Microsoft.Azure.Commands.MachineLearningCompute.Models.PSOperationalizationCluster


## NOTES

## RELATED LINKS

