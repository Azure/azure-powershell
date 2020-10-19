$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"

BeforeAll {
    . $PSScriptRoot/ManagedHsmDatePlaneTests.ps1
    ImportModules
    $hsmName = GetAzManagedHsm
}

Describe "AddAzManagedHsmKey" {
    It "Create a RSA key inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "RSA"
        $rsaKey = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType $keyType
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "RSA-HSM"
    }

    It "Create an EC key with curve P-256 inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "EC"
        $curveName = "P-256"
        $rsaKey = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType $keyType -CurveName $curveName
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "EC-HSM"
        $rsaKey.Key.CurveName | Should -Be $curveName
    }

    It "Create an oct key inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "oct"
        $rsaKey = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType $keyType
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "oct-HSM"
    }

     It "Create an oct key inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "oct"
        $rsaKey = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType $keyType
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "oct-HSM"
    }

     It "Create a key with non-default values inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "RSA"
        $KeyOps = 'decrypt', 'verify'
        # Expires & NotBefore is hard to cmpare, may add in the furture
        $Tags = @{'Severity' = 'high'; 'Accounting' = "true"}

        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType $keyType -KeyOps $KeyOps -Disable -Tag $Tags
        
        $key.Attributes.KeyOps | Should -Be $KeyOps
        $key.Tags.Count | Should -Be 2
        $key.Enabled | Should -Be $false
    }

    It "Import a RSA key from pfx file into a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyFilePath = Join-Path $PSScriptRoot ../Resources/testImportKey.pfx -Resolve
        $keyFilePwd = ConvertTo-SecureString "Passw0rd" -AsPlainText -Force
        $key = Add-AzManagedHsmKey -HsmName bezmhsm -Name $keyName -KeyFilePath $keyFilePath -KeyFilePassword $keyFilePwd
        $key.Name | Should -BeExactly $keyName
    }
}

Describe "GetAzManagedHsmKey"{
    It "List all the keys in a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $keys = Get-AzManagedHsmKey -HsmName $hsmName
        $keys.Count | Should -BeGreaterThan 0
    }

    It "Get a specific key in a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $got = Get-AzManagedHsmKey -HsmName $hsmName -KeyName $keyName
        $got.Id | Should -Be $key.Id
    }

    It "List all the keys that have been deleted in a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        Remove-AzManagedHsmKey -HsmName $hsmName -Name $keyName
        $deletedKey = Get-AzManagedHsmKey -HsmName $hsmName -KeyName $keyName -InRemovedState
        $deletedKey.Id | Should -Be $key.Id
    }
    
    It "Download a key from a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $filePath = "$PSScriptRoot\public.pem"
        Get-AzManagedHsmKey -HsmName $hsmName -KeyName $keyName -OutFile $filePath
        $filePath | Should -Exist
    }
}

Describe "RemoveAzManagedHsmKey"{
    It "Remove a key from a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $deletedKey = Remove-AzManagedHsmKey -HsmName $hsmName -Name $keyName -Force -PassThru
        $deletedKey.Id | Should -Be $key.Id
    }

    It "Purge a deleted key from a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        Remove-AzManagedHsmKey -HsmName $hsmName -Name $keyName -Force -PassThru
        Remove-AzManagedHsmKey -HsmName $hsmName -Name $keyName -InRemovedState -Force -PassThru
        $deletedKey = Get-AzManagedHsmKey -HsmName $hsmName -Name $keyName -InRemovedState
        $deletedKey | Should -Be $null
    }

    It "Remove keys by using piping" {
        Get-AzManagedHsmKey -HsmName $hsmName | Remove-AzManagedHsmKey -Force
        $keys = Get-AzManagedHsmKey -HsmName $hsmName
        $keys.Count | Should -Be 0
    }
}

Describe "UpdateAzManagedHsmKey"{
    It "Enable a key and set tags" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA" -Disable
        $Tags = @{'Severity' = 'high'; 'Accounting' = 'true'}

        $updatedKey = Update-AzManagedHsmKey -HsmName $hsmName -Name $keyName -Enable $True -Tag $Tags -PassThru
       
        $updatedKey.Id | Should -Be $key.Id
        $updatedKey.Enabled | Should -Be $True
        $updatedKey.Tags.Count | Should -Be 2
    }
}

Describe "UndoAzManagedHsmKeyRemoval"{
    It "Undo a key removal" {      
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $deletedKey = Remove-AzManagedHsmKey -HsmName $hsmName -Name $keyName -Force -PassThru
        $recoveredKey = $deletedKey | Undo-AzManagedHsmKeyRemoval
        $recoveredKey.Id | Should -Be $key.Id
    }
}

Describe "BackupAndRetoreAzManagedHsmKey"{
    It "Backup and retore a key" {      
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $filePath = "$PSScriptRoot/backupkey.blob"  
        $key | Backup-AzManagedHsmKey -OutputFile $filePath -Force
        $filePath | Should -Exist
 
        Remove-AzManagedHsmKey -HsmName $hsmName -Name $keyName -Force
        Remove-AzManagedHsmKey -HsmName $hsmName -Name $keyName -InRemovedState -Force
        $restoredKey = Restore-AzManagedHsmKey -HsmName $hsmName -InputFile $filePath
        $restoredKey.Id | Should -Be $key.Id
    }
}

# to do: manually remove all stuffs in resource group
# AfterAll {
    # $hsm = Get-AzManagedHsm -Name $hsmName
    # Remove-AzResourceGroup -Name $hsm.ResourceGroupName -Force
# }