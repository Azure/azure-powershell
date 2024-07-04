## Deploy ServicePrincipal Test Required Application
```pwsh
Connect-AzAccount -Tenant "54826b22-38d6-4fb2-bad9-b7b93a3e9c5a"
.\DeployServicePrincipal.ps1 -Path './' -PfxFileName 'AzAccountTestCertificate.pfx'
```

- Result
  - Application
    https://portal.azure.com/#view/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/~/Overview/appId/74ed8837-2559-4387-9e74-fa4d980652d5
  - Sp Secret
    https://portal.azure.com/#@AzureSDKTeam.onmicrosoft.com/asset/Microsoft_Azure_KeyVault/Secret/https://livetestkeyvault.vault.azure.net/secrets/AzAccountsTestSecret
  - Sp Certificate
    https://portal.azure.com/#@AzureSDKTeam.onmicrosoft.com/asset/Microsoft_Azure_KeyVault/Certificate/https://livetestkeyvault.vault.azure.net/certificates/AzAccountsTestCertificate


# Test Az.Account Upgrading with ServicePrincipal flows
```pwsh
.\TestAzAccountsUpgradeBySp.ps1 -AzAccountsVersionFrom 2.17.0 -AzAccountsVersionTo 3.0.1 -Path "D:\repos\azure-powershell\tools\TestAzAccounts\" -PfxFileName "AzAccountTestCertificate.pfx" -Debug
```


