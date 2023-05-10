### Example 1: List federated identity credentials under a user assigned identity
```powershell
Get-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01
```

```output
Name       Issuer                               Subject                               Audience
----       ------                               -------                               --------
fic-pwsh01 https://kubernetes-oauth.azure.com   system:serviceaccount:ns:svcaccount   {api://AzureADTokenExchange}
fic-pwsh02 https://kubernetes-oauth-2.azure.com system:serviceaccount-2:ns:svcaccount {api://AzureADTokenExchange}
```

This command lists federated identity credentials under a user assigned identity.

### Example 2: Get a federated identity credential
```powershell
Get-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01
```

```output
Name       Issuer                             Subject                             Audience
----       ------                             -------                             --------
fic-pwsh01 https://kubernetes-oauth.azure.com system:serviceaccount:ns:svcaccount {api://AzureADTokenExchange}
```

This command gets a federated identity credential by name.

### Example 3: Get a federated identity credential by pipeline
```powershell
New-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh03 -Issuer "https://kubernetes-oauth-3.azure.com" -Subject "system:serviceaccount-3:ns:svcaccount" `
        | Get-AzFederatedIdentityCredentials
```

```output
Name       Issuer                               Subject                               Audience
----       ------                               -------                               --------
fic-pwsh03 https://kubernetes-oauth-3.azure.com system:serviceaccount-3:ns:svcaccount {api://AzureADTokenExchange}
```

This command creates and gets a federated identity credential by pipeline.