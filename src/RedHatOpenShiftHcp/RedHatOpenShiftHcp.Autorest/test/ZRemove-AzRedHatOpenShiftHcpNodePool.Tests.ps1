if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRedHatOpenShiftHcpNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRedHatOpenShiftHcpNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Deletes the throwaway pool created by New-AzRedHatOpenShiftHcpNodePool.Tests.ps1.
$poolName = 'nptest-ps'

Describe 'Remove-AzRedHatOpenShiftHcpNodePool' {
    It 'Delete' {
        { Remove-AzRedHatOpenShiftHcpNodePool -ResourceGroupName $env.ResourceGroupName `
            -HcpOpenShiftClusterName $env.ClusterName -Name $poolName } | Should -Not -Throw
    }
}
