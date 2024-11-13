---
external help file:
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/az.kubernetesruntime/enable-azkubernetesruntimestorageclass
schema: 2.0.0
---

# Enable-AzKubernetesRuntimeStorageClass

## SYNOPSIS
Enable Arc storage class service in a connected cluster.

## SYNTAX

```
Enable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId <String> [-ReleaseTrain <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Enable Arc storage class service in a connected cluster.

## EXAMPLES

### Example 1: Enable Arc storage class service in a connected cluster
```powershell
Enable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

```output
Name                           Value
----                           -----
K8sExtensionContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
StorageClassContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
Extension                      {…}
```

Enables Arc storage class service in a connected cluster.
Returns the created Azure resources.

### Example 2: Enable Arc storage class service in a connected cluster using dev release train extension
```powershell
Enable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -ReleaseTrain dev
```

```output
Name                           Value
----                           -----
K8sExtensionContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
StorageClassContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
Extension                      {…}
```

Enables Arc storage class service in a connected cluster using dev release train extension.
Returns the created Azure resources.

## PARAMETERS

### -ArcConnectedClusterId
The resource uri of the connected cluster

```yaml
Type: System.String
Parameter Sets: (All)
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

### -ReleaseTrain
ReleaseTrain this extension participates in

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.IServiceResource

## NOTES

## RELATED LINKS

