### Example 1: List the quota request details and status for the scope
```powershell
PS C:\> Get-AzQuotaRequestStatus -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"

Name                                 ProvisioningState ErrorMessage    Code
----                                 ----------------- ------------    ----
6cf5716a-3df8-421a-8457-719e10381dbc Failed            Request failed. QuotaReductionNotSupported
```

This command lists the quota request details and status for the scope.

### Example 2: Get the quota request details and status by quota request ID for the resources of the resource provider at a specific location
```powershell
PS C:\> Get-AzQuotaRequestStatus -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -Id "6cf5716a-3df8-421a-8457-719e10381dbc"

Name                                 ProvisioningState ErrorMessage    Code
----                                 ----------------- ------------    ----
6cf5716a-3df8-421a-8457-719e10381dbc Failed            Request failed. QuotaReductionNotSupported
```

This command gets the quota request details and status by quota request ID for the resources of the resource provider at a specific location.
The quota request ID **id** is returned in the response of the PUT operation.