### Example 1: Create an object to hold the upgrade parameters.
```powershell
$hotfixObj = New-AzHdInsightOnAksClusterHotfixUpgradeObject -ComponentName Webssh -TargetBuildNumber 7 -TargetClusterVersion "1.1.1" -TargetOssVersion "0.4.2"
```

```output
Property                                    UpgradeType
--------                                    -----------
{…                                          HotfixUpgrade
```

Create an object to hold the flink cluster HotfixUpgrade parameters.