### Example 1: List the quota request details and status for the scope
```powershell
PS C:\> Get-AzQuotaRequestStatus -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"

Name                                 ProvisioningState ErrorMessage    Code
----                                 ----------------- ------------    ----
171f4e10-f396-48bc-a93f-245cfd7ebe75 Succeeded
0f5636d8-9377-4aec-9a57-5cdeded08615 Succeeded
3ae1cf1d-c792-448f-b2ff-33334ea1a28b Succeeded
5698cdd1-6b4b-4ec1-9a39-a4b5963094dd Succeeded
fb507eaa-f45f-476d-a1a5-77c74b1224b2 Succeeded
22f8a9f1-a003-42a0-9892-474a0478ceea Succeeded
103e114c-3894-4b33-a673-b3d814eea753 Succeeded
9decdd61-be39-4815-96d7-dfad78674940 Succeeded
3a4c474e-cfb1-4af6-baff-0f0bfea67b61 Succeeded
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