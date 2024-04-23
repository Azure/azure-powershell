---
Module Name: Az.Quota
Module Guid: bd26548c-ac2c-4447-9d5d-2e4d8c622495
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

### [Get-AzQuotaOperation](Get-AzQuotaOperation.md)
List all the operations supported by the Microsoft.Quota resource provider.

### [Get-AzQuotaRequestStatus](Get-AzQuotaRequestStatus.md)
Get the quota request details and status by quota request ID for the resources of the resource provider at a specific location.
The quota request ID **id** is returned in the response of the PUT operation.

### [Get-AzQuotaUsage](Get-AzQuotaUsage.md)
Get the current usage of a resource.

### [New-AzQuota](New-AzQuota.md)
Create the quota limit for the specified resource with the requested value.
To Create the quota, follow these steps:\n1.
Use the GET operation for quotas and usages to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to Create the quota limit.
Please check the URI in location header for the detailed status of the request.

### [New-AzQuotaLimitObject](New-AzQuotaLimitObject.md)
Create an in-memory object for LimitObject.

### [Update-AzQuota](Update-AzQuota.md)
Update the quota limit for a specific resource to the specified value:\n1.
Use the Usages-GET and Quota-GET operations to determine the remaining quota for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to Update the quota limit.
Please check the URI in location header for the detailed status of the request.

