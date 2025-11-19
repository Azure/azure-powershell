### Example 1: List GroupQuota subscription allocations
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocation -ManagementGroupId "mgId" -SubscriptionId "<subscription>" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name              AllocatedLimit ProvisioningState
----              -------------- -----------------
standardav2family 50             Succeeded
standardbsfamily  25             Succeeded
```

List all quota allocations for a specified subscription within a GroupQuota for a particular resource provider and location.

