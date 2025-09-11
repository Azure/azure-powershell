


# Problems with docs-examples

| Status | Cmdlet | Error |
|--------|--------|-------|
| [ ] | Get-AzQuotaGroupQuotaSubscriptionAllocationRequest | The server responded with a Request Error, Status: NotFound |
| [ ] | Get-AzQuotaGroupQuotaSubscription | SubscriptionId : 0e745469-49f8-48c9-873b-24ca87143db1 is not registered with GroupQuota: ComputeGroupQuota01 |
| [ ] | New-AzQuotaGroupQuotaLocationSetting | The server responded with an unrecognized response, Status: OK |
| [ ] | Update-AzQuotaGroupQuotaSubscriptionAllocationRequest | The subscription : 0e745469-49f8-48c9-873b-24ca87143db1 is not registered with GroupQuotaId: ComputeGroupQuota01. Please register the subscription with GroupQuota, then allocate quota to subscription. |
| [ ] | Update-AzQuotaGroupQuotaLimitsRequest | No subscriptions found for group quota: computegroupquota01. Please add a subscription before creating a Group Quota Limit Request |
| [ ] | Update-AzQuotaGroupQuotaLocationSetting | The server responded with an unrecognized response, Status: OK |
| [ ] | Get-AzQuotaGroupQuotaLocationSetting | EnforcementStatus is not found for GroupId: computegroupquota01, MgId: mg-demo, TenantId: 213e87ed-8e08-4eb4-a63c-c073058f7b00 |
| [ ] | Get-AzQuotaGroupQuotaSubscriptionRequest | Unable to verify that the user that sent this request is the original caller of the asynchronous operation being polled. Please refer to https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/async-operations for more information. |
| [ ] | Get-AzQuotaGroupQuotaUsage | Get-AzQuotaGroupQuotaUsage_List: Expected '{' or '['. Was String: Get. |

# Tests

| Status | Test | Error |
|--------|------|-------|
| [ ] | New-AzQuota.Tests.ps1 CreateExpanded | New-AzQuota_CreateExpanded: Name PublicIPAddresses is not valid resource name. |
| [ ] | All Group tests| fail because they the user id does not have authorisation to update group quota in test env |



# Cleanup

- [ ] mask 0e745469-49f8-48c9-873b-24ca87143db1
