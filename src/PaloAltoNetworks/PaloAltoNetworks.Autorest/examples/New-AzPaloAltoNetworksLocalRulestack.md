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

### Example 2: Create a LocalRulestackResource.
```powershell
New-AzPaloAltoNetworksLocalRulestack -Name azps-panlr2 -ResourceGroupName azps_test_group_pan -Location eastus -Description "testing powershell" -DefaultMode 'NONE' -UserAssignedIdentity "/subscriptions/{subId}/resourcegroups/azps_test_group_pan/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami"
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

Create a LocalRulestackResource.