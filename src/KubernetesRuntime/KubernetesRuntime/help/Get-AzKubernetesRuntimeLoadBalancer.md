---
external help file: Az.KubernetesRuntime-help.xml
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/az.kubernetesruntime/get-azkubernetesruntimeloadbalancer
schema: 2.0.0
---

# Get-AzKubernetesRuntimeLoadBalancer

## SYNOPSIS
Get a LoadBalancer

## SYNTAX

### List (Default)
```
Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKubernetesRuntimeLoadBalancer -InputObject <IKubernetesRuntimeIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a LoadBalancer

## EXAMPLES

### Example 1: List all load balancers of a connected cluster
```powershell
Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

List all load balancers of a connected cluster

### Example 2: Get a load balancer of a connected cluster
```powershell
Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name "test1"
```

Get a load balancer of a connected cluster

## PARAMETERS

### -ArcConnectedClusterId
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases: ResourceUri

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.IKubernetesRuntimeIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the LoadBalancer

```yaml
Type: System.String
Parameter Sets: Get
Aliases: LoadBalancerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.IKubernetesRuntimeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.ILoadBalancer

## NOTES

## RELATED LINKS
