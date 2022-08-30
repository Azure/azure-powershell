---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-Help.xml
Module Name: Az.ServiceFabric
online version: https://docs.microsoft.com/powershell/module/az.servicefabric/new-azservicefabricmanagedclusterservice
schema: 2.0.0
---

# New-AzServiceFabricManagedClusterService

## SYNOPSIS
Create new service fabric managed service under the specified application and cluster.

## SYNTAX

### Stateless-Singleton (Default)
```
New-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> -Type <String> [-Stateless] -InstanceCount <Int32>
 [-MinInstanceCount <Int32>] [-MinInstancePercentage <Int32>] [-DefaultMoveCost <MoveCostEnum>]
 [-PlacementConstraint <String>] [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-PartitionSchemeSingleton] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Stateless-UniformInt64Range
```
New-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> -Type <String> [-Stateless] -InstanceCount <Int32>
 [-MinInstanceCount <Int32>] [-MinInstancePercentage <Int32>] [-DefaultMoveCost <MoveCostEnum>]
 [-PlacementConstraint <String>] [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-PartitionSchemeUniformInt64] -PartitionCount <Int32> -LowKey <Int64> -HighKey <Int64>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Stateless-Named
```
New-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> -Type <String> [-Stateless] -InstanceCount <Int32>
 [-MinInstanceCount <Int32>] [-MinInstancePercentage <Int32>] [-DefaultMoveCost <MoveCostEnum>]
 [-PlacementConstraint <String>] [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-PartitionSchemeNamed] -PartitionName <String[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Stateful-Singleton
```
New-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> -Type <String> [-Stateful] -TargetReplicaSetSize <Int32>
 -MinReplicaSetSize <Int32> [-HasPersistedState] [-ReplicaRestartWaitDuration <TimeSpan>]
 [-QuorumLossWaitDuration <TimeSpan>] [-StandByReplicaKeepDuration <TimeSpan>]
 [-ServicePlacementTimeLimit <TimeSpan>] [-DefaultMoveCost <MoveCostEnum>] [-PlacementConstraint <String>]
 [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-PartitionSchemeSingleton] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Stateful-UniformInt64Range
```
New-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> -Type <String> [-Stateful] -TargetReplicaSetSize <Int32>
 -MinReplicaSetSize <Int32> [-HasPersistedState] [-ReplicaRestartWaitDuration <TimeSpan>]
 [-QuorumLossWaitDuration <TimeSpan>] [-StandByReplicaKeepDuration <TimeSpan>]
 [-ServicePlacementTimeLimit <TimeSpan>] [-DefaultMoveCost <MoveCostEnum>] [-PlacementConstraint <String>]
 [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-PartitionSchemeUniformInt64] -PartitionCount <Int32> -LowKey <Int64> -HighKey <Int64>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Stateful-Named
```
New-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> -Type <String> [-Stateful] -TargetReplicaSetSize <Int32>
 -MinReplicaSetSize <Int32> [-HasPersistedState] [-ReplicaRestartWaitDuration <TimeSpan>]
 [-QuorumLossWaitDuration <TimeSpan>] [-StandByReplicaKeepDuration <TimeSpan>]
 [-ServicePlacementTimeLimit <TimeSpan>] [-DefaultMoveCost <MoveCostEnum>] [-PlacementConstraint <String>]
 [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-PartitionSchemeNamed] -PartitionName <String[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet allows to creating stateless or stateful managed services under the specified application. The service should exit in the application manifest and the type should be the same as the one in the manifest. The application name should be a prefix of the service name.

## EXAMPLES

### Example 1
```powershell
$resourceGroupName = "testRG"
$clusterName = "testCluster"
$appName = "testApp"
$serviceName = "testService1"
$serviceTypeName = "testStateless"
$statelessServiceMetric = New-Object -TypeName "Microsoft.Azure.Commands.ServiceFabric.Models.PSServiceMetric" -ArgumentList @("metric1", "Low", 4)
New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName -Type $serviceTypeName -Stateless -InstanceCount -1 -PartitionSchemeSingleton -Metric @($statelessServiceMetric) -Verbose
```

This example will create a new stateless managed service "testService1" with instance count -1 (on all the nodes).

### Example 2
```powershell
$resourceGroupName = "testRG"
$clusterName = "testCluster"
$appName = "testApp"
$serviceName = "testService2"
$serviceTypeName = "testStatefulType"
$partitionCount = 5
$partitionLowKey = 0
$partitionHighKey = 25
$statefulServiceMetric = New-Object -TypeName "Microsoft.Azure.Commands.ServiceFabric.Models.PSServiceMetric" -ArgumentList @("metric2", "Medium", 4, 2)
New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName -Type $serviceTypeName -Stateful -TargetReplicaSetSize 5 -MinReplicaSetSize 3 -Metric @($statefulServiceMetric) -PartitionSchemeUniformInt64 -PartitionCount $partitionCount -LowKey $partitionLowKey -HighKey $partitionHighKey -Verbose
```

This example will create a new stateful managed service "testService2" with a target of 5 nodes.

### Example 3
```powershell
$resourceGroupName = "testRG"
$clusterName = "testCluster"
$appName = "testApp"
$serviceName = "testService3"
$serviceName2 = "testService2"
$serviceTypeName = "testStateless"
$statefulService = Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName2
$statefulServiceCorrelation = New-Object -TypeName "Microsoft.Azure.Commands.ServiceFabric.Models.PSServiceCorrelation" -ArgumentList @("AlignedAffinity", $statefulService.Id)
New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName -Type $serviceTypeName -Stateless -InstanceCount 3 -PartitionSchemeSingleton -Correlation @($statefulServiceCorrelation) -Verbose
```

This example will create a new stateless managed service "testService3".

## PARAMETERS

### -ApplicationName
Specify the name of the managed application.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background and return a Job to track progress.

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
Specify the name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Correlation
Specify the placement constraints of the managed service, as a string.

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.PSServiceCorrelation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultMoveCost
Specify the default cost for a move.
Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.MoveCostEnum
Parameter Sets: (All)
Aliases:
Accepted values: Zero, Low, Medium, High

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

### -Force
Continue without prompts

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

### -HasPersistedState
Specify the target replica set size for the managed service

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HighKey
Specify the upper bound of the partition key range.

```yaml
Type: System.Int64
Parameter Sets: Stateless-UniformInt64Range, Stateful-UniformInt64Range
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceCount
Specify the instance count for the managed service

```yaml
Type: System.Int32
Parameter Sets: Stateless-Singleton, Stateless-UniformInt64Range, Stateless-Named
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LowKey
Specify the lower bound of the partition key range.

```yaml
Type: System.Int64
Parameter Sets: Stateless-UniformInt64Range, Stateful-UniformInt64Range
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metric
Specify the placement constraints of the managed service, as a string.

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.PSServiceMetric[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinInstanceCount
Specify the minimum instance count for the managed service

```yaml
Type: System.Int32
Parameter Sets: Stateless-Singleton, Stateless-UniformInt64Range, Stateless-Named
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinInstancePercentage
Specify the minimum instance percentage for the managed service

```yaml
Type: System.Int32
Parameter Sets: Stateless-Singleton, Stateless-UniformInt64Range, Stateless-Named
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinReplicaSetSize
Specify the min replica set size for the managed service

```yaml
Type: System.Int32
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specify the name of the managed service.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServiceName

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionCount
Specify the number of partitions.

```yaml
Type: System.Int32
Parameter Sets: Stateless-UniformInt64Range, Stateful-UniformInt64Range
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionName
Indicates that the service uses the named partition scheme. Services using this model usually have data that can be bucketed, within a bounded set. Some common examples of data fields used as named partition keys would be regions, postal codes, customer groups, or other business boundaries.

```yaml
Type: System.String[]
Parameter Sets: Stateless-Named, Stateful-Named
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionSchemeNamed
Indicates that the service uses the named partition scheme.
Services using this model usually have data that can be bucketed, within a bounded set.
Some common examples of data fields used as named partition keys would be regions, postal codes, customer groups, or other business boundaries.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Stateless-Named, Stateful-Named
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionSchemeSingleton
Indicates that the service uses the singleton partition scheme.
Singleton partitions are typically used when the service does not require any additional routing.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Stateless-Singleton, Stateful-Singleton
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionSchemeUniformInt64
Indicates that the service uses the UniformInt64 partition scheme.
This means that each partition owns a range of int64 keys.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Stateless-UniformInt64Range, Stateful-UniformInt64Range
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementConstraint
Specify the placement constraints of the managed service, as a string.

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

### -QuorumLossWaitDuration
Specify the quorum loss wait duration for the managed service.
Duration represented in ISO 8601 format 'hh:mm:ss'

```yaml
Type: System.TimeSpan
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicaRestartWaitDuration
Specify the replica restart wait duration for the managed service.
Duration represented in ISO 8601 format 'hh:mm:ss'

```yaml
Type: System.TimeSpan
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specify the name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServicePackageActivationMode
Specify the default cost for a move.
Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.ServicePackageActivationModeEnum
Parameter Sets: (All)
Aliases:
Accepted values: SharedProcess, ExclusiveProcess

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePlacementTimeLimit
Specify the service placement time limit for the managed service.
Duration represented in ISO 8601 format 'hh:mm:ss'

```yaml
Type: System.TimeSpan
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StandByReplicaKeepDuration
Specify the stand by replica duration for the managed service.
Duration represented in ISO 8601 format 'hh:mm:ss'

```yaml
Type: System.TimeSpan
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stateful
Use for stateful service

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stateless
Use for stateless service

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Stateless-Singleton, Stateless-UniformInt64Range, Stateless-Named
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Specify the tags as key/value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetReplicaSetSize
Specify the target replica set size for the managed service

```yaml
Type: System.Int32
Parameter Sets: Stateful-Singleton, Stateful-UniformInt64Range, Stateful-Named
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Specify the service type name of the managed application, should exist in the application manifest.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServiceType

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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### System.String

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PSManagedService

## NOTES

## RELATED LINKS
