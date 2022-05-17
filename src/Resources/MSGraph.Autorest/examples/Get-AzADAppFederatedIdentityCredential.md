### Example 1: List federated identity credentials for application
```powershell
Get-AzADApplication -ObjectId $app | Get-AzADAppFederatedCredential
```

List federated identity credentials for application

### Example 2: Get federated identity credential by id
```powershell
Get-AzADAppFederatedCredential -ApplicationObjectId $appObjectId -Id $credentialId
```

Get federated identity credential by id

