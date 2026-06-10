if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPrivateTrafficManagerHealthPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPrivateTrafficManagerHealthPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPrivateTrafficManagerHealthPolicy' {
    It 'Delete - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'Delete' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'DeleteViaIdentityPrivateTrafficManagerProfile - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'DeleteViaIdentityPrivateTrafficManagerProfile' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'DeleteViaIdentity - should have correct parameter set' {
        $cmd = Get-Command Remove-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'DeleteViaIdentity' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Remove-AzPrivateTrafficManagerHealthPolicy
        $help.Description | Should Not BeNullOrEmpty
    }
}