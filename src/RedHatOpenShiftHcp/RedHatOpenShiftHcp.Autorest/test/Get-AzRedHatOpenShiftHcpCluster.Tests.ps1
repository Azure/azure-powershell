if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRedHatOpenShiftHcpCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedHatOpenShiftHcpCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRedHatOpenShiftHcpCluster' {
    It 'List (by resource group)' {
        $list = @(Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName $env.ResourceGroupName)
        $list.Count | Should -BeGreaterOrEqual 1
        $list.Name | Should -Contain $env.ClusterName
    }

    It 'Get (by name)' {
        $c = Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName $env.ResourceGroupName -Name $env.ClusterName
        $c.Name | Should -Be $env.ClusterName
        $c.Location | Should -Be $env.Location
        $c.ProvisioningState | Should -Be 'Succeeded'
    }
}
