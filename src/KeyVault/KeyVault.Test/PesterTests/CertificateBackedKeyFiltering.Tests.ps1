
$debugModulePath = "$PSScriptRoot\..\..\..\..\artifacts\Debug\Az.KeyVault\Az.KeyVault.psd1"
Import-Module $debugModulePath -Force

$vaultName = 'danielKV5816'
. "$PSScriptRoot\..\Scripts\Common.ps1"

Describe "Get-AzKeyVaultKey filters certificate-backed keys" {
    It "Should not return certificate-backed managed keys" {
        $certName = Get-CertificateName
        $keyName = Get-KeyName

        # Create a self-signed certificate (creates a managed key)
        $policy = New-AzKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName "CN=test.contoso.com" -IssuerName Self -ValidityInMonths 6
        $certOp = Add-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificatePolicy $policy

        Start-Sleep -Seconds 30
        $cert = Get-AzKeyVaultCertificate -VaultName $vaultName -Name $certName
        $cert | Should Not BeNullOrEmpty

        $key = Add-AzKeyVaultKey -VaultName $vaultName -Name $keyName -Destination Software
        $key | Should Not BeNullOrEmpty

        $keys = Get-AzKeyVaultKey -VaultName $vaultName

        $standaloneKey = $keys | Where-Object { $_.Name -eq $keyName }
        $standaloneKey | Should Not BeNullOrEmpty

        $certBackedKey = $keys | Where-Object { $_.Name -eq $certName }
        $certBackedKey | Should BeNullOrEmpty
    }
}

Describe "Get-AzKeyVaultSecret filters certificate-backed secrets" {
    It "Should not return certificate-backed managed secrets" {
        $certName = Get-CertificateName
        $secretName = Get-SecretName

        # Create a certificate (creates both managed key AND managed secret)
        $policy = New-AzKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName "CN=test2.contoso.com" -IssuerName Self -ValidityInMonths 6
        $certOp = Add-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificatePolicy $policy

        Start-Sleep -Seconds 30

        $secretValue = ConvertTo-SecureString "MySecretValue123!" -AsPlainText -Force
        $secret = Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue $secretValue
        $secret | Should Not BeNullOrEmpty

        $secrets = Get-AzKeyVaultSecret -VaultName $vaultName

        $standaloneSecret = $secrets | Where-Object { $_.Name -eq $secretName }
        $standaloneSecret | Should Not BeNullOrEmpty

        $certBackedSecret = $secrets | Where-Object { $_.Name -eq $certName }
        $certBackedSecret | Should BeNullOrEmpty
    }
}
