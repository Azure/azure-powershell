if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRedHatOpenShiftHcpNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedHatOpenShiftHcpNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRedHatOpenShiftHcpNodePool' {
    It 'List (by cluster)' {
        $list = @(Get-AzRedHatOpenShiftHcpNodePool -ResourceGroupName $env.ResourceGroupName -HcpOpenShiftClusterName $env.ClusterName)
        $list.Count | Should -BeGreaterOrEqual 1
        $list.Name | Should -Contain $env.NodePoolName
    }

    It 'Get (by name)' {
        $np = Get-AzRedHatOpenShiftHcpNodePool -ResourceGroupName $env.ResourceGroupName -HcpOpenShiftClusterName $env.ClusterName -Name $env.NodePoolName
        $np.Name | Should -Be $env.NodePoolName
        $np.ProvisioningState | Should -Be 'Succeeded'
    }
}
