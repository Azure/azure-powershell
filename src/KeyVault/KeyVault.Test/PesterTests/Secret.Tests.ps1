$vaultName = 'yemingkv23'


. ../Scripts/Common.ps1
$secretName = Get-SecretName
$secretText = 'dummy text'
$secretTextV2 = 'dummy text 2'
Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue (ConvertTo-SecureString $secretText -AsPlainText -Force)
Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue (ConvertTo-SecureString $secretTextV2 -AsPlainText -Force)

Describe "Get secret" {
    It "should write secrets in plain text if -AsPlainText" {
        Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -AsPlainText | Should -BeExactly $secretTextV2

        $versions = Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -IncludeVersions
        Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -Version $versions[0].Version -AsPlainText | Should -BeExactly $secretTextV2
        Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -Version $versions[1].Version -AsPlainText | Should -BeExactly $secretText
        Get-AzKeyVaultSecret -VaultName $vaultName -Name "doesnotexist" -AsPlainText | Should -BeNullOrEmpty
    }
}