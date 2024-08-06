### Example 1: Create an object to hold the cluster pool upgrade parameters.
```powershell
New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject -TargetAksVersion "1.27.9" -UpgradeClusterPool $true
```

```output
Property                                                                                                                                    UpgradeType
--------                                                                                                                                    -----------
{…                                                                                                                                          AKSPatchUpgrade
```

Create an object to hold the flink cluster AKSPatchUpgrade parameters.
