if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageDiscoveryWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageDiscoveryWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageDiscoveryWorkspace' {
    It 'CreateExpanded' {
        {
            $scope1 = New-AzStorageDiscoveryScopeObject -DisplayName "scope1" -ResourceType "Microsoft.Storage/storageAccounts" -TagKeysOnly "key1" -Tag @{"tag1" = "value1"; "tag2" = "value2"}
            New-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName2 -ResourceGroupName $env.resourceGroup -Location $env.region -WorkspaceRoot $env.workspaceRoot -Sku Standard -Scope $scope1 -Description "test storage discovery workspace 2"
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateExpanded with capacity details and blob prefix configuration' {
        $scope = New-AzStorageDiscoveryScopeObject -DisplayName "scope1" -ResourceType "Microsoft.Storage/storageAccounts" -TagKeysOnly "key1" -Tag @{"tag1" = "value1"}
        $prefix = @{ StorageAccountName = "pshteststorageacct"; ContainerName = "pshtestcontainer"; Prefix = "logs/" }
        $workspace = New-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName3 -ResourceGroupName $env.resourceGroup -Location $env.region -WorkspaceRoot $env.workspaceRoot -Sku Standard -Scope $scope -CapacityDetailStatus Enabled -AzureBlobStoragePrefixConfiguration $prefix
        $workspace.CapacityDetailStatus | Should -Be 'Enabled'
        $workspace.AzureBlobStoragePrefixConfiguration.Count | Should -Be 1
        $workspace.AzureBlobStoragePrefixConfiguration[0].ContainerName | Should -Be 'pshtestcontainer'
        $workspace.AzureBlobStoragePrefixConfiguration[0].Prefix | Should -Be 'logs/'
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
