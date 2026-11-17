if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRedHatOpenShiftHcpNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRedHatOpenShiftHcpNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Same throwaway pool created by New-AzRedHatOpenShiftHcpNodePool.Tests.ps1.
$poolName = 'nptest-ps'

Describe 'Update-AzRedHatOpenShiftHcpNodePool' {
    It 'UpdateExpanded' {
        # A cheap config-only PATCH (no node churn): change the node drain timeout.
        $np = Update-AzRedHatOpenShiftHcpNodePool -ResourceGroupName $env.ResourceGroupName `
            -HcpOpenShiftClusterName $env.ClusterName -Name $poolName -NodeDrainTimeoutMinute 45
        $np.Name | Should -Be $poolName
        $np.ProvisioningState | Should -Be 'Succeeded'
        $np.NodeDrainTimeoutMinute | Should -Be 45
    }
}
