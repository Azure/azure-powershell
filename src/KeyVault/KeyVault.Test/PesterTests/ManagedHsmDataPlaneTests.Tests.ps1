$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"

. $PSScriptRoot/ManagedHsmDataPlaneTests.ps1
# ImportModules
$hsmName = 'yeminghsm112901'
$signInName = 'yeliu@microsoft.com'
$storageAccount = 'bezstorageaccount'
$containerName = 'backup'
$keyName = 'test'
# $sasToken = ConvertTo-SecureString -AsPlainText -Force 'insert sas token'
$certs = "D:\sd1.cer", "D:\sd2.cer", "D:\sd3.cer" # for security domain
$certsKeys = @{PublicKey = "D:\sd1.cer"; PrivateKey = "D:\sd1.key" }, @{PublicKey = "D:\sd2.cer"; PrivateKey = "D:\sd2.key" }, @{PublicKey = "D:\sd3.cer"; PrivateKey = "D:\sd3.key" }

Describe "AddAzManagedHsmKey" {
    It "Create a RSA key inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "RSA"
        $rsaKey = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType $keyType
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "RSA-HSM"
    }

    It "Create an EC key with curve P-256 inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "EC"
        $curveName = "P-256"
        $rsaKey = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType $keyType -CurveName $curveName
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "EC-HSM"
        $rsaKey.Key.CurveName | Should -Be $curveName
    }

    It "Create an oct key inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "oct"
        $rsaKey = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType $keyType
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "oct-HSM"
    }

    It "Create an oct key inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "oct"
        $rsaKey = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType $keyType
        $rsaKey.VaultName | Should -BeExactly $hsmName
        $rsaKey.Name | Should -BeExactly $keyName
        $rsaKey.Attributes.KeyType | Should -Be "oct-HSM"
    }

    It "Create a key with non-default values inside a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $keyType = "RSA"
        $KeyOps = 'decrypt', 'verify'
        # Expires & NotBefore is hard to cmpare, may add in the furture
        $Tags = @{'Severity' = 'high'; 'Accounting' = "true" }

        $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType $keyType -KeyOps $KeyOps -Disable -Tag $Tags

        $key.Attributes.KeyOps | Should -Be $KeyOps
        $key.Tags.Count | Should -Be 2
        $key.Enabled | Should -Be $false
    }

    # It "Import a RSA key from pfx file into a managed HSM" {
    #     $keyName = GetRandomName -Prefix "key"
    #     $keyFilePath = Join-Path $PSScriptRoot ../Resources/testImportKey.pfx -Resolve
    #     $keyFilePwd = $null
    #     $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyFilePath $keyFilePath -KeyFilePassword $keyFilePwd
    #     $key.Name | Should -BeExactly $keyName
    # }
}

Describe "GetAzManagedHsmKey" {
    BeforeEach {
        # Add a key
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
    }

    It "List all the keys in a managed HSM" {
        $keys = Get-AzKeyVaultKey -HsmName $hsmName
        $keys.Count | Should -BeGreaterThan 0
    }

    It "Get a specific key in a managed HSM" {
        $got = Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName
        $got.Id | Should -Be $key.Id
    }

    It "List all the keys that have been deleted in a managed HSM" {
        Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Force
        $deletedKey = Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -InRemovedState
        $deletedKey.Id | Should -Be $key.Id
    }

    It "Download a key from a managed HSM" {
        $filePath = "$PSScriptRoot\public.pem"
        Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -OutFile $filePath
        $filePath | Should -Exist
    }
}

Describe "RemoveAzManagedHsmKey" {
    It "Remove a key from a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $deletedKey = Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Force -PassThru
        $deletedKey.Id | Should -Be $key.Id
    }

    It "Purge a deleted key from a managed HSM" {
        $keyName = GetRandomName -Prefix "key"
        Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Force -PassThru
        Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -InRemovedState -Force -PassThru
        $deletedKey = Get-AzKeyVaultKey -HsmName $hsmName -Name $keyName -InRemovedState
        $deletedKey | Should -Be $null
    }

    It "Remove keys by using piping" {
        Get-AzKeyVaultKey -HsmName $hsmName | Remove-AzKeyVaultKey -Force
        $keys = Get-AzKeyVaultKey -HsmName $hsmName
        $keys.Count | Should -Be 0
    }
}

Describe "UpdateAzManagedHsmKey" {
    It "Enable a key and set tags" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType "RSA" -Disable
        $Tags = @{'Severity' = 'high'; 'Accounting' = 'true' }

        $updatedKey = Update-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Enable $True -Tag $Tags -PassThru

        $updatedKey.Id | Should -Be $key.Id
        $updatedKey.Enabled | Should -Be $True
        $updatedKey.Tags.Count | Should -Be 2
    }
}

Describe "UndoAzManagedHsmKeyRemoval" {
    It "Undo a key removal" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $deletedKey = Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Force -PassThru
        $recoveredKey = $deletedKey | Undo-AzKeyVaultKeyRemoval
        $recoveredKey.Id | Should -Be $key.Id
    }
}

Describe "BackupAndRestoreAzManagedHsmKey" {
    It "Backup and restore a key" {
        $keyName = GetRandomName -Prefix "key"
        $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -KeyType "RSA"
        $filePath = "$PSScriptRoot/backupkey.blob"
        $key | Backup-AzKeyVaultKey -OutputFile $filePath -Force
        $filePath | Should -Exist

        Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Force
        Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -InRemovedState -Force
        $restoredKey = Restore-AzKeyVaultKey -HsmName $hsmName -InputFile $filePath
        $restoredKey.Id | Should -Be $key.Id
    }
}

Describe "BackupAndRestoreAzManagedHsm" {
    $script:backupUri = ''
    $containerUri = "https://$storageAccount.blob.core.windows.net/$containerName"
    It "Backup a managed HSM" {
        $script:backupUri = Backup-AzKeyVault -HsmName $hsmName -StorageContainerUri $containerUri -SasToken $sasToken
        $script:backupUri | Should -Not -Be $null
    }

    It "Selective restore a key to managed HSM" {
        $script:backupUri = [System.Uri]::new($script:backupUri)
        $backupFolder = $script:backupUri.Segments[$script:backupUri.Segments.Length - 1]
        $restoreResult = Restore-AzKeyVault -HsmName $hsmName -KeyName $keyName -StorageContainerUri $containerUri -BackupFolder $backupFolder -SasToken $sasToken -PassThru
        $restoreResult | Should -Be $True
    }

    It "Restore whole managed HSM" {
        $script:backupUri = [System.Uri]::new($script:backupUri)
        $backupFolder = $script:backupUri.Segments[$script:backupUri.Segments.Length - 1]
        # Clean hsm
        Get-AzKeyVaultKey -HsmName $hsmName | Remove-AzKeyVaultKey -Force
        Get-AzKeyVaultKey -HsmName $hsmName -InRemovedState | Remove-AzKeyVaultKey -InRemovedState -Force
        $restoreResult = Restore-AzKeyVault -HsmName $hsmName -StorageContainerUri $containerUri -BackupFolder $backupFolder -SasToken $sasToken -PassThru
        $restoreResult | Should -Be $True
    }
}

Describe "GetAzManagedHsmRoleDefinition" {
    It "List all the roles at '/' scope" {
        $roles = Get-AzKeyVaultRoleDefinition -HsmName $hsmName -Scope "/"
        $roles.Count | Should -BeGreaterThan 0
    }

    It "Get a specific role" {
        $backupRole = Get-AzKeyVaultRoleDefinition -HsmName $hsmName -RoleDefinitionName "Managed HSM Backup User"
        $backupRole | Should -Not -Be $null
        $backupRole.Permissions | Should -Not -Be $null
        $backupRole.Permissions.DataActions | Should -Not -Be $null
    }
}

Describe "NewAzManagedHsmRoleAssignment" {
    BeforeEach {
        $roleDefinitionName = "Managed HSM Backup User"
        # Clean role
        $roleAssignment = Get-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        if ($roleAssignment) {
            Remove-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        }
    }

    It "Assign a role to user" {
        # Assign role
        $roleAssignment = New-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        $roleAssignment | Should -Not -Be $null
        $roleAssignment.RoleDefinitionName | Should -Be $roleDefinitionName
    }
}

Describe "RemoveAzManagedHsmRoleAssignment" {
    BeforeEach {
        # Assign role
        $roleDefinitionName = "Managed HSM Backup User"
        $roleAssignment = Get-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        if (!$roleAssignment) {
            $roleAssignment = New-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        }
    }

    It "Revoke a role from user at '/' scope" {
        Remove-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName -Scope "/"
        $roleAssignment = Get-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        $roleAssignment | Should -Be $null
    }
}

Describe "GetAzManagedHsmRoleAssignment" {
    BeforeEach {
        # Assign role
        $roleDefinitionName = "Managed HSM Backup User"
        $roleAssignment = Get-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        if (!$roleAssignment) {
            $roleAssignment = New-AzKeyVaultRoleAssignment -HsmName $hsmName -RoleDefinitionName $roleDefinitionName -SignInName $signInName
        }
    }

    It "List all role assignmentss in a managed HSM" {
        $roleAssignments = Get-AzKeyVaultRoleAssignment -HsmName $hsmName
        $roleAssignments | Should -Not -Be $null
        $roleAssignments.Count | Should -BeGreaterThan 0
    }

    It "List a user's role assignments in a managed HSM on '/' scope" {
        $roleAssignments = Get-AzKeyVaultRoleAssignment -HsmName $hsmName -SignInName $signInName -Scope "/"
        $roleAssignments | Should -Not -Be $null
        $roleAssignments.Count | Should -BeGreaterThan 0
    }
}

Describe 'Export Import Security domain' {
    $sd = New-TemporaryFile
    It 'Can export security domain' {
        Get-Content $sd | Should -BeNullOrEmpty
        Export-AzKeyVaultSecurityDomain -HsmName $hsmName -Certificates $certs -OutputPath $sd.FullName -Quorum 3 -Force
        Get-Content $sd | Should -Not -BeNullOrEmpty
    }

    # Cannot test importing because it needs another HSM
    #   Import-AzKeyVaultSecurityDomain -Name $hsmName -Keys $certsKeys -SecurityDomainPath $sd.FullName
}

Describe 'Custom Role Definition' {
    $roleName = "my custom role"
    $roleDesc = "description for my role"
    $roleAction = @("Microsoft.KeyVault/managedHsm/roleAssignments/write/action", "Microsoft.KeyVault/managedHsm/roleAssignments/delete/action")
    It 'Can create' {
        # 0 custom role
        Get-AzKeyVaultRoleDefinition -HsmName $hsmName -Custom | Should -BeNullOrEmpty

        # create by object
        $role = Get-AzKeyVaultRoleDefinition -HsmName $hsmName -RoleDefinitionName 'Managed HSM Crypto User'
        $role.Name = $null
        $role.RoleName = $roleName
        $role.Description = $roleDesc
        $role.Permissions[0].DataActions = $roleAction
        New-AzKeyVaultRoleDefinition -HsmName $hsmName -Role $role

        # 1 custom role
        $actual = Get-AzKeyVaultRoleDefinition -HsmName $hsmName -Custom
        $actual | Should -Not -BeNullOrEmpty
        $actual.RoleName | Should -Be $roleName
        $actual.Description | Should -Be $roleDesc
        $actual.Permissions[0].DataActions | Should -Be $roleAction
    }

    It 'Can remove' {
        Remove-AzKeyVaultRoleDefinition -HsmName $hsmName -RoleName $roleName -Force
        Get-AzKeyVaultRoleDefinition -HsmName $hsmName -Custom | Should -BeNullOrEmpty
    }
}