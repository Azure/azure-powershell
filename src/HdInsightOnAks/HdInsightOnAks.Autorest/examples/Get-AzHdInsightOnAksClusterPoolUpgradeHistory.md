### Example 1: Get a list of clusterpool upgrade history.
```powershell
Get-AzHdInsightOnAksClusterPoolUpgradeHistory -ResourceGroupName $resourceGroupName -ClusterPoolName $clusterPoolName
```

```output
Id                           : /subscriptions/10e32bab-26da-4cc4-a441-52b318f824e6/resourceGroups/hilotest/providers/Microsoft.HDInsight/clusterpools/hilopool/upgradeHistories/05_21_2024_07_38_10_AM-NodeOsUpgrade
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
