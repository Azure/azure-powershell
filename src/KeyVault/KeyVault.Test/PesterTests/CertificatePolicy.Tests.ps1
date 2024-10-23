# CertificatePolicy.Tests.ps1

BeforeAll {
    $vaultName = 'yash-kv'
    . "$PSScriptRoot\..\Scripts\Common.ps1" # Common setup script

    $psd1Path = Join-Path $PSScriptRoot "../../../../artifacts/Debug/" -Resolve
    $keyVaultPsd1 = Join-Path $psd1Path "./Az.KeyVault/Az.KeyVault.psd1" -Resolve
    Import-Module $keyVaultPsd1 -Force
}

Describe "Set-AzKeyVaultCertificatePolicy Null Handling" {
    Context "When setting null for RenewAtNumberOfDaysBeforeExpiry and RenewAtPercentageLifetime" {

        It "Should not throw an error when setting null values" {

            # Arrange: Generate a random certificate name
            $certName = Get-CertificateName -suffix (Get-Random)
            
            # Retrieve Key Vault & Certificate
            $KV = Get-AzKeyVault -VaultName $vaultName
            $cert = $KV | Get-AzKeyVaultCertificate -Name $certName

            if ($cert -eq $null) {
                # Create a certificate if it doesn't exist
                $policy = New-AzKeyVaultCertificatePolicy `
                    -SubjectName "CN=$certName" `
                    -IssuerName "Self" `
                    -ValidityInMonths 12
                
                $cert = Add-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificatePolicy $policy
            }

            # Retrieve Cert & Certificate Policy
            $cert = $KV | Get-AzKeyVaultCertificate -Name $certName
            $policy = $cert | Get-AzKeyVaultCertificatePolicy

            # Act: Set null for RenewAtPercentageLifetime and some value for RenewAtNumberOfDaysBeforeExpiry 
            $policy.RenewAtNumberOfDaysBeforeExpiry = 25
            $policy.RenewAtPercentageLifetime = $null

            # Apply policy and verify no errors
            $policy | Set-AzKeyVaultCertificatePolicy -VaultName $vaultName -Name $certName

            # Retrieve updated policy
            $updatedCert = $KV | Get-AzKeyVaultCertificate -Name $certName
            $updatedPolicy = $updatedCert | Get-AzKeyVaultCertificatePolicy

            # Clean up the created resources
            Remove-AzKeyVaultCertificate -VaultName $vaultName -Name $certName -Force

            # Assert: Check if the properties have been set to null
            $updatedPolicy.RenewAtNumberOfDaysBeforeExpiry | Should -Be 25
            $updatedPolicy.RenewAtPercentageLifetime | Should -Be $null
        }
    }
}

