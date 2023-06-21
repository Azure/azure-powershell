---
external help file:
Module Name: Az.KubernetesConfiguration
online version: https://learn.microsoft.com/powershell/module/az.kubernetesconfiguration/get-azkubernetesconfigfluxoperationstatus
schema: 2.0.0
---

# Get-AzKubernetesConfigFluxOperationStatus

## SYNOPSIS
Get Async Operation status

## SYNTAX

### Get (Default)
```
Get-AzKubernetesConfigFluxOperationStatus -ClusterName <String> -ClusterType <String>
 -FluxConfigurationName <String> -OperationId <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKubernetesConfigFluxOperationStatus -InputObject <IKubernetesConfigurationIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get Async Operation status

## EXAMPLES

### Example 1: Get Async Operation status
```powershell
Get-AzKubernetesConfigFluxOperationStatus -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -FluxConfigurationName azpstestflux-k8s -ResourceGroupName azps_test_group -OperationId e9871335-7ba8-4100-8cb4-73b3464eb863
```

```output
Name                                 ResourceGroupName Status
----                                 ----------------- ------
e9871335-7ba8-4100-8cb4-73b3464eb863 azps_test_group   Succeeded
```

Get Async Operation status

## PARAMETERS

### -ClusterName
The name of the kubernetes cluster.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterType
The Kubernetes cluster resource name - i.e.
managedClusters, connectedClusters, provisionedClusters.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FluxConfigurationName
Name of the Flux Configuration.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OperationId
operation Id

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IOperationStatusResult

## NOTES

ALIASES

Get-AzK8sConfigFluxOperationStatus

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IKubernetesConfigurationIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: The name of the kubernetes cluster.
  - `[ClusterResourceName <String>]`: The Kubernetes cluster resource name - i.e. managedClusters, connectedClusters, provisionedClusters.
  - `[ClusterRp <String>]`: The Kubernetes cluster RP - i.e. Microsoft.ContainerService, Microsoft.Kubernetes, Microsoft.HybridContainerService.
  - `[ExtensionName <String>]`: Name of the Extension.
  - `[FluxConfigurationName <String>]`: Name of the Flux Configuration.
  - `[Id <String>]`: Resource identity path
  - `[OperationId <String>]`: operation Id
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SourceControlConfigurationName <String>]`: Name of the Source Control Configuration.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

