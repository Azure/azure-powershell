if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryStorageAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryStorageAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryStorageAsset' {
    It 'Get' {
        $result = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageAssetNameForGet
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $result = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $resource = Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageAssetContainerName -Name $env.StorageAssetNameForGet -ErrorAction Stop
        $result = Get-AzDiscoveryStorageAsset -InputObject $resource -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageAssetNameForGet
    }}
