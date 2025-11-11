# EXAMPLES

## Example 1: Get the status of a subscription request by requestId
```
$requestId = "abcd1234-5678-90ef-ghij-1234567890ab"
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName "ComputeGroupQuota01" -ManagementGroupId "mg-demo" -RequestId $requestId
```

```output
RequestId                                Status     Subscriptions
---------                                ------     -------------
abcd1234-5678-90ef-ghij-1234567890ab     Succeeded  0e745469-49f8-48c9-873b-24ca87143db1
```

This example gets the status of a subscription request using the request ID stored in `$requestId` for the group quota "ComputeGroupQuota01".

## Example 2: List all subscription requests for a GroupQuota
```
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName "ComputeGroupQuota01" -ManagementGroupId "mg-demo"
```

```output
RequestId                                Status     Subscriptions
---------                                ------     -------------
abcd1234-5678-90ef-ghij-1234567890ab     Succeeded  0e745469-49f8-48c9-873b-24ca87143db1
bcde2345-6789-01fg-hijk-2345678901bc     Failed     1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d
```

This example lists all subscription requests for the group quota "ComputeGroupQuota01" in the management group "mg-demo".

