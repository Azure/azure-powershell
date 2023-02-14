### Example 1: Create or update a tag rule set for a given monitor resource
```powershell
<<<<<<< HEAD
New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 -LogRuleSendActivityLog
```

```output
=======
PS C:\> New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 -LogRuleSendActivityLog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azps-elastic-test
```

This command creates or updates a tag rule set for a given monitor resource.


