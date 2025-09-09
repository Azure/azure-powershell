# EXAMPLES

## Example 1: Check the status of a GroupQuota request by requestId
```
Get-AzQuotaGroupQuotaLimitsRequest -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -RequestId "<guid>"
```

```output
RequestId   Status     ResourceType   SubmittedAt           CompletedAt
---------   ------     ------------   -------------------   -------------------
<guid>      Succeeded  Compute        2025-09-01T10:00:00Z  2025-09-01T10:05:00Z
```

This example checks the status of a GroupQuota request for "ComputeGroupQuota01" in management group "mg-demo" using the specified requestId.

## Example 2: List all GroupQuota requests for a resource and location
```
Get-AzQuotaGroupQuotaLimitsRequest -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -ResourceProviderName "Microsoft.Compute" -Filter "location eq eastus and resourceName eq Standard_DS1_v2"
```

```output
RequestId   Status     ResourceType   Location   ResourceName         SubmittedAt
---------   ------     ------------   --------   ------------         -------------------
<guid>      Succeeded  Compute        eastus     Standard_DS1_v2      2025-09-01T10:00:00Z
<guid>      Failed     Compute        eastus     Standard_DS1_v2      2025-09-01T09:00:00Z
```

This example lists all GroupQuota requests for "ComputeGroupQuota01" in management group "mg-demo" for the resource provider "Microsoft.Compute" and resource "Standard_DS1_v2" in "eastus".

