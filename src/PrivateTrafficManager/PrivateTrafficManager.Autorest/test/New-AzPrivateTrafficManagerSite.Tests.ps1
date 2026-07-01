if(($null -eq $TestName) -or ($TestName -contains 'New-AzPrivateTrafficManagerSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPrivateTrafficManagerSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPrivateTrafficManagerSite' {
    It 'CreateExpanded - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonString - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonString' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonFilePath - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonFilePath' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaIdentityTopologyMapExpanded - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaIdentityTopologyMapExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help New-AzPrivateTrafficManagerSite
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'CreateExpanded - should create a new site' {
        $newSiteName = "ptm-site-new-$($env.randomStr)"
        $newSiteJson = @{
            properties = @{
                virtualNetworkIds = @()
            }
        } | ConvertTo-Json -Depth 5
        $result = New-AzPrivateTrafficManagerSite `
            -Name $newSiteName `
            -TopologyMapName $env.topologyMapName `
            -ResourceGroupName $env.resourceGroupName `
            -JsonString $newSiteJson
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $newSiteName
        Remove-AzPrivateTrafficManagerSite `
            -Name $newSiteName `
            -TopologyMapName $env.topologyMapName `
            -ResourceGroupName $env.resourceGroupName
    }
}