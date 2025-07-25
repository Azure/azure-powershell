### Example 1: List AzureFrontDoor secret under the profile
```powershell
Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
Name      ResourceGroupName
----      -----------------
secret001 testps-rg-da16jm
secret002 testps-rg-da16jm
```

List AzureFrontDoor secret under the profile


### Example 2: Get an AzureFrontDoor secret under the profile
```powershell
Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
```

```output
Name      ResourceGroupName
----      -----------------
secret001 testps-rg-da16jm
```

Get an AzureFrontDoor secret under the profile


### Example 2: Get an AzureFrontDoor secret under the profile via identity
```powershell
$secretSourceId = "xxxxxxxx"      
$certificateParameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate" -SecretSourceId $secretSourceId  
New-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001 -Parameter $certificateParameter | Get-AzFrontDoorCdnSecret
```

```output
Name      ResourceGroupName
----      -----------------
secret001 testps-rg-da16jm
```

Get an AzureFrontDoor secret under the profile via identity

