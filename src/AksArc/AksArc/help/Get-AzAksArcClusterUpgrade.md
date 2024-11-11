---
external help file: Az.AksArc-help.xml
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/get-azaksarcclusterupgrade
schema: 2.0.0
---

# Get-AzAksArcClusterUpgrade

## SYNOPSIS
Gets the upgrade profile of a provisioned cluster

## SYNTAX

```
Get-AzAksArcClusterUpgrade -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the upgrade profile of a provisioned cluster

## EXAMPLES

### Example 1: Get all potential kubernetes version upgrades on the provisioned cluster.
```powershell
Get-AzAksArcClusterUpgrade -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
```

This command gets the potential upgrades that can be done on the provisioned cluster.

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IProvisionedClusterUpgradeProfile

## NOTES

## RELATED LINKS
