if(($null -eq $TestName) -or ($TestName -contains 'AzStorageCacheAmlFileSystem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStorageCacheAmlFileSystem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStorageCacheAmlFileSystem' {
    It 'CreateExpandedHSM' {
        {
            $config = New-AzStorageCacheAmlFileSystem -Name $env.storageCacheAmlFileSystemName -ResourceGroupName $env.resourceGroup -Location $env.location -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.virtualNetworkName)/subnets/default" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1 -SettingContainer "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Storage/storageAccounts/$($env.storageAccountName)/blobServices/default/containers/$($env.blobContainerName2)" -SettingImportPrefix "/" -SettingLoggingContainer "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Storage/storageAccounts/$($env.storageAccountName)/blobServices/default/containers/$($env.blobContainerName1)"
            $config.Name | Should -Be $env.storageCacheAmlFileSystemName
        } | Should -Not -Throw
    }

    It 'ArchiveExpanded' {
        {
            $config = Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName $env.storageCacheAmlFileSystemName -ResourceGroupName $env.resourceGroup -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Cancel' {
        {
            $config = Stop-AzStorageCacheAmlFilesystemArchive -AmlFilesystemName $env.storageCacheAmlFileSystemName -ResourceGroupName $env.resourceGroup -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Create' {
        {
            $config = New-AzStorageCacheAmlFileSystem -Name $env.storageCacheAmlFileSystemName2 -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'UserAssigned' -IdentityUserAssignedIdentity @{"/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$($env.managementIdentityName)" = @{}} -KeyEncryptionKeyUrl "https://azps-keyvault-0703.vault.azure.net/keys/az-kv-0703/4d8967f8419640198c38302ea6c4284f" -SourceVaultId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.KeyVault/vaults/$($env.keyVaultName)" -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.virtualNetworkName)/subnets/default" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1
            $config.Name | Should -Be $env.storageCacheAmlFileSystemName2
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzStorageCacheAmlFileSystem -Name $env.storageCacheAmlFileSystemName2 -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.storageCacheAmlFileSystemName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' {
        {
            $config = Get-AzStorageCacheAmlFileSystem -Name $env.storageCacheAmlFileSystemName2 -ResourceGroupName $env.resourceGroup
            $config = Update-AzStorageCacheAmlFileSystem -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.storageCacheAmlFileSystemName2
        } | Should -Not -Throw
    }

    It 'GetExpanded' {
        {
            $config = Get-AzStorageCacheAmlFileSystemSubnetRequiredSize -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzStorageCacheAmlFileSystem -Name $env.storageCacheAmlFileSystemName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzStorageCacheAmlFileSystem
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzStorageCacheAmlFileSystem -Name $env.storageCacheAmlFileSystemName2 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.storageCacheAmlFileSystemName2
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzStorageCacheAmlFileSystem -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
