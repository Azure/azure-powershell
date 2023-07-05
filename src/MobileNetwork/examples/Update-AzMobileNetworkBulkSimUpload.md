### Example 1: Bulk uploading Sims
```powershell
$sim1 = @{Name = "BulkSim01"; InternationalMobileSubscriberIdentity = "0000000001"; AuthenticationKey = "00000000000000000000000000000001"; OperatorKeyCode = "00000000000000000000000000000001"}
$sim2 = @{Name = "BulkSim02"; InternationalMobileSubscriberIdentity = "0000000002"; AuthenticationKey = "00000000000000000000000000000002"; OperatorKeyCode = "00000000000000000000000000000002"}
$sims = @($sim1,$sim2)
Update-AzMobileNetworkBulkSimUpload -ResourceGroupName azps_test_group -SimGroupName SimGroup01 -Sim $sims
```

Bulks uploads multiple sims into a SimGroup.
