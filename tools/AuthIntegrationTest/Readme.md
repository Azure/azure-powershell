## Deploy ServicePrincipal Test Required Application
```pwsh
Connect-AzAccount -Tenant "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
./DeployServicePrincipal.ps1 -Path "./" -PfxFileName "AzAccountTestCertificate.pfx"
```

# Test Az.Account Upgrading with ServicePrincipal flows
```pwsh
./TestServicePrincipalAuthFlow.ps1 -UsePassword  -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -AzAccountsVersionFrom 2.19.0 -AzAccountsVersionTo 3.0.1

./TestServicePrincipalAuthFlow.ps1 -UseThumbprint -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -AzAccountsVersionFrom 2.19.0 -AzAccountsVersionTo 3.0.1 -Path D:/temp/ -PfxFileName AzAccountTestCertificate.pfx

./TestServicePrincipalAuthFlow.ps1 -UseCertificateFile -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -AzAccountsVersionFrom 2.19.0 -AzAccountsVersionTo 3.0.1 -Path D:/temp/ -PfxFileName AzAccountTestCertificate.pfx
```


