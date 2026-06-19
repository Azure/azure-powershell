if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPrivateTrafficManagerTopologyMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPrivateTrafficManagerTopologyMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPrivateTrafficManagerTopologyMap' {
    It 'Delete - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerTopologyMap
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'Delete' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'DeleteViaIdentity - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerTopologyMap
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'DeleteViaIdentity' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Remove-AzPrivateTrafficManagerTopologyMap
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'Delete - should remove a topology map' {
        { Remove-AzPrivateTrafficManagerTopologyMap `
            -Name $env.topologyMapNameForDelete `
            -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw
    }
}