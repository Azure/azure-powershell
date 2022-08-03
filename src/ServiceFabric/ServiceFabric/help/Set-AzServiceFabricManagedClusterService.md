---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-Help.xml
Module Name: Az.ServiceFabric
online version: https://docs.microsoft.com/powershell/module/az.servicefabric/set-azservicefabricmanagedclusterservice
schema: 2.0.0
---

# Set-AzServiceFabricManagedClusterService

## SYNOPSIS
Update a managed service from the cluster. Only supports ARM deployed services.

## SYNTAX

### Stateless-ByResourceGroup (Default)
```
Set-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> [-Stateless] [-InstanceCount <Int32>] [-MinInstanceCount <Int32>]
 [-MinInstancePercentage <Int32>] [-DefaultMoveCost <MoveCostEnum>] [-PlacementConstraint <String>]
 [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Stateful-ByResourceGroup
```
Set-AzServiceFabricManagedClusterService [-ResourceGroupName] <String> [-ClusterName] <String>
 [-ApplicationName] <String> [-Name] <String> [-Stateful] [-TargetReplicaSetSize <Int32>]
 [-MinReplicaSetSize <Int32>] [-HasPersistedState] [-ReplicaRestartWaitDuration <TimeSpan>]
 [-QuorumLossWaitDuration <TimeSpan>] [-StandByReplicaKeepDuration <TimeSpan>]
 [-ServicePlacementTimeLimit <TimeSpan>] [-DefaultMoveCost <MoveCostEnum>] [-PlacementConstraint <String>]
 [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Stateless-ByResourceId
```
Set-AzServiceFabricManagedClusterService -ResourceId <String> [-Stateless] [-InstanceCount <Int32>]
 [-MinInstanceCount <Int32>] [-MinInstancePercentage <Int32>] [-DefaultMoveCost <MoveCostEnum>]
 [-PlacementConstraint <String>] [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Stateful-ByResourceId
```
Set-AzServiceFabricManagedClusterService -ResourceId <String> [-Stateful] [-TargetReplicaSetSize <Int32>]
 [-MinReplicaSetSize <Int32>] [-HasPersistedState] [-ReplicaRestartWaitDuration <TimeSpan>]
 [-QuorumLossWaitDuration <TimeSpan>] [-StandByReplicaKeepDuration <TimeSpan>]
 [-ServicePlacementTimeLimit <TimeSpan>] [-DefaultMoveCost <MoveCostEnum>] [-PlacementConstraint <String>]
 [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Stateless-ByInputObject
```
Set-AzServiceFabricManagedClusterService -InputObject <PSManagedService> [-Stateless] [-InstanceCount <Int32>]
 [-MinInstanceCount <Int32>] [-MinInstancePercentage <Int32>] [-DefaultMoveCost <MoveCostEnum>]
 [-PlacementConstraint <String>] [-Metric <PSServiceMetric[]>] [-Correlation <PSServiceCorrelation[]>]
 [-ServicePackageActivationMode <ServicePackageActivationModeEnum>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Stateful-ByInputObject
```
Set-AzServiceFabricManagedClusterService -InputObject <PSManagedService> [-Stateful]
 [-TargetReplicaSetSize <Int32>] [-MinReplicaSetSize <Int32>] [-HasPersistedState]
 [-ReplicaRestartWaitDuration <TimeSpan>] [-QuorumLossWaitDuration <TimeSpan>]
 [-StandByReplicaKeepDuration <TimeSpan>] [-ServicePlacementTimeLimit <TimeSpan>]
 [-DefaultMoveCost <MoveCostEnum>] [-PlacementConstraint <String>] [-Metric <PSServiceMetric[]>]
 [-Correlation <PSServiceCorrelation[]>] [-ServicePackageActivationMode <ServicePackageActivationModeEnum>]
 [-Tag <Hashtable>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet updates a managed service form the cluster.

## EXAMPLES

### Example 1
```powershell
$resourceGroupName = "testRG"
$clusterName = "testCluster"
$appName = "testApp"
$serviceName = "testService1"
Set-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName -Stateful -TargetReplicaSetSize 3 -MinReplicaSetSize 5 -Verbose
```

This example will update the managed service "testService1".

### Example 2
```powershell
$resourceGroupName = "testRG"
$clusterName = "testCluster"
$appName = "testApp"
$serviceName = "testService1"
$minInstancePercentage = 20
$minInstanceCount = 2
$statelessServiceMetric = New-Object -TypeName "Microsoft.Azure.Commands.ServiceFabric.Models.PSServiceMetric" -ArgumentList @("metric1", "Low", 4)
$service = Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName
$service | Set-AzServiceFabricManagedClusterService -Stateless -Metric @($statelessServiceMetric) -MinInstanceCount $minInstanceCount -MinInstancePercentage $minInstancePercentage -Verbose
```

This example will remove the managed service testService1".

### Example 3
```powershell
$standByReplicaKeepDuration = "00:11:00"
$servicePlacementTimeLimit = "00:11:00"
$resourceId = "/subscriptions/13ad2c84-84fa-4798-ad71-e70c07af873f/resourcegroups/testRG/providers/Microsoft.ServiceFabric/managedClusters/testCluster/applications/testApp/services/testService"
Set-AzServiceFabricManagedClusterService -ResourceId $resourceId -StandByReplicaKeepDuration $standByReplicaKeepDuration -ServicePlacementTimeLimit $servicePlacementTimeLimit -Verbose
```

This example will remove the managed service details with the ARM Resource ID specified.

## PARAMETERS

### -ApplicationName
Specify the name of the managed application.

```yaml
Type: System.String
Parameter Sets: Stateless-ByResourceGroup, Stateful-ByResourceGroup
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
Parameter Sets: Stateless-ByResourceGroup, Stateful-ByResourceGroup
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The managed service resource.

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.PSManagedService
Parameter Sets: Stateless-ByInputObject, Stateful-ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceCount
Specify the instance count for the managed service

```yaml
Type: System.Int32
Parameter Sets: Stateless-ByResourceGroup, Stateless-ByResourceId, Stateless-ByInputObject
Aliases:

Required: False
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
Parameter Sets: Stateless-ByResourceGroup, Stateless-ByResourceId, Stateless-ByInputObject
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
Parameter Sets: Stateless-ByResourceGroup, Stateless-ByResourceId, Stateless-ByInputObject
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specify the name of the managed service.

```yaml
Type: System.String
Parameter Sets: Stateless-ByResourceGroup, Stateful-ByResourceGroup
Aliases: ServiceName

Required: True
Position: 3
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
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
Parameter Sets: Stateless-ByResourceGroup, Stateful-ByResourceGroup
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Arm ResourceId of the managed service.

```yaml
Type: System.String
Parameter Sets: Stateless-ByResourceId, Stateful-ByResourceId
Aliases:

Required: True
Position: Named
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
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
Parameter Sets: Stateless-ByResourceGroup, Stateless-ByResourceId, Stateless-ByInputObject
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
Parameter Sets: Stateful-ByResourceGroup, Stateful-ByResourceId, Stateful-ByInputObject
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

### Microsoft.Azure.Commands.ServiceFabric.Models.PSManagedService

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PSManagedService

## NOTES

## RELATED LINKS
