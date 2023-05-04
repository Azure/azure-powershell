BeforeAll {
    $vaultName = 'nori-kv765'
    . "..\Scripts\Common.ps1"
}

Describe "Import Certificate with policy" {
    It "ImportCertificateFromFileWithPolicyParameterSet" {
        $certName = Get-CertificateName
        $certFilePath = "..\Resources\importCertWithPolicy.pfx"
        $policy = New-AzKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName "CN=contoso.com" -IssuerName "Self" -ValidityInMonths 6 -ReuseKeyOnRenewal

        $cert = Import-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -FilePath $certFilePath -PolicyObject $policy
        $cert.Policy.SecretContentType | Should -Be "application/x-pkcs12"
    }
    It "ImportCertificateFromFileWithPolicyFileParameterSet" {
        $certName = Get-CertificateName
        $certFilePath = "..\Resources\importCertWithPolicy.pfx"
        $policyPath = "..\Resources\certPolicy.json"

        $cert = Import-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -FilePath $certFilePath -PolicyPath $policyPath
        $cert.Policy.SecretContentType | Should -Be "application/x-pkcs12"
    }
    It "ImportWithPrivateKeyFromStringWithPolicyFileParameterSet" {
        $certName = Get-CertificateName
        $certFilePath = "..\Resources\importCertWithPolicy.pfx"
        $policyPath = "..\Resources\certPolicy.json"
        $Base64StringCertificate = [System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes($certFilePath))

        $cert = Import-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificateString $Base64StringCertificate -PolicyPath $policyPath
        $cert.Policy.SecretContentType | Should -Be "application/x-pkcs12"
    }
    It "ImportWithPrivateKeyFromCollectionWithPolicyFileParameterSet" {
        $certName = Get-CertificateName
        $certFilePath = "..\Resources\importCertWithPolicy.pfx"
        $policyPath = "..\Resources\certPolicy.json"
        $certCollection = [System.Security.Cryptography.X509Certificates.X509Certificate2Collection]::new()
        $certCollection.Import($certFilePath, $null, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)

        $cert = Import-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificateCollection $certCollection -PolicyPath $policyPath
        $cert.Policy.SecretContentType | Should -Be "application/x-pkcs12"
    }
}

