if(($null -eq $TestName) -or ($TestName -contains 'New-AzPrivateTrafficManagerEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPrivateTrafficManagerEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPrivateTrafficManagerEndpoint' {
    It 'CreateExpanded - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonString - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonString' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonFilePath - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonFilePath' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaIdentityPrivateTrafficManagerProfileExpanded - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaIdentityPrivateTrafficManagerProfileExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help New-AzPrivateTrafficManagerEndpoint
        $help.Description | Should Not BeNullOrEmpty
    }
}