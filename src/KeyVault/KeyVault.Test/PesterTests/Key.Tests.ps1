$vaultName = 'bez-kv0824'


. "$PSScriptRoot\..\Scripts\Common.ps1"

Describe "Create key" {
    It "should create RSA keys" {
        $keyName = Get-KeyName
        $key = Add-AzKeyVaultKey -VaultName $vaultName -Name $keyName -Destination Software
        $key.KeyType | Should -Be "RSA"
        $key.KeySize | Should -Be 2048

        $keyName = Get-KeyName
        $key = Add-AzKeyVaultKey -VaultName $vaultName -Name $keyName -Destination Software -Size 4096
        $key.KeyType | Should -Be "RSA"
        $key.KeySize | Should -Be 4096
    }

    It "should create EC keys" {
        $keyName = Get-KeyName
        $key = Add-AzKeyVaultKey -VaultName $vaultName -Name $keyName -Destination Software -KeyType EC
        $key.KeyType | Should -Be "EC"
        $key.Key.CurveName | Should -Be "P-256"

        $keyName = Get-KeyName
        $key = Add-AzKeyVaultKey -VaultName $vaultName -Name $keyName -Destination Software -KeyType EC -CurveName P-384
        $key.KeyType | Should -Be "EC"
        $key.Key.CurveName | Should -Be "P-384"
    }
}

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

Describe "Import key" {
    It "should throw when key type EC and curve name are not paired" {
        {
            Add-AzKeyVaultKey -VaultName veakkine-kv -Name PSECImportedKey -KeyFilePath E:\targetBlob.byok -KeyType EC -ErrorAction Stop
        } | Should -Throw "CurveName"
        {
            Add-AzKeyVaultKey -VaultName veakkine-kv -Name PSECImportedKey -KeyFilePath E:\targetBlob.byok -CurveName P-256 -ErrorAction Stop
        } | Should -Throw "KeyType"
    }
}

Describe "Invoke key operation" {
    It "Encrypt and Decrypt a sequence using key" {
        $encryptedResult = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -HsmName bez-hsm -Name bez-k -Value (ConvertTo-SecureString -String "test" -AsPlainText -Force) 
        $decryptedResult = Invoke-AzKeyVaultKeyOperation -Operation Decrypt -Algorithm RSA1_5 -HsmName bez-hsm -Name bez-k -Value (ConvertTo-SecureString -String $$encryptedResult.result -AsPlainText -Force) 
        $decryptedResult.result | Should -Be "test"
    }

    It "Wrap and Unwrap a sequence using key" {
        $wrappedResult = Invoke-AzKeyVaultKeyOperation -Operation Wrap -Algorithm RSA1_5 -HsmName bez-hsm -Name bez-k -Value (ConvertTo-SecureString -String "test" -AsPlainText -Force) 
        $unwrappedResult = Invoke-AzKeyVaultKeyOperation -Operation Unwrap -Algorithm RSA1_5 -HsmName bez-hsm -Name bez-k -Value (ConvertTo-SecureString -String $wrappedResult.result -AsPlainText -Force) 
        $unwrappedResult.result | Should -Be "test"
    }
}