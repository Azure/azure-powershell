### Example 1: Bulk removing Sims
```powershell
$sims = @("BulkSim01", "BulkSim02")
Remove-AzMobileNetworkBulkSimDelete -ResourceGroupName azps_test_group -SimGroupName SimGroup01 -Sim $sims
```

Bulks remove multiple sims from a SimGroup.

