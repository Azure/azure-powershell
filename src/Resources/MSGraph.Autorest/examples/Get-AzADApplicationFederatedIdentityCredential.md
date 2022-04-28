### Example 1: List federated identity credentials for application
```powershell
PS C:\> Get-AzADApplication -ObjectId $app | Get-AzADApplicationFederatedCredential
```

List federated identity credentials for application

### Example 2: Get federated identity credential by id
```powershell
PS C:\> Get-AzADApplicationFederatedCredential -ApplicationObjectId $appObjectId -Id $credentialId
```

Get federated identity credential by id

