---
external help file:
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/az.kubernetesruntime/update-azkubernetesruntimeservice
schema: 2.0.0
---

# Update-AzKubernetesRuntimeService

## SYNOPSIS
Update a ServiceResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzKubernetesRuntimeService -ArcConnectedClusterId <String> -Name <String> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzKubernetesRuntimeService -InputObject <IKubernetesRuntimeIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a ServiceResource

## EXAMPLES

### Example 1: Update a Kubernetes Runtime service object
```powershell
Update-AzKubernetesRuntimeService -ArcConnectedClusterId /subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/jundachen/providers/Microsoft.Kubernetes/connectedClusters/test-3-arc -Name storageclass
```

Update a Kubernetes Runtime service object.

## PARAMETERS

### -ArcConnectedClusterId
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded
Aliases: ServiceName

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.IKubernetesRuntimeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.IServiceResource

## NOTES

## RELATED LINKS

