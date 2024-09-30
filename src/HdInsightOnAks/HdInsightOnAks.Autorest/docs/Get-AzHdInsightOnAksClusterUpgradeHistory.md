---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/get-azhdinsightonaksclusterupgradehistory
schema: 2.0.0
---

# Get-AzHdInsightOnAksClusterUpgradeHistory

## SYNOPSIS
Returns a list of upgrade history.

## SYNTAX

```
Get-AzHdInsightOnAksClusterUpgradeHistory -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a list of upgrade history.

## EXAMPLES

### Example 1: Get a list of cluster upgrade history.
```powershell
$resourceGroupName = "resourceGroupName"
$clusterPoolName = "clusterPoolName"
$clusterName = "clusterName"
Get-AzHdInsightOnAksClusterUpgradeHistory -ResourceGroupName $resourceGroupName -ClusterPoolName $clusterPoolName -ClusterName $clusterName
```

```output
Name                                   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                                   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
05_11_2024_06_41_26_AM-AKSPatchUpgrade
05_08_2024_08_48_28_AM-AKSPatchUpgrade
```

Get a list of cluster upgrade history.

## PARAMETERS

### -ClusterName
The name of the HDInsight cluster.

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

### -ClusterPoolName
The name of the cluster pool.

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
The value must be an UUID.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgradeHistory

## NOTES

## RELATED LINKS

