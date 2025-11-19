### Example 1: Update GroupQuotasSubscriptionAllocationRequest for a GroupQuota and Subscription
```powershell
$limitObject = New-AzQuotaLimitObject -Value 50
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -SubscriptionId "<subscription>" -Region "eastus" -Limit $limitObject
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Accepted          50
```

Updates a GroupQuotasSubscriptionAllocationRequest for a specified GroupQuota, resource provider, resource, subscription, and region with new quota allocation limits.

