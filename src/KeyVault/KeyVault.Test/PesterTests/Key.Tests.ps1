$vaultName = 'yemingkv27'


. "$PSScriptRoot\..\Scripts\Common.ps1"

Describe "Update key" {
    It "should update multiple versions" {
        $keyName = Get-KeyName
        Add-AzKeyVaultKey -VaultName $vaultName -Name $keyName -Destination Software
        Add-AzKeyVaultKey -VaultName $vaultName -Name $keyName -Destination Software
        Get-AzKeyVaultKey -VaultName $vaultName -Name $keyName -IncludeVersions | Should -HaveCount 2

        Get-AzKeyVaultKey -VaultName $vaultName -Name $keyName -IncludeVersions | Update-AzKeyVaultKey -Enable $false
        Get-AzKeyVaultKey -VaultName $vaultName -Name $keyName -IncludeVersions | ForEach-Object { $_.Enabled | Should -BeFalse }

        Get-AzKeyVaultKey -VaultName $vaultName -Name $keyName -IncludeVersions | Update-AzKeyVaultKey -Enable $true
        Get-AzKeyVaultKey -VaultName $vaultName -Name $keyName -IncludeVersions | ForEach-Object { $_.Enabled | Should -BeTrue }
    }
}

Describe "Add key" {
    It "should throw when key type EC and curve name are not paired" {
        {
            Add-AzKeyVaultKey -VaultName veakkine-kv -Name PSECImportedKey -KeyFilePath E:\targetBlob.byok -KeyType EC -ErrorAction Stop
        } | Should -Throw "CurveName"
        {
            Add-AzKeyVaultKey -VaultName veakkine-kv -Name PSECImportedKey -KeyFilePath E:\targetBlob.byok -CurveName P-256 -ErrorAction Stop
        } | Should -Throw "KeyType"
    }
}