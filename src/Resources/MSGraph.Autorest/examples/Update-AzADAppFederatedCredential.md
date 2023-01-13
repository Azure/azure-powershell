### Example 1: Update subject for federated identity credential
```powershell
Update-AzADAppFederatedCredential -ApplicationObjectId $appObjectId -FederatedCredentialId $credentialId -Subject 'subject'
```

Update subject for federated identity credential