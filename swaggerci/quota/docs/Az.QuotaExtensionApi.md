---
Module Name: Az.QuotaExtensionApi
Module Guid: 8184d481-1cae-4edf-b582-c2071460c705
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.quotaextensionapi
Help Version: 1.0.0.0
Locale: en-US
---

# Az.QuotaExtensionApi Module
## Description
Microsoft Azure PowerShell: QuotaExtensionApi cmdlets

## Az.QuotaExtensionApi Cmdlets
### [Get-AzQuotaExtensionApiQuota](Get-AzQuotaExtensionApiQuota.md)
Get the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.

### [Get-AzQuotaExtensionApiQuotaOperation](Get-AzQuotaExtensionApiQuotaOperation.md)
List all the operations supported by the Microsoft.Quota resource provider.

### [Get-AzQuotaExtensionApiQuotaRequestStatus](Get-AzQuotaExtensionApiQuotaRequestStatus.md)
Get the quota request details and status by quota request ID for the resources of the resource provider at a specific location.
The quota request ID **id** is returned in the response of the PUT operation.

### [Get-AzQuotaExtensionApiUsage](Get-AzQuotaExtensionApiUsage.md)
Get the current usage of a resource.

### [New-AzQuotaExtensionApiQuota](New-AzQuotaExtensionApiQuota.md)
Create or update the quota limit for the specified resource with the requested value.
To update the quota, follow these steps:\n1.
Use the GET operation for quotas and usages to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.
Please check the URI in location header for the detailed status of the request.

### [Update-AzQuotaExtensionApiQuota](Update-AzQuotaExtensionApiQuota.md)
Update the quota limit for a specific resource to the specified value:\n1.
Use the Usages-GET and Quota-GET operations to determine the remaining quota for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.
Please check the URI in location header for the detailed status of the request.

