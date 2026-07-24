if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryStorageContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryStorageContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryStorageContainer' {
    It 'Get' {
        $result = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageContainerNameForGet
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $result = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $resource = Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -ErrorAction Stop
        $result = Get-AzDiscoveryStorageContainer -InputObject $resource -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.StorageContainerNameForGet
    }}
