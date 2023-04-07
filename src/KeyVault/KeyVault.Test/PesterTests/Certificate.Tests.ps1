BeforeAll {
    $vaultName = 'nori-kv765'
    . "..\Scripts\Common.ps1"
}

Describe "Import Certificate with policy" {
    It "ImportCertificateFromFileParameterSet" {
        $certName = Get-CertificateName
        $certFilePath = "..\Resources\importCert00.pfx"
        $policyPath = "..\Resources\certPolicy.json"

        $cert = Import-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -FilePath $certFilePath -PolicyPath $policyPath
        $cert.Policy.SecretContentType | Should -Be "application/x-pkcs12"
    }
    It "ImportWithPrivateKeyFromStringParameterSet" {
        $certName = Get-CertificateName
        $certFilePath = "..\Resources\importCert00.pfx"
        $policyPath = "..\Resources\certPolicy.json"
        $Base64StringCertificate = [System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes($certFilePath))

        $cert = Import-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificateString $Base64StringCertificate -PolicyPath $policyPath
        $cert.Policy.SecretContentType | Should -Be "application/x-pkcs12"
    }
    It "ImportWithPrivateKeyFromCollectionParameterSet" {
        $certName = Get-CertificateName
        $certFilePath = "..\Resources\importCert00.pfx"
        $policyPath = "..\Resources\certPolicy.json"
        $certCollection = [System.Security.Cryptography.X509Certificates.X509Certificate2Collection]::new()
        $certCollection.Import($certFilePath, $null, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)

        $cert = Import-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificateCollection $certCollection -PolicyPath $policyPath
        $cert.Policy.SecretContentType | Should -Be "application/x-pkcs12"
    }
}

