### Example 1: List GroupQuotasSubscriptionAllocationRequest for a GroupQuota and Subscription
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -SubscriptionId "<subscription>"
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Succeeded         75
11111111-1111-1111-1111-111111111111 InProgress        100
```

List all GroupQuotasSubscriptionAllocationRequests for a specified GroupQuota, resource provider, resource, and subscription.

### Example 2: Get a specific GroupQuotasSubscriptionAllocationRequest by RequestId
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -SubscriptionId "<subscription>" -RequestId "00000000-0000-0000-0000-000000000000"
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Succeeded         75
```

Get details of a specific GroupQuotasSubscriptionAllocationRequest by its request ID.

