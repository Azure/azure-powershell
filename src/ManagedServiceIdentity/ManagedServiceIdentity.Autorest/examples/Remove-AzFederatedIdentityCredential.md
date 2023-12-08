### Example 1: Delete federated identity credential
```powershell
Remove-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01
```

This command deletes a federated identity credential.

### Example 2: Delete federated identity credential by pipeline
```powershell
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01 | Remove-AzFederatedIdentityCredential
```

This command deletes a federated identity credential by pipeline.