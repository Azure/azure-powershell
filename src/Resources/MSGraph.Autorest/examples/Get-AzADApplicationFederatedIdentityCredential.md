### Example 1: List federated identity credentials for application
```powershell
Get-AzADApplication -ObjectId $app | Get-AzADApplicationFederatedCredential
```

List federated identity credentials for application

### Example 2: Get federated identity credential by id
```powershell
Get-AzADApplicationFederatedCredential -ApplicationObjectId $appObjectId -Id $credentialId
```

Get federated identity credential by id

