---
external help file:
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/az.kubernetesruntime/remove-azkubernetesruntimebgppeer
schema: 2.0.0
---

# Remove-AzKubernetesRuntimeBgpPeer

## SYNOPSIS
Delete a BgpPeer

## SYNTAX

### Delete (Default)
```
Remove-AzKubernetesRuntimeBgpPeer -ArcConnectedClusterId <String> -Name <String> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzKubernetesRuntimeBgpPeer -InputObject <IKubernetesRuntimeIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delete a BgpPeer

## EXAMPLES

### Example 1: Remove a bgp peer from a connected cluster
```powershell
Remove-AzKubernetesRuntimeBgpPeer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name "test1"
```

Remove a bgp peer from a connected cluster.

## PARAMETERS

### -ArcConnectedClusterId
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: Delete
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
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the BgpPeer

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: BgpPeerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### System.Boolean

## NOTES

## RELATED LINKS

