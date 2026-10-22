if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRedHatOpenShiftHcpCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRedHatOpenShiftHcpCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Deletes the throwaway cluster created by New-AzRedHatOpenShiftHcpCluster.Tests.ps1.
# MUST be byte-identical to the name the New-/Update- cluster tests use, since the
# recording match key includes the cluster name in the DELETE URI path. This is a
# dedicated hardcoded literal (NOT $env.ClusterName, which is the persistent live
# cluster aro-hcp-01 and must never be the delete target).
$clusterName = 'cltest-ps'

Describe 'Remove-AzRedHatOpenShiftHcpCluster' {
    It 'Delete' {
        { Remove-AzRedHatOpenShiftHcpCluster -ResourceGroupName $env.ResourceGroupName `
            -Name $clusterName } | Should -Not -Throw
    }
}
