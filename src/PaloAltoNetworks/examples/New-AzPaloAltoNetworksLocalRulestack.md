### Example 1: Create a LocalRulestackResource.
```powershell
New-AzPaloAltoNetworksLocalRulestack -Name azps-panlr -ResourceGroupName azps_test_group_pan -Location eastus -Description "testing powershell" -DefaultMode 'NONE'
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

Create a LocalRulestackResource.