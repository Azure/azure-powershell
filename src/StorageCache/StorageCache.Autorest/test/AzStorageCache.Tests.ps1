if(($null -eq $TestName) -or ($TestName -contains 'AzStorageCache'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStorageCache.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStorageCache' {
    It 'CreateExpanded' {
        {
            $config = New-AzStorageCache -Name $env.storageCacheName2 -ResourceGroupName $env.resourceGroup -IdentityType 'UserAssigned' -IdentityUserAssignedIdentity @{"/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$($env.managementIdentityName)" = @{}} -KeyEncryptionKeyUrl "https://azps-keyvault-0703.vault.azure.net/keys/az-kv-0703/4d8967f8419640198c38302ea6c4284f" -SourceVaultId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.KeyVault/vaults/$($env.keyVaultName)" -Location eastus -CacheSizeGb "3072" -Subnet "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.virtualNetworkName)/subnets/default" -SkuName "Standard_2G" -Zone 1
            $config.Name | Should -Be $env.storageCacheName2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzStorageCache
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzStorageCache -ResourceGroupName $env.resourcegroup -Name $env.storageCacheName2
            $config.Name | Should -Be $env.storageCacheName2
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzStorageCache -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzStorageCache -ResourceGroupName $env.resourcegroup -Name $env.storageCacheName2 -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.storageCacheName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' {
        {
            $config = Get-AzStorageCache -ResourceGroupName $env.resourcegroup -Name $env.storageCacheName2
            $config = Update-AzStorageCache -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.storageCacheName2
        } | Should -Not -Throw
    }

    It 'Start' {
        {
            $config = Start-AzStorageCache -ResourceGroupName $env.resourcegroup -Name $env.storageCacheName2 -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'AscUsageList' {
        {
            $config = Get-AzStorageCacheAscUsage -Location eastus
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'SkuList' {
        {
            $config = Get-AzStorageCacheSku
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UsageModelList' {
        {
            $config = Get-AzStorageCacheUsageModel
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Flush' {
        {
            $config = Clear-AzStorageCache -ResourceGroupName $env.resourcegroup -Name $env.storageCacheName2 -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Debug' {
        {
            $config = Debug-AzStorageCache -CacheName $env.storageCacheName2 -ResourceGroupName $env.resourcegroup -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Stop' {
        {
            $config = Stop-AzStorageCache -ResourceGroupName $env.resourcegroup -Name $env.storageCacheName2 -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        {
            $config = Get-AzStorageCache -ResourceGroupName $env.resourcegroup -Name $env.storageCacheName2
            $config = Start-AzStorageCache -InputObject $config -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }
}
