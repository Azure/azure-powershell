### Example 1: Synchronously updates a channel with the specified parameters.
```powershell
$dateObj = Get-Date -Year 2023 -Month 11 -Day 10 -Hour 11 -Minute 06 -Second 07
Update-AzEventGridChannel -Name azps-channel -PartnerNamespaceName azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -ExpirationTimeIfNotActivatedUtc $dateObj.ToUniversalTime()
```

```output
Name         ResourceGroupName
----         -----------------
azps-channel azps_test_group_eventgrid
```

Synchronously updates a channel with the specified parameters.