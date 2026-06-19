if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPrivateTrafficManagerSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPrivateTrafficManagerSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPrivateTrafficManagerSite' {
    It 'Delete - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'Delete' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'DeleteViaIdentityTopologyMap - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'DeleteViaIdentityTopologyMap' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'DeleteViaIdentity - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'DeleteViaIdentity' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Remove-AzPrivateTrafficManagerSite
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'Delete - should remove a site' {
        { Remove-AzPrivateTrafficManagerSite `
            -Name $env.siteNameForDelete `
            -TopologyMapName $env.topologyMapName `
            -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw
    }
}