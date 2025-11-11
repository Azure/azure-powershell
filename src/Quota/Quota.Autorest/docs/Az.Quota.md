---
Module Name: Az.Quota
Module Guid: 731766b6-b5c1-4e10-83fa-065919e1b0fb
Download Help Link: https://learn.microsoft.com/powershell/module/az.quota
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Quota Module
## Description
Microsoft Azure PowerShell: Quota cmdlets

## Az.Quota Cmdlets
### [Get-AzQuota](Get-AzQuota.md)
Get the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.

### [Get-AzQuotaGroupQuota](Get-AzQuotaGroupQuota.md)
Gets the GroupQuotas for the name passed.
It will return the GroupQuotas properties only.
The details on group quota can be access from the group quota APIs.

### [Get-AzQuotaGroupQuotaLimit](Get-AzQuotaGroupQuotaLimit.md)
Gets the GroupQuotaLimits for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}.

### [Get-AzQuotaGroupQuotaLimitsRequest](Get-AzQuotaGroupQuotaLimitsRequest.md)
Get API to check the status of a GroupQuota request by requestId.

### [Get-AzQuotaGroupQuotaLocationSetting](Get-AzQuotaGroupQuotaLocationSetting.md)
Gets the GroupQuotas enforcement settings for the ResourceProvider/location.
The locations, where GroupQuota enforcement is not enabled will return Not Found.

### [Get-AzQuotaGroupQuotaSubscription](Get-AzQuotaGroupQuotaSubscription.md)
Returns the subscriptionIds along with its provisioning state for being associated with the GroupQuota.
If the subscription is not a member of GroupQuota, it will return 404, else 200.

### [Get-AzQuotaGroupQuotaSubscriptionAllocation](Get-AzQuotaGroupQuotaSubscriptionAllocation.md)
Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}.
This will include the GroupQuota and total quota allocated to the subscription.
Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.

### [Get-AzQuotaGroupQuotaSubscriptionAllocationRequest](Get-AzQuotaGroupQuotaSubscriptionAllocationRequest.md)
Get the quota allocation request status for the subscriptionId by allocationId.

### [Get-AzQuotaGroupQuotaSubscriptionRequest](Get-AzQuotaGroupQuotaSubscriptionRequest.md)
Get API to check the status of a subscriptionIds request by requestId.
Use the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status.
This API provides the finals status with the request details and status.

### [Get-AzQuotaGroupQuotaUsage](Get-AzQuotaGroupQuotaUsage.md)
Gets the GroupQuotas usages and limits(quota).
Location is required paramter.

### [Get-AzQuotaOperation](Get-AzQuotaOperation.md)
List the operations for the provider

### [Get-AzQuotaRequestStatus](Get-AzQuotaRequestStatus.md)
Get the quota request details and status by quota request ID for the resources of the resource provider at a specific location.
The quota request ID **id** is returned in the response of the PUT operation.

### [Get-AzQuotaUsage](Get-AzQuotaUsage.md)
Get the current usage of a resource.

### [New-AzQuota](New-AzQuota.md)
Create the quota limit for the specified resource with the requested value.
To create the quota, follow these steps:\n1.
Use the GET operation for quotas and usages to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to create the quota limit.
Please check the URI in location header for the detailed status of the request.

### [New-AzQuotaGroupQuota](New-AzQuotaGroupQuota.md)
Create a new GroupQuota for the name passed.
A RequestId will be returned by the Service.
The status can be polled periodically.
The status Async polling is using standards defined at - https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/async-api-reference.md#asynchronous-operations.
Use the OperationsStatus URI provided in Azure-AsyncOperation header, the duration will be specified in retry-after header.
Once the operation gets to terminal state - Succeeded | Failed, then the URI will change to Get URI and full details can be checked.

### [New-AzQuotaGroupQuotaLocationSetting](New-AzQuotaGroupQuotaLocationSetting.md)
Enables the GroupQuotas enforcement for the resource provider and the location specified.
The resource provider will start using the group quotas as the overall quota for the subscriptions included in the GroupQuota.
The subscriptions cannot request quota at subscription level since it is now part of an enforced group.\nThe subscriptions share the GroupQuotaLimits assigned to the GroupQuota.
If the GroupQuotaLimits is used, then submit a groupQuotaLimit request for the specific resource - provider/location/resource.\nOnce the GroupQuota Enforcement is enabled then, it cannot be deleted or reverted back.
To disable GroupQuota Enforcement -\n1.
Remove all the subscriptions from the groupQuota using the delete API for Subscriptions (Check the example - GroupQuotaSubscriptions_Delete).\n2.
Then delete the GroupQuota (Check the example - GroupQuotas_Delete).

### [New-AzQuotaLimitObject](New-AzQuotaLimitObject.md)
Create an in-memory object for LimitObject.

### [Remove-AzQuotaGroupQuota](Remove-AzQuotaGroupQuota.md)
Deletes the GroupQuotas for the name passed.
All the remaining shareQuota in the GroupQuotas will be lost.

### [Remove-AzQuotaGroupQuotaSubscription](Remove-AzQuotaGroupQuotaSubscription.md)
Removes the subscription from GroupQuotas.
The request's TenantId is validated against the subscription's TenantId.

### [Update-AzQuota](Update-AzQuota.md)
Update the quota limit for a specific resource to the specified value:\n1.
Use the Usages-GET and Quota-GET operations to determine the remaining quota for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.
Please check the URI in location header for the detailed status of the request.

### [Update-AzQuotaGroupQuota](Update-AzQuotaGroupQuota.md)
Update the GroupQuotas for the name passed.
A GroupQuotas RequestId will be returned by the Service.
The status can be polled periodically.
The status Async polling is using standards defined at - https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/async-api-reference.md#asynchronous-operations.
Use the OperationsStatus URI provided in Azure-AsyncOperation header, the duration will be specified in retry-after header.
Once the operation gets to terminal state - Succeeded | Failed, then the URI will change to Get URI and full details can be checked.\nAny change in the filters will be applicable to the future quota assignments, existing quota allocated to subscriptions from the GroupQuotas remains unchanged.

### [Update-AzQuotaGroupQuotaLimitsRequest](Update-AzQuotaGroupQuotaLimitsRequest.md)
Update the GroupQuota requests for a specific ResourceProvider/Location/Resource.
The resourceName properties are specified in the request body.
Only 1 resource quota can be requested.
Please note that patch request update a new groupQuota request.\nUse the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status.
This API provides the finals status with the request details and status.

### [Update-AzQuotaGroupQuotaLocationSetting](Update-AzQuotaGroupQuotaLocationSetting.md)
Enables the GroupQuotas enforcement for the resource provider and the location specified.
The resource provider will start using the group quotas as the overall quota for the subscriptions included in the GroupQuota.
The subscriptions cannot request quota at subscription level since it is now part of an enforced group.\nThe subscriptions share the GroupQuotaLimits assigned to the GroupQuota.
If the GroupQuotaLimits is used, then submit a groupQuotaLimit request for the specific resource - provider/location/resource.\nOnce the GroupQuota Enforcement is enabled then, it cannot be deleted or reverted back.
To disable GroupQuota Enforcement -\n1.
Remove all the subscriptions from the groupQuota using the delete API for Subscriptions (Check the example - GroupQuotaSubscriptions_Delete).\n2.
Ten delete the GroupQuota (Check the example - GroupQuotas_Delete).

### [Update-AzQuotaGroupQuotaSubscriptionAllocationRequest](Update-AzQuotaGroupQuotaSubscriptionAllocationRequest.md)
Request to assign quota from group quota to a specific Subscription.
The assign GroupQuota to subscriptions or reduce the quota allocated to subscription to give back the unused quota ( quota \>= usages) to the groupQuota.
So, this API can be used to assign Quota to subscriptions and assign back unused quota to group quota, which can be assigned to another subscriptions in the GroupQuota.
User can collect unused quotas from multiple subscriptions within the groupQuota and assign the groupQuota to the subscription, where it's needed.

