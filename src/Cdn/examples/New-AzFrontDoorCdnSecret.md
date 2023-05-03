### Example 1: Create an AzureFrontDoor Secret within the specified AzureFrontDoor profile
```powershell
$secretSourceId = "xxxxxxxx"      
$certificateParameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate" -SecretSourceId $secretSourceId  
New-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001 -Parameter $certificateParameter           
```

```output
Name      ResourceGroupName
----      -----------------
secret001 testps-rg-da16jm
```

Create an AzureFrontDoor Secret within the specified AzureFrontDoor profile