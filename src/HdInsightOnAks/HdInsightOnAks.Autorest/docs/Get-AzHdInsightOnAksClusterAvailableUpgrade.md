---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/get-azhdinsightonaksclusteravailableupgrade
schema: 2.0.0
---

# Get-AzHdInsightOnAksClusterAvailableUpgrade

## SYNOPSIS
List a cluster available upgrade.

## SYNTAX

```
Get-AzHdInsightOnAksClusterAvailableUpgrade -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List a cluster available upgrade.

## EXAMPLES

### Example 1: List a cluster available upgrade.
```powershell
Get-AzHdInsightOnAksClusterAvailableUpgrade -ResourceGroupName PStestGroup -ClusterPoolName hilo-pool -ClusterName flinkcluster
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PStestGroup/providers/Microsoft.HDInsight/clusterpools/hilo-pool/clusters/flinkcluster/availableUpgrades/HotfixUpgrade_Webssh_0.4.2-1.1.1.6_20240103       
Name                         : HotfixUpgrade_Webssh_0.4.2-1.1.1.6_20240103
Property                     : {
                                 "upgradeType": "HotfixUpgrade",
                                 "description": "BugBash",
                                 "sourceOssVersion": "0.4.2",
                                 "sourceClusterVersion": "1.1.1",
                                 "sourceBuildNumber": "6",
                                 "targetOssVersion": "0.4.2",
                                 "targetClusterVersion": "1.1.1",
                                 "targetBuildNumber": "7",
                                 "componentName": "Webssh",
                                 "severity": "low",
                                 "extendedProperties": " ",
                                 "createdTime": "2024-03-12T07:22:42.0000000Z"
                               }
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
UpgradeType                  : HotfixUpgrade
```

List a flink cluster available upgrade.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterAvailableUpgrade

## NOTES

## RELATED LINKS

