if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDiscoveryNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiscoveryNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDiscoveryNodePool' {
    It 'Get' {
        $result = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.NodePoolNameForGet
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $result = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $resource = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
        $result = Get-AzDiscoveryNodePool -InputObject $resource -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.NodePoolNameForGet
    }}
