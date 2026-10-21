if(($null -eq $TestName) -or ($TestName -contains 'Revoke-AzRedHatOpenShiftHcpClusterCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Revoke-AzRedHatOpenShiftHcpClusterCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Revoke-AzRedHatOpenShiftHcpClusterCredentials' {
    It 'Revoke' {
        # The revoke LRO completes with HTTP 204 (No Content). Without the C6 directive the generated cmdlet
        # throws "unrecognized response, Status: NoContent"; with it, the 204 is dispatched to onNoContent and
        # the call returns cleanly.
        { Revoke-AzRedHatOpenShiftHcpClusterCredentials -ResourceGroupName $env.ResourceGroupName `
            -HcpOpenShiftClusterName $env.ClusterName } | Should -Not -Throw
    }
}
