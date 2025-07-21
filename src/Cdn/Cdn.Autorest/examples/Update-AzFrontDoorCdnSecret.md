### Example 1: Update an AzureFrontDoor Secret within the specified AzureFrontDoor profile
```powershell
$secretSourceId = "xxxxxxxx"
$certificateParameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate" -SecretSourceId $secretSourceId  
Update-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001 -Parameter $certificateParameter
```

```output
Name      ResourceGroupName
----      -----------------
secret001 testps-rg-da16jm
```

Update an AzureFrontDoor Secret within the specified AzureFrontDoor profile
