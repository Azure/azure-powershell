if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageDiscoveryWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageDiscoveryWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageDiscoveryWorkspace' {
    It 'UpdateExpanded' {
        {
            $updatedScope = New-AzStorageDiscoveryScopeObject -DisplayName "updatedScope" -ResourceType "Microsoft.Storage/storageAccounts" -TagKeysOnly "updatedKey" -Tag @{"updatedTag1" = "updatedValue1"; "updatedTag2" = "updatedValue2"}
            Update-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName1 -ResourceGroupName $env.resourceGroup -Description "updated storage discovery workspace description" -Sku Free -Scope $updatedScope
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded with capacity details and blob prefix configuration' {
        $prefix = @{ StorageAccountName = "pshteststorageacct"; ContainerName = "pshtestcontainer"; Prefix = "data/" }
        $workspace = Update-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName1 -ResourceGroupName $env.resourceGroup -CapacityDetailStatus Disabled -AzureBlobStoragePrefixConfiguration $prefix
        $workspace.CapacityDetailStatus | Should -Be 'Disabled'
        $workspace.AzureBlobStoragePrefixConfiguration[0].Prefix | Should -Be 'data/'
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
