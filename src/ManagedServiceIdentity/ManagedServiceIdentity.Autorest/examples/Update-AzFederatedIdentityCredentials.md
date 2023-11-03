### Example 1: Update federated identity credential under the specified user assigned identity
```powershell
Update-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh01 -Issuer "https://kubernetes-oauth-upd.azure.com" -Subject "system:serviceaccount-upd:ns:svcaccount"
```

```output
Name       Issuer                                 Subject                                 Audience
----       ------                                 -------                                 --------
fic-pwsh01 https://kubernetes-oauth-upd.azure.com system:serviceaccount-upd:ns:svcaccount {api://AzureADTokenExchange}
```

This command updates a federated identity credential under the specified user assigned identity.

### Example 2: Update federated identity credential under the specified user assigned identity by pipeline
```powershell
Get-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01 `
    | Update-AzFederatedIdentityCredentials -Issuer "https://kubernetes-oauth-upd.azure.com" -Subject "system:serviceaccount-upd:ns:svcaccount"
```

```output
Name       Issuer                                 Subject                                 Audience
----       ------                                 -------                                 --------
fic-pwsh01 https://kubernetes-oauth-upd.azure.com system:serviceaccount-upd:ns:svcaccount {api://AzureADTokenExchange}
```

This command updates a federated identity credential under the specified user assigned identity by pipeline.
