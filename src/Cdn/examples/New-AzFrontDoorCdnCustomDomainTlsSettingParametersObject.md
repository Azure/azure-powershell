### Example 1: Create an in-memory object for AFDDomainHttpsParameters
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
$secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS12" -Secret $secretResoure
```

```output
CertificateType     MinimumTlsVersion
---------------     -----------------
CustomerCertificate TLS12
```

Create an in-memory object for AFDDomainHttpsParameters

