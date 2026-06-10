if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPrivateTrafficManagerEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPrivateTrafficManagerEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPrivateTrafficManagerEndpoint' {
    It 'List - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'List' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'GetViaIdentityPrivateTrafficManagerProfile - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'GetViaIdentityPrivateTrafficManagerProfile' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Get - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'Get' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'GetViaIdentity - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerEndpoint
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'GetViaIdentity' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Get-AzPrivateTrafficManagerEndpoint
        $help.Description | Should Not BeNullOrEmpty
    }
}