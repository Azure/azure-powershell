### Example 1: Get a list of clusterpool upgrade history.
```powershell
$resourceGroupName = "resourceGroupName"
$clusterPoolName = "clusterPoolName"
Get-AzHdInsightOnAksClusterPoolUpgradeHistory -ResourceGroupName $resourceGroupName -ClusterPoolName $clusterPoolName
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hilotest/providers/Microsoft.HDInsight/clusterpools/hilopool/upgradeHistories/05_21_2024_07_38_10_AM-NodeOsUpgrade
Name                         : 05_21_2024_07_38_10_AM-NodeOsUpgrade
Property                     : {
                                 "upgradeType": "NodeOsUpgrade",
                                 "utcTime": "05/21/2024 07:38:10 AM",
                                 "upgradeResult": "Succeed",
                                 "newNodeOs": "AKSAzureLinux-V2gen2-202405.03.0"
                               }
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
UpgradeResult                : Succeed
UpgradeType                  : NodeOsUpgrade
UtcTime                      : 05/21/2024 07:38:10 AM
```

Get the upgrade history of a cluster pool.
