$pfxPassword = "123"

function Get-CertificateSubjectName([string]$certificateName)
{
    return 'CN=' + $certificateName + '.com'
}

function Get-X509FromSecret([string]$keyVault, [string]$secretName)
{
    $secret = Get-AzureKeyVaultSecret $keyVault $secretName
    $secretValueBytes = [System.Convert]::FromBase64String($secret.SecretValueText)
    $x509FromSecretCollection = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
    $x509FromSecretCollection.Import($secretValueBytes)
    $x509FromSecret = $x509FromSecretCollection[0]
    return $x509FromSecret
}

function CreateAKVCertificate(
    [string] $keyVault,
    [string] $certificateName)
{
    $pfxPath = Get-FilePathFromCommonData 'importpfx01.pfx'
    $securePfxPassword = ConvertTo-SecureString $pfxPassword -AsPlainText -Force
    $createdCert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $pfxPath -Password $securePfxPassword
    $global:createdCertificates += $certificateName

    return $createdCert
}

<#
.SYNOPSIS
Import a pfx (pkcs12) file into a certificate
#>

function Test_ImportPfxAsCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'importpfxascertificate'

    $cert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $cert

    # Verify the secret
    Assert-NotNull $cert.Name
    $x509FromSecret = Get-X509FromSecret $keyVault $cert.Name
    Assert-NotNull $x509FromSecret
    Assert-True { Equal-String $x509FromSecret.SubjectName.Name "CN=KeyVaultTest" }
    Assert-True { $x509FromSecret.HasPrivateKey }

    # Verify the key   
    $key = Get-AzureKeyVaultKey $keyVault $cert.Name
    Assert-NotNull $key
}

<#
.SYNOPSIS
Import a pfx (pkcs12) file into a certificate with a non-secure password
#>

function Test_ImportPfxAsCertificateNonSecurePassword
{    
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'importpfxascertificatenonsecurepassword'
    $pfxPath = Get-FilePathFromCommonData 'importpfx01.pfx'
    
    Assert-Throws { $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $pfxPath -Password $pfxPassword }
}

<#
.SYNOPSIS
Import a pfx (pkcs12) file into a certificate without a password
#>

function Test_ImportPfxAsCertificateWithoutPassword
{    
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'importpfxascertificatewithoutpassword'
    $pfxPath = Get-FilePathFromCommonData 'importpfx01.pfx'
    
    Assert-Throws { $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $pfxPath }
}

<#
.SYNOPSIS
Import a X509Certificate2Collection into a certificate
#>

function Test_ImportX509Certificate2CollectionAsCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'importx509certificate2collectionascertificate'

    $pfxBase64 = "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"

    $pfxBytes = [System.Convert]::FromBase64String($pfxBase64)

    $certCollection = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection 
    $certCollection.Import($pfxBytes, "123", [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)

    $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -CertificateCollection $certCollection
    Assert-NotNull $cert

    # Verify the secret
    Assert-NotNull $cert.Name
    $x509FromSecret = Get-X509FromSecret $keyVault $cert.Name
    Assert-NotNull $x509FromSecret
    Assert-True { Equal-String $x509FromSecret.SubjectName.Name "CN=www.fabrikam.com" }
    Assert-True { $x509FromSecret.HasPrivateKey }

    # Verify the key
    $key = Get-AzureKeyVaultKey $keyVault $cert.Name
    Assert-NotNull $key
}

<#
.SYNOPSIS
Import a X509Certificate2Collection into a certificate without the key being marked exportable
#>

function Test_ImportX509Certificate2CollectionNotExportableAsCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'importx509certificate2collectionascertificate'

    $pfxBase64 = "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"

    $pfxBytes = [System.Convert]::FromBase64String($pfxBase64)

    $certCollection = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection 
    $certCollection.Import($pfxBytes, "123", [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::DefaultKeySet)

    Assert-Throws { $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -CertificateCollection $certCollection }
}

<#
.SYNOPSIS
Import a Base64 encoded pfx into a certificate
#>

function Test_ImportBase64EncodedStringAsCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'importbase64encodedstringascertificate'

    $pfxBase64 = "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"

    $pfxPassword = "123"
    $securePfxPassword = ConvertTo-SecureString $pfxPassword -AsPlainText -Force
    $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -CertificateString $pfxBase64 -Password $securePfxPassword
    Assert-NotNull $cert

    # Verify the secret
    Assert-NotNull $cert.Name
    $x509FromSecret = Get-X509FromSecret $keyVault $cert.Name
    Assert-NotNull $x509FromSecret
    Assert-True { Equal-String $x509FromSecret.SubjectName.Name "CN=www.fabrikam.com" }
    Assert-True { $x509FromSecret.HasPrivateKey }

    # Verify the key
    $key = Get-AzureKeyVaultKey $keyVault $cert.Name
    Assert-NotNull $key
}

<#
.SYNOPSIS
Import a Base64 encoded pfx without a password into a certificate
#>

function Test_ImportBase64EncodedStringWithoutPasswordAsCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'importbase64encodedstringwithoutpasswordascertificate'

    $pfxBase64 = "MIIKfAIBAzCCCjwGCSqGSIb3DQEHAaCCCi0EggopMIIKJTCCBg4GCSqGSIb3DQEHAaCCBf8EggX7MIIF9zCCBfMGCyqGSIb3DQEMCgECoIIE9jCCBPIwHAYKKoZIhvcNAQwBAzAOBAgjN3Au0vGugwICB9AEggTQxSMPfYNcmjdNbFSSnWdcyaJzHqdui79OdLFhmLrXc8wxutKRXUOlQbFMgOq6twuKzdeQrKSvy4xjRaIt3bvHbQkWG3lE7Q+W2Xjp2nKZ4pmg8pWkCx0gBMzsjwn3aKfOeiK5pGDI7jnATOGyCc++bE1lWJG/oZWwTvS5iJhiPJybd0znIfGMlYxwLwxDNsIfH6DkPk6XB+sa1fs2j5WZLxiBDeDHV4BNFFJ4VuuOXV164GaNOu169Xi7Ln8S7vMi1t4fnhuxmY60qHRGE3BozAM7A0yOmJKtfZm5kFiiYaE43BMtQQg+vcK6OXVw7u2TmAbDTTIh5RIqdwOiOe9EXFS2F1AfjNWoQTp24CIH2ygeLXFimKGlKISJucHvhRp+KcU64IksXAp1sH42yx8aEg5v26balMYsjBigjsifIuEFJ2/FQqXipwAb2dTvuoh1uskOvqYtip0gV/Guij/paZB23xA0o3GwhwAot6acay3e1yf9ryIUEt8OANBMvxS3/WxfIpEZRCe1hJHEhf+tly/ZvWcJpkl6Pe/kwnFTpsEyHK9szUvqHNzuIIVfUrq4wjE4LCggUEHgGaJvurkbu2n2NIEx+AxNiJEexaRl8uCl9bmJD4oJOofjaQKJGip1211Q3hf/x/Jd5SbMU5lZMPDoD1HyXDskRicUzPHUQpAuG2iYg7NmjISg6Ze1Z73lF69ShK9Etq0XIfu+dsWxNothjvo8uR3sJFzwoSnFFukshurpSdYQBbIm+xZPsCAMz1fOfAKS8GWmOmzLNJRBwx5LYSslDnPUrU9/2c2qtHyNypEIiz9kHXd0drlQIfDabMgImkcRZuh8LbcmOcwCA92kdV7jX8C8qwOza1pqkamnQJRiQQ6e5JXky9Ll3kwCjE9hbTmB2VrgS4HS2vjPfGPBaZ5IDRs3fQSmyKrZQlyQMsmVCYiMR/nYSpS6n0nblvayzJdXyA9lN+WtanQsvnkpNviQsgRJOIkAr75wN3s6K8cvHyKOOtibYKy+NGpSGbE6UsCzobElmqyzT9TnJTCg7koHvM3eq30HHMxwd71/ULAoIl1kksycBbNObgjbArTx5b/r/JbiQMjGsF0dsufTcyl4xUH4F8fEixeyxCgFsKgUn9l8hFeX4+QjRh5bciBhU7yV6ZP1HzpPYhyWUOJFGxIE1pp54SGro8XImgSAfpkkhfd8p6A1bgkFXjLEtO93yxtb1vPFonC8wzWB01cek20vgABX6nqflDm2F75wLDuo4MkFs8CSSV1XhRItPx7dmbciXhT285IxbhDjix/GJKaLmUL/km/2suMIMNn+41W8n3M7iMtSyFMuKl2u9oF5YbcBxkRsI/l837opXC7SC6VNeEjUnDqImS5SNR9YtRzXL/L7jhY1v+aut/cW+fuvEAcorPYmIq2x5PL5cntCn4SGYmMRXnNhX62wYcm6nKUyaSR4f+29+sqI6OTg327KSnnnZfL53XPx0gkVbwSa2i1ujuT6MnPrKqKBvnzGl3/ZFoy6SVSNoPkvSQ+AxIg020uRZn7BnnLUrhEgg14zKjnLaragNVHBDrXtrcbpQxFtxFUXa11Htw+cWMxffuW/JVbphQwzoNJAgTCvNzZhBulUPTeLjSVrDyh0yMkxgekwEwYJKoZIhvcNAQkVMQYEBAEAAAAwVwYJKoZIhvcNAQkUMUoeSAAwADYAMQAxADAAOAA3ADcALQAzADcANQAxAC0ANABiADcANgAtADgAOAA1ADAALQAyAGEANgA2ADYAMwAwADQANgBmAGUAYzB5BgkrBgEEAYI3EQExbB5qAE0AaQBjAHIAbwBzAG8AZgB0ACAARQBuAGgAYQBuAGMAZQBkACAAUgBTAEEAIABhAG4AZAAgAEEARQBTACAAQwByAHkAcAB0AG8AZwByAGEAcABoAGkAYwAgAFAAcgBvAHYAaQBkAGUAcjCCBA8GCSqGSIb3DQEHBqCCBAAwggP8AgEAMIID9QYJKoZIhvcNAQcBMBwGCiqGSIb3DQEMAQYwDgQIASxP9mK8d4ACAgfQgIIDyEzSvzZ5A/rshEqx45iShdofUV7ytp/7vA687VQC+M9IopwqpNI7joaRaNXHJVYENDM/qpRfkUEkoxGY2jo2rN7cUT5LI3XAB81aDTbs3R/u6ozt8FliKqN3e9ITv7+DWKYh3buIKcH5mIXK7yVXOPBr1uPgO/tX9Y6VHtsrId4We1Dd0/xnx3HeN8IyWG4OcYrg1niRSwsGX1Opplz23sm4yA1iGqzszYRfLst05FwEE03HnGy7U5XOvShQSKGxsDiXW8Un0HuAhrtY9n3khcSvMwihxn5LIO9wyRPvTGucFE8brXPXKRoco27RjurbTvxhiJ0E9mHHdabzxORD9swioQTNXO5C0LMCX2WD3OvvieqmOXBz77kn5E9ELHD2DCT3FW7ycoHwV5MuBVoEr84RGkqqncJarqn5FGJPuRqw//XLSCOcziPVkHM37tsfLd1OCH1BGz3+EU3AHxSspL7WzRIBBJXX4pU60kXnLPoR3E6jtAdE2pSlgVtlKiRlyTYqOzRAp7UldweG7RlIIJUVRSWMbu7pdB7SSZsmQEpuRGicnVJvoDP5nXw1WWFAQ56P0kvkZzu3M9cyyM4e86ZSHElsVcXtFoiSOPBJgSvClLgV7Hu+0+bZE7yRqERlRNFP/N/fEUVJ3FsYGJ1vqlKWY7RpjbSOm/aWFWmXOKqF8ke5upevLg8VNiVPvnVjVxPiLBRMYRHnRCgIlXCw0Pheaxe0GwiytzpbgZ7KVkTp4811ixlN75XoWgi0luDDF4477/DcxcSE8CYtDnMrDtJjWR2Q1RP5Fhqrm5AqGmB1ibYd3Z3T7NgrmAWDEJD5emUhQ2+AJ3Lz5rs447dwpkqDXboOvVKq+ZsJzFBkyjAnC/QvD0pHJABH/xqod4cURjda1pWDwbKp1nuYIadlacXjtpjldps0zyrq4JtqfGbXMOupVerFC7g7gNPsm7WN0SLn8D+mTHxpUbF1KZ8FhV+aAjmLYb08tQhj2HuFPfp+xyXru0siuVxhNrq/gRPBhA7/l8qkQbeYGVuTWAyEHS6Lfz/wfQ7pqFGH2uGG/Lm991rLenYKkgORy+kzRj40vgmm2b9N+DbxBkmN5nAMzhpgSH/JAUofafPZmKY4DEWdNIog0WZjfD6uOrvYTiDS4m088f4mRdACWC5ep6/WcWPupGyP6b3RL6TewUzQKhZ95xHmcCZE1zvraN4G68CVRrapP6b6AinI6AoftSZbRuvaZtH2bub9P2z4KxLCx/ZApat+adhdVrFrXtMzHYGxX3mT6GWIljdPMDcwHzAHBgUrDgMCGgQU5BkyRJGOXInsB0WQ8fHNBHcvtSsEFBe+eeNPhqP0bASoHb5LK0+9+hV1"

    $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -CertificateString $pfxBase64
    Assert-NotNull $cert

    # Verify the secret
    Assert-NotNull $cert.Name
    $x509FromSecret = Get-X509FromSecret $keyVault $cert.Name
    Assert-NotNull $x509FromSecret
    Assert-True { Equal-String $x509FromSecret.SubjectName.Name "CN=*.microsoft.com" }
    Assert-True { $x509FromSecret.HasPrivateKey }

    # Verify the key
    $key = Get-AzureKeyVaultKey $keyVault $cert.Name
    Assert-NotNull $key
}

<#
.SYNOPSIS
Merge a cer (signed CSR) into a non-existant key pair
#>

function Test_MergeCerWithNonExistantKeyPair
{    
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'mergecerwithnonexistankeypair'
    
    $cert = CreateAKVCertificate $keyVault $certificateName

    $cerPath = Get-FilePathFromCommonData 'mergecer01.cer'    
    Assert-Throws { $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $cerPath }
}

<#
.SYNOPSIS
Merge a cer (signed CSR) into a non-existant key pair
#>

function Test_MergeCerWithMismatchKeyPair
{    
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'mergecerwithmismatchkeypair'
    $policy = New-AzureKeyVaultCertificatePolicy -DnsNames "test1.keyvault.com", "test2.keyvault.com" -IssuerName "Unknown"
    
    $certRequest = Add-AzureKeyVaultCertificate $keyVault $certificateName $policy
    Assert-NotNull $certRequest
    Assert-NotNull $certRequest.CertificateSigningRequest
    $global:createdCertificates += $certificateName
    
    $cerPath = Get-FilePathFromCommonData 'mergecer01.cer'    
    Assert-Throws { $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $cerPath }
}


<#
.SYNOPSIS
Get a certificate
#>

function Test_GetCertificate 
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'getcertificate'

    $createdCert = CreateAKVCertificate $keyVault $certificateName

    $retrievedCert = Get-AzureKeyVaultCertificate $keyVault $certificateName    
    Assert-NotNull $retrievedCert
    Assert-True { Equal-String $createdCert.Name  $retrievedCert.Name }
}

<#
.SYNOPSIS
Get a non existant certificate
#>

function Test_GetCertificateNonExistant
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'getcertificatenonexistant'
    Assert-Throws { $cert = Get-AzureKeyVaultCertificate $keyVault $certificateName }
}


<#
.SYNOPSIS
Get a certificate in a syntactically bad vault name
#>

function Test_GetCertificateInABadVault
{
    $certificateName = Get-CertificateName 'getcertificatenonexistant'
    Assert-Throws { Get-AzureKeyVaultCertificate '$vaultName' $certificateName }
}

<#
.SYNOPSIS
List the certificates in a vault
#>

function Test_ListCertificates
{
    $keyVault = Get-KeyVault
    
    $certificateName01 = Get-CertificateName 'listcertificates01'
    $createdCert01 = CreateAKVCertificate $keyVault $certificateName01
    Assert-NotNull $createdCert01
    
    $certificateName02 = Get-CertificateName 'listcertificates02'
    $createdCert02 = CreateAKVCertificate $keyVault $certificateName02
    Assert-NotNull $createdCert02
    
    $certificates = Get-AzureKeyVaultCertificate $keyVault
    Assert-NotNull $certificates
    
    Assert-True { $certificates.Count -ge 2 }

    $item01 = $certificates | where { Equal-String $_.Name $certificateName01 } | Select -First 1    
    Assert-NotNull $item01
        
    $item02 = $certificates | where { Equal-String $_.Name $certificateName02 } | Select -First 1    
    Assert-NotNull $item02
}


<#
.SYNOPSIS
Add and get the certificates contacts in a vault
#>

function Test_AddAndGetCertificateContacts
{
    $keyVault = Get-KeyVault
    $originalContacts = @('admin1@contoso.com', 'admin2@contoso.com' )

    $retrievedContacts = Get-AzureKeyVaultCertificateContact $keyVault
    Assert-True { $retrievedContacts.Count -eq 0 }
    
    $setContacts = Add-AzureKeyVaultCertificateContact $keyVault $originalContacts[0] -PassThru
    Assert-True { $setContacts.Count -eq 1 }

    $setContacts =  Add-AzureKeyVaultCertificateContact $keyVault $originalContacts[1] -PassThru
    Assert-True { Equal-OperationList $originalContacts $setContacts.Email }
    
    $retrievedContacts =  Get-AzureKeyVaultCertificateContact $keyVault
    Assert-True { Equal-OperationList $originalContacts $retrievedContacts.Email }

    Remove-AzureKeyVaultCertificateContact $keyVault $originalContacts[1]
    $remainingContacts = Remove-AzureKeyVaultCertificateContact $keyVault $originalContacts[0] -PassThru
    Assert-True { $remainingContacts.Count -eq 0 }

    Assert-Throws { Remove-AzureKeyVaultCertificateContact $keyVault $originalContacts[0] }
}

<#
.SYNOPSIS
Gets a non-existing certificate policy
#>

function Test_GetNonExistingCertificatePolicy
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'getcertificatenonexistant'

    $policy = Get-AzureKeyVaultCertificatePolicy $keyVault $certificateName

    Assert-Null $policy
}

<#
.SYNOPSIS
Create an in-memory certificate policy
#>

function Test_NewCertificatePolicy
{ 
    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -IssuerName Self
    Assert-NotNull $policy
    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -DnsNames "testCertificate.com","testCertificate2.com" -IssuerName Self
    Assert-NotNull $policy
    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -Ekus "1.0","2.0" -IssuerName Self
    Assert-NotNull $policy
    Assert-Throws { $policy = New-AzureKeyVaultCertificatePolicy -Ekus "1.0","2.0" -SecretContentType application/x-pem-file -ReuseKeyOnRenewal -Disabled -RenewAtNumberOfDaysBeforeExpiry 10 -ValidityInMonths 10 -IssuerName Self }
    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -Ekus "1.0","2.0" -SecretContentType application/x-pem-file -ReuseKeyOnRenewal -Disabled -RenewAtNumberOfDaysBeforeExpiry 10 -ValidityInMonths 10 -IssuerName Self
    Assert-NotNull $policy
    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -Ekus "1.0","2.0" -SecretContentType application/x-pem-file -ReuseKeyOnRenewal -Disabled -RenewAtNumberOfDaysBeforeExpiry 10 -ValidityInMonths 10 -IssuerName Self -EmailAtNumberOfDaysBeforeExpiry 15
    Assert-NotNull $policy
}

<#
.SYNOPSIS
Sets a certificate policy on an existing certificate
#>

function Test_SetCertificatePolicy
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'setcertificatepolicycertificate01'

    $createdCert = CreateAKVCertificate $keyVault $certificateName

    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -Ekus "1.0","2.0" -SecretContentType application/x-pem-file -ReuseKeyOnRenewal -Disabled -RenewAtNumberOfDaysBeforeExpiry 10 -ValidityInMonths 10 -IssuerName Self
    $policySet = Set-AzureKeyVaultCertificatePolicy $keyVault $certificateName $policy -PassThru
    Assert-NotNull $policySet
}

<#
.SYNOPSIS
Various organization details/admin details settings
#>

function Test_NewOrganizationDetails
{
    $admin1Details = New-AzureKeyVaultCertificateAdministratorDetails -EmailAddress "admin1@contoso.com"
    Assert-NotNull $admin1Details

    $admin2Details = New-AzureKeyVaultCertificateAdministratorDetails -EmailAddress "admin2@contoso.com" -FirstName "admin" -LastName "2"
    Assert-NotNull $admin2Details
    
    $orgDetails = New-AzureKeyVaultCertificateOrganizationDetails -Id "MSFT" -AdministratorDetails $admin1Details, $admin2Details
    Assert-NotNull $orgDetails
}

<#
.SYNOPSIS
Create SSLAdmin issuer
#>

function Test_CreateSSLAdminIssuer
{
    $keyVault = Get-KeyVault
	$issuerName = "SSLAdminIssuer"
	$issuerProvider = "SSLAdmin"

    $admin1Details = New-AzureKeyVaultCertificateAdministratorDetails -EmailAddress "admin1@contoso.com"
    $admin2Details = New-AzureKeyVaultCertificateAdministratorDetails -EmailAddress "admin2@contoso.com" -FirstName "admin" -LastName "2"
    $admin3Details = New-AzureKeyVaultCertificateAdministratorDetails -EmailAddress "admin3@contoso.com" -FirstName "admin" -LastName "3" -PhoneNumber "425-555-5555"
    $orgDetails = New-AzureKeyVaultCertificateOrganizationDetails -AdministratorDetails $admin1Details, $admin2Details, $admin3Details

	$issuer1 = Set-AzureKeyVaultCertificateIssuer $keyVault $issuerName -IssuerProvider $issuerProvider -OrganizationDetails $orgDetails -PassThru
	Assert-NotNull $issuer1
	Assert-AreEqual $issuer1.Name $issuerName
	Assert-AreEqual $issuer1.IssuerProvider $issuerProvider
	Assert-Null $issuer1.OrganizationDetails
	Assert-Null $issuer1.ApiKey
	Assert-Null $issuer1.AccountName

	# cleanup
	Remove-AzureKeyVaultCertificateIssuer $keyVault $issuerName
}

<#
.SYNOPSIS
Tests Create/Get/Remove issuer cmdlets
#>

function Test_CreateAndGetTestIssuer
{
    $keyVault = Get-KeyVault
    $issuer01Name = "getissuer01"
    $nonExistingIssuerName = "non-existingissuer"

    $adminDetails = New-AzureKeyVaultCertificateAdministratorDetails -EmailAddress "admin@contoso.com" -FirstName "admin" -LastName "admin" -PhoneNumber "425-555-5555"
    $orgDetails = New-AzureKeyVaultCertificateOrganizationDetails -Id "MSFT" -AdministratorDetails $adminDetails

	$issuerAdded = Set-AzureKeyVaultCertificateIssuer $keyVault $issuer01Name -IssuerProvider "Test" -OrganizationDetails $orgDetails -PassThru
	$issuerGotten = Get-AzureKeyVaultCertificateIssuer $keyVault $issuer01Name
	Assert-AreEqual $issuerAdded.Name $issuerGotten.Name

	Assert-Throws { Get-AzureKeyVaultCertificateIssuer $keyVault $nonExistingIssuerName }

	$issuers = Get-AzureKeyVaultCertificateIssuer $keyVault
    Assert-True { $issuers.Count -ge 1 }
    
	$issuer01 = $issuers | where { Equal-String $_.Name $issuer01Name } | Select -First 1
    Assert-NotNull $issuer01

    $issuerGotten = Remove-AzureKeyVaultCertificateIssuer $keyVault $issuer01Name -Force -PassThru
    Assert-NotNull $issuerGotten
    
    Assert-Throws { Remove-AzureKeyVaultCertificateIssuer $keyVault $issuer01Name -Force }
}

<#
.SYNOPSIS
Tests Add-AzureKeyVaultCertificate and AzureKeyVaultCertificateOperation cmdlets
#>

function Test_Add_AzureKeyVaultCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'certWithEnrollment'

    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -IssuerName Self

    # returns is in progress during initial enrollment
    $certificateOperation = Add-AzureKeyVaultCertificate $keyVault $certificateName $policy
    $global:createdCertificates += $certificateName
    Assert-NotNull $certificateOperation

    $pollCount = 0

    while (($certificateOperation.Status -eq 'inProgress') -and ($pollCount -lt 10))
    {
        Assert-NotNull $certificateOperation.CertificateSigningRequest
        Assert-Null $certificateOperation.Information
        Assert-Null $certificateOperation.ErrorCode
        Assert-Null $certificateOperation.ErrorMessage
        Start-Sleep -s 10
        $certificateOperation = Get-AzureKeyVaultCertificateOperation $keyVault $certificateName
        $pollCount++
    }

    # the certificate should have been enrolled by now
    Assert-NotNull $certificateOperation
    Assert-AreEqual "completed" $certificateOperation.Status
    Assert-NotNull $certificateOperation.CertificateSigningRequest
    Assert-Null $certificateOperation.Information
    Assert-Null $certificateOperation.ErrorCode
    Assert-Null $certificateOperation.ErrorMessage

    # check the certificate itself
    $certificate = Get-AzureKeyVaultCertificate $keyVault $certificateName
    Assert-NotNull $certificate
    Assert-NotNull $certificate.Certificate

    # remove the operation now
    $certificateOperation = Remove-AzureKeyVaultCertificateOperation $keyVault $certificateName -Force -PassThru
    Assert-NotNull $certificateOperation

    # it does not exist anymore
    Assert-Throws { Get-AzureKeyVaultCertificateOperation $keyVault $certificateName }
    Assert-Throws { Remove-AzureKeyVaultCertificateOperation $keyVault $certificateName -Force }
}

<#
.SYNOPSIS
Add tags to a certificate
#>

function Test_CertificateTags
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'certificatetags'

    $tags = @{}
    $tags.Add("Org", "Azure")
    $tags.Add("Team", "KeyVault")
    
    $pfxPath = Get-FilePathFromCommonData 'importpfx01.pfx'
    $securePfxPassword = ConvertTo-SecureString $pfxPassword -AsPlainText -Force
    $createdCert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $pfxPath -Password $securePfxPassword -Tag $tags
    $global:createdCertificates += $certificateName
    
    $retrievedCertificate = Get-AzureKeyVaultCertificate $keyVault $certificateName
    Assert-NotNull $retrievedCertificate
    Assert-NotNull $retrievedCertificate.Tags
    Assert-AreEqual $retrievedCertificate.Tags.Count 2
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("Org") $true
    Assert-AreEqual $retrievedCertificate.Tags["Org"] "Azure"
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("Team") $true
    Assert-AreEqual $retrievedCertificate.Tags["Team"] "KeyVault"
}

<#
.SYNOPSIS
Add/Remove/Delete tags to a certificate
#>

function Test_UpdateCertificateTags
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'updatecertificatetags'

    $tags = @{}
    $tags.Add("Org", "Azure")
    $tags.Add("Team", "KeyVault")
    
    $pfxPath = Get-FilePathFromCommonData 'importpfx01.pfx'
    $securePfxPassword = ConvertTo-SecureString $pfxPassword -AsPlainText -Force
    $createdCert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $pfxPath -Password $securePfxPassword -Tag $tags
    $global:createdCertificates += $certificateName
    
    $retrievedCertificate = Get-AzureKeyVaultCertificate $keyVault $certificateName
    Assert-NotNull $retrievedCertificate
    Assert-NotNull $retrievedCertificate.Tags
    Assert-AreEqual $retrievedCertificate.Tags.Count 2
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("Org") $true
    Assert-AreEqual $retrievedCertificate.Tags["Org"] "Azure"
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("Team") $true
    Assert-AreEqual $retrievedCertificate.Tags["Team"] "KeyVault"
    
    # Remove tags
    $tags = @{}
    Set-AzureKeyVaultCertificateAttribute $keyVault $certificateName -Tag $tags
    $retrievedCertificate = Get-AzureKeyVaultCertificate $keyVault $certificateName
    Assert-NotNull $retrievedCertificate
    Assert-NotNull $retrievedCertificate.Tags
    Assert-AreEqual $retrievedCertificate.Tags.Count 0
    
    # Re-create tags
    $tags = @{}
    $tags.Add("Org", "Azure")
    $tags.Add("Team", "KeyVault")
    Set-AzureKeyVaultCertificateAttribute $keyVault $certificateName -Tag $tags
    $retrievedCertificate = Get-AzureKeyVaultCertificate $keyVault $certificateName
    Assert-NotNull $retrievedCertificate
    Assert-NotNull $retrievedCertificate.Tags
    Assert-AreEqual $retrievedCertificate.Tags.Count 2
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("Org") $true
    Assert-AreEqual $retrievedCertificate.Tags["Org"] "Azure"
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("Team") $true
    Assert-AreEqual $retrievedCertificate.Tags["Team"] "KeyVault"
    
    # Update tags
    $tags = @{}
    $tags.Add("State", "Washington")
    $tags.Add("City", "Redmond")
    Set-AzureKeyVaultCertificateAttribute $keyVault $certificateName -Tag $tags
    $retrievedCertificate = Get-AzureKeyVaultCertificate $keyVault $certificateName
    Assert-NotNull $retrievedCertificate
    Assert-NotNull $retrievedCertificate.Tags
    Assert-AreEqual $retrievedCertificate.Tags.Count 2
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("State") $true
    Assert-AreEqual $retrievedCertificate.Tags["State"] "Washington"
    Assert-AreEqual $retrievedCertificate.Tags.ContainsKey("City") $true
    Assert-AreEqual $retrievedCertificate.Tags["City"] "Redmond"
}