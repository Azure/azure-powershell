## Deploy ServicePrincipal Test Required Application
```pwsh
Connect-AzAccount -Tenant "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
./DeployServicePrincipal.ps1 -Path "./" -PfxFileName "AzAccountTestCertificate.pfx"
```

# Test Az.Account Upgrading with ServicePrincipal flows
```pwsh
./TestServicePrincipalAuthFlow.ps1 -AzAccountsVersionFrom 2.17.0 -AzAccountsVersionTo 3.0.1 -Path "D:/temp/ -PfxFileName "AzAccountTestCertificate.pfx"
```


