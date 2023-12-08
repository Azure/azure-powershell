### Example 1: Creates an AzureFrontDoor domain within the specified AzureFrontDoor profile
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
$secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
$tlsSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS12" -Secret $secretResoure
New-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001 -HostName "pstest001.dev.cdn.azure.cn" -TlsSetting $tlsSetting
```

```output
Name      ResourceGroupName
----      -----------------
domain001 testps-rg-da16jm
```

Creates an AzureFrontDoor domain within the specified AzureFrontDoor profile
