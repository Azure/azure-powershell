### Example 1: Update an AzureFrontDoor customdomain under the profile
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
$secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
$updateTlsSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure
Update-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001 -TlsSetting $updateSetting
```

```output
Name      ResourceGroupName
----      -----------------
domain001 testps-rg-da16jm
```

Update an AzureFrontDoor customdomain under the profile


### Example 2: Update an AzureFrontDoor customdomain under the profile via identity
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
$secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
$updateTlsSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure
Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001 | Update-AzFrontDoorCdnCustomDomain -TlsSetting $updateSetting
```

```output
Name      ResourceGroupName
----      -----------------
domain001 testps-rg-da16jm
```

Update an AzureFrontDoor customdomain under the profile via identity

