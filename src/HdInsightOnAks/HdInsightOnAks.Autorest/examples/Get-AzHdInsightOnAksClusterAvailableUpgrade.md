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
