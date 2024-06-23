---
external help file:
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/invoke-azaksarcclusterupgrade
schema: 2.0.0
---

# Invoke-AzAksArcClusterUpgrade

## SYNOPSIS
Update the provisioned cluster instance

## SYNTAX

### UpdateExpanded (Default)
```
Invoke-AzAksArcClusterUpgrade -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Upgrade
```
Invoke-AzAksArcClusterUpgrade -ClusterName <String> -ResourceGroupName <String> -KubernetesVersion <String>
 [-SubscriptionId <String>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the provisioned cluster instance

## EXAMPLES

### Example 1: Upgrade kubernetes version to latest possible
```powershell
Invoke-AzAksArcClusterUpgrade -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
```

Upgrade cluster to latest kubernetes version.

### Example 2: Upgrade kubernetes version to specified version
```powershell
Invoke-AzAksArcClusterUpgrade -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -KubernetesVersion "1.28.5"
```

Upgrade cluster to the specified kubernetes version.

## PARAMETERS

### -AsJob
Run the command as a job

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
The name of the Kubernetes cluster on which get is called.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KubernetesVersion
The version of Kubernetes in use by the provisioned cluster.

```yaml
Type: System.String
Parameter Sets: Upgrade
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IProvisionedCluster

## NOTES

## RELATED LINKS

