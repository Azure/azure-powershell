if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPrivateTrafficManagerSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPrivateTrafficManagerSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPrivateTrafficManagerSite' {
    It 'UpdateExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaJsonString - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaJsonString' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaJsonFilePath - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaJsonFilePath' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaIdentityTopologyMapExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaIdentityTopologyMapExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaIdentityExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerSite
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaIdentityExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Update-AzPrivateTrafficManagerSite
        $help.Description | Should Not BeNullOrEmpty
    }
}