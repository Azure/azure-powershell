if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPrivateTrafficManagerSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPrivateTrafficManagerSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPrivateTrafficManagerSite' {
    It 'List - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'List' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'GetViaIdentityTopologyMap - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'GetViaIdentityTopologyMap' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Get - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'Get' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'GetViaIdentity - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'GetViaIdentity' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Get-AzPrivateTrafficManagerSite
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'Get - should retrieve a specific site by name' {
        $result = Get-AzPrivateTrafficManagerSite `
            -Name $env.siteName `
            -TopologyMapName $env.topologyMapName `
            -ResourceGroupName $env.resourceGroupName
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.siteName
    }

    It 'List - should list sites in a topology map' {
        $result = Get-AzPrivateTrafficManagerSite `
            -TopologyMapName $env.topologyMapName `
            -ResourceGroupName $env.resourceGroupName
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 2
    }
}