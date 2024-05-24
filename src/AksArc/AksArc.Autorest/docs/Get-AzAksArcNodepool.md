---
external help file:
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/get-azaksarcnodepool
schema: 2.0.0
---

# Get-AzAksArcNodepool

## SYNOPSIS
Gets the specified agent pool in the provisioned cluster

## SYNTAX

### List (Default)
```
Get-AzAksArcNodepool -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [<CommonParameters>]
```

### Get
```
Get-AzAksArcNodepool -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAksArcNodepool -ClusterName <String> -InputObject <IAksArcIdentity> -ResourceGroupName <String>
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified agent pool in the provisioned cluster

## EXAMPLES

### Example 1: Get all nodepools in a provisioned cluster. 
```powershell
Get-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
```

```output
Name                  ResourceGroupName
----                  -----------------
azps_test_nodepool1    azps_test_group
azps_test_nodepool2    azps_test_group
```

This command gets the provisioned cluster's nodepools.

### Example 2: Get a specific nodepool in a provisioned cluster. 
```powershell
Get-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool1
```

This command gets the specified provisioned cluster nodepool.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAksArcIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Parameter for the name of the agent pool in the provisioned cluster.

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

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAksArcIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAgentPool

## NOTES

## RELATED LINKS

