$pfxPassword = "123"

function Get-CertificateSubjectName([string]$certificateName)
{
    return 'CN=' + $certificateName + '.com'
}

function Get-X509FromSecretBySubjectDistinguishedName([string]$keyVault, [string]$secretName, [string]$subjectDistinguishedName)
{
    $secret = Get-AzureKeyVaultSecret $keyVault $secretName
    $secretValueBytes = [System.Convert]::FromBase64String($secret.SecretValueText)
    $x509FromSecretCollection = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
    $x509FromSecretCollection.Import($secretValueBytes)
    $x509Matches = $x509FromSecretCollection.Find([Security.Cryptography.X509Certificates.X509FindType]::FindBySubjectDistinguishedName, $subjectDistinguishedName, $false)
    $matchCount = $x509Matches.Count
    Assert-True { $matchCount -le 1 } "There should be at most one cert in the collection with the subject distinguished name '$subjectDistinguishedName'." | Out-Null

    if ($matchCount -eq 0)
    {
        return $null
    }

    return $x509Matches[0]
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
    $x509FromSecret = Get-X509FromSecretBySubjectDistinguishedName $keyVault $cert.Name "CN=KeyVaultTest"
    Assert-NotNull $x509FromSecret
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
    $certCollection.Import($pfxBytes, "1234", [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)

    $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -CertificateCollection $certCollection
    Assert-NotNull $cert

    # Verify the secret
    Assert-NotNull $cert.Name
    $x509FromSecret = Get-X509FromSecretBySubjectDistinguishedName $keyVault $cert.Name "CN=contoso.com, O=Contoso, L=Portland, S=Oregon, C=US"
    Assert-NotNull $x509FromSecret
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
    $certCollection.Import($pfxBytes, "1234", [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::DefaultKeySet)

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

    $pfxPassword = "1234"
    $securePfxPassword = ConvertTo-SecureString $pfxPassword -AsPlainText -Force
    $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -CertificateString $pfxBase64 -Password $securePfxPassword
    Assert-NotNull $cert

    # Verify the secret
    Assert-NotNull $cert.Name
    $x509FromSecret = Get-X509FromSecretBySubjectDistinguishedName $keyVault $cert.Name "CN=contoso.com, O=Contoso, L=Portland, S=Oregon, C=US"
    Assert-NotNull $x509FromSecret
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

    $pfxBase64 = "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"

    $cert = Import-AzureKeyVaultCertificate $keyVault $certificateName -CertificateString $pfxBase64
    Assert-NotNull $cert

    # Verify the secret
    Assert-NotNull $cert.Name
    $x509FromSecret = Get-X509FromSecretBySubjectDistinguishedName $keyVault $cert.Name "CN=*.microsoft.com"
    Assert-NotNull $x509FromSecret
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
    $cert = Get-AzureKeyVaultCertificate $keyVault $certificateName
    Assert-Null $cert
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

    $customEkus = @("1.0", "2.0")
    $customKeyUsage = @("DecipherOnly", "KeyCertSign")
    $policy = New-AzureKeyVaultCertificatePolicy -SubjectName "CN=testCertificate" -Ekus $customEkus -SecretContentType application/x-pem-file -ReuseKeyOnRenewal -Disabled -RenewAtNumberOfDaysBeforeExpiry 10 -ValidityInMonths 10 -IssuerName Self -KeyUsage $customKeyUsage
    Assert-NotNull $policy
    Assert-NotNull $policy.KeyUsage
    Assert-True { Equal-OperationList $policy.KeyUsage $customKeyUsage }
    Assert-NotNull $policy.Ekus
    Assert-True { Equal-OperationList $policy.Ekus $customEkus }
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

    $noneexisting = Get-AzureKeyVaultCertificateIssuer $keyVault $nonExistingIssuerName
	Assert-Null $noneexisting

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
    $certop = Get-AzureKeyVaultCertificateOperation $keyVault $certificateName
    Assert-Null $certop
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


<#
.SYNOPSIS
Tests getting a previously deleted certificate
#>

function Test_GetDeletedCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'getdeletedcertificate'

    $createdCert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $createdCert

    $global:createdCertificates += $certificateName

    $createdCertificate | Remove-AzureKeyVaultCertificate -Force -Confirm:$false

    Wait-ForDeletedCertificate $keyVault $certificateName

    $deletedCertificate = Get-AzureKeyVaultCertificate -VaultName $keyVault.VaultName -Name $certificateName -InRemovedState
    Assert-NotNull $deletedCertificate
    Assert-NotNull $deletedCertificate.DeletedDate
    Assert-NotNull $deletedCertificate.ScheduledPurgeDate
}


<#
.SYNOPSIS
Tests listing all previously deleted certificates
#>
function Test_GetDeletedCertificates
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'getdeletedcertificates'
    $createdCert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $createdCert

    $global:createdCertificates += $certificateName

    $createdCertificate | Remove-AzureKeyVaultCertificate -Force -Confirm:$false

    Wait-ForDeletedCertificate $keyVault $certificateName

    $deletedCerts = Get-AzureKeyVaultCertificate -VaultName $keyVault.VaultName -InRemovedState
    Assert-True {$deletedCerts.Count -ge 1}
    Assert-True {$deletedCerts.Name -contains $key.Name}
}

<#
.SYNOPSIS
Tests recovering a previously deleted certificate.
#>

function Test_UndoRemoveCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'undoremovedcert'
    $createdCert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $createdCert

    $global:createdCertificates += $certificateName

    $createdCertificate | Remove-AzureKeyVaultCertificate -Force -Confirm:$false

    Wait-ForDeletedCertificate $keyVault $certificateName

    $recoveredCert = Undo-AzureKeyVaultCertificateRemoval -VaultName $keyVault.VaultName -Name $certificateName

    Assert-NotNull $recoveredCert
    Assert-AreEqual $recoveredCert.Name $createdCert.Name
    Assert-AreEqual $recoveredCert.Version $createdCert.Version
    #Assert-KeyAttributes $recoveredKey.Attributes 'RSA' $false $expires $nbf $ops $tags 
}

<#
.SYNOPSIS
Tests purging a deleted certificate.
#>

function Test_RemoveDeletedCertificate
{
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'undoremovedcert'
    $createdCert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $createdCert

    $global:createdCertificates += $certificateName

    $createdCertificate | Remove-AzureKeyVaultCertificate -Force -Confirm:$false

    Wait-ForDeletedCertificate $keyVault $certificateName

    Remove-AzureKeyVaultCertificate -VaultName $keyVault.VaultName -Name $certificateName -InRemovedState -Force -Confirm:$false
}

<#
.SYNOPSIS
Tests purging an active certificate
#>
function Test_RemoveNonExistDeletedCertificate
{
    $keyVault = Get-KeyVault
    $certName = Get-CertificateName 'purgeactivecert'

    $createdCert = CreateAKVCertificate $keyVault $certName
    Assert-NotNull $createdCert

    $global:createdCertificates += $certName

    Assert-Throws {Remove-AzureKeyVaultCertificate -VaultName $keyVault.VaultName -Name $certName -InRemovedState -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests pipeline commands to remove multiple deleted certificates
#>

function Test_PipelineRemoveDeletedCertificates
{
    $rootCertName = 'piperemovecert'
    $keyVault = Get-KeyVault
    $certName = Get-CertificateName $rootCertName + '1' 
    $createdCert1 = CreateAKVCertificate $keyVault $certName
    Assert-NotNull $createdCert1

    $certName = Get-CertificateName $rootCertName + '2'
    $createdCert2 = CreateAKVCertificate $keyVault $certName
    Assert-NotNull $createdCert2

    Get-AzureKeyVaultCertificate $keyVault |  Where-Object {$_.CertificateName -like $rootCertName + '*'}  | Remove-AzureKeyVaultCertificate -Force -Confirm:$false
    Wait-Seconds 30
    Get-AzureKeyVaultCertificate $keyVault -InRemovedState |  Where-Object {$_.CertificateName -like $rootCertName + '*'}  | Remove-AzureKeyVaultCertificate -Force -Confirm:$false -InRemovedState

    $certs = Get-AzureKeyVaultCertificate $keyVault -InRemovedState |  Where-Object {$_.CertificateName -like $rootCertName + '*'} 
    Assert-AreEqual $keys.Count 0
}