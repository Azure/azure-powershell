### Example 1: Create federated identity credential for application
```powershell
New-AzADappfederatedidentitycredential -ApplicationObjectId $appObjectId -Audience api://AzureADTokenExchange -Issuer https://login.microsoftonline.com/3d1e2be9-a10a-4a0c-8380-7ce190f98ed9/v2.0 -name 'test-cred' -Subject 'subject'
```

Create federated identity credential for application

