---
external help file:
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/az.kubernetesruntime/get-azkubernetesruntimeservice
schema: 2.0.0
---

# Get-AzKubernetesRuntimeService

## SYNOPSIS
Get a ServiceResource

## SYNTAX

### List (Default)
```
Get-AzKubernetesRuntimeService -ArcConnectedClusterId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzKubernetesRuntimeService -ArcConnectedClusterId <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKubernetesRuntimeService -InputObject <IKubernetesRuntimeIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a ServiceResource

## EXAMPLES

### Example 1: Get all Kubernetes Runtime service objects in a cluster
```powershell
Get-AzKubernetesRuntimeService -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

```output
Id                           : /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1/providers/Microsoft.KubernetesRuntime/services/storageclass
Name                         : storageclass
ProvisioningState            : Succeeded
ResourceGroupName            : example
RpObjectId                   : 00000000-1111-2222-3333-444444444444
SystemDataCreatedAt          : 3/1/2024 0:00:00 AM
SystemDataCreatedBy          : user@user.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/1/2024 0:00:00 AM
SystemDataLastModifiedBy     : user@user.com
SystemDataLastModifiedByType : User
Type                         : microsoft.kubernetesruntime/services
```

Get all Kubernetes Runtime service objects for the connected cluster.

### Example 2: Get a Kubernetes Runtime service object for a connected cluster.
```powershell
Get-AzKubernetesRuntimeService -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name storageclass
```

```output
Id                           : /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1/providers/Microsoft.KubernetesRuntime/services/storageclass
Name                         : storageclass
ProvisioningState            : Succeeded
ResourceGroupName            : example
RpObjectId                   : 00000000-1111-2222-3333-444444444444
SystemDataCreatedAt          : 3/1/2024 0:00:00 AM
SystemDataCreatedBy          : user@user.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/1/2024 0:00:00 AM
SystemDataLastModifiedBy     : user@user.com
SystemDataLastModifiedByType : User
Type                         : microsoft.kubernetesruntime/services
```

Get a Kubernetes Runtime service object for a connected cluster.

## PARAMETERS

### -ArcConnectedClusterId
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: Get, List
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
The name of the the service

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ServiceName

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.IServiceResource

## NOTES

## RELATED LINKS

