---
Module Name: Az.Quota
Module Guid: bd26548c-ac2c-4447-9d5d-2e4d8c622495
Download Help Link: https://docs.microsoft.com/powershell/module/az.quota
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Quota Module
## Description
Microsoft Azure PowerShell: Quota cmdlets

## Az.Quota Cmdlets
### [Get-AzQuota](Get-AzQuota.md)
Gets the quota limit and current quota usage of a resource.
The response can be used to determine the remaining quota and calculate a new quota limit that can be submitted with a PUT request.

### [Get-AzQuotaRequestStatus](Get-AzQuotaRequestStatus.md)
Gets the quota request details and status by quota request ID for the resources of the resource provider at a specific location.
The quota request ID **id** is returned in the response of the PUT operation.

### [Get-AzQuotaResourceProvider](Get-AzQuotaResourceProvider.md)
Gets the list of current resource providers supported by the Microsoft.Quota resource provider.\r\nFor each resource provider, the resource templates the resource provider supports are be provided.
\r\nFor each resource template, the resource dimensions are listed.
The resource dimensions are the name-value pairs in the resource URI.\r\nExample: Microsoft.Compute Resource Provider\r\nThe URI template is '/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{locationId}/quotaBucket'.
The actual dimensions vary depending on the resource provider.\r\nThe resource dimensions are {subscriptions},{locations},{quotaBucket}.

### [New-AzQuota](New-AzQuota.md)
Create or update the quota limit for the specified resource to the requested value.
To update the quota, follow these steps:\n1.
Use the GET operation to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.

### [Set-AzQuota](Set-AzQuota.md)
Create or update the quota limit for the specified resource to the requested value.
To update the quota, follow these steps:\n1.
Use the GET operation to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.

### [Update-AzQuota](Update-AzQuota.md)
Update the quota limit for a specific resource to the specified value:\n1.
Use the GET operation to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.

