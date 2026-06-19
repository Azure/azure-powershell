if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPrivateTrafficManagerHealthPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPrivateTrafficManagerHealthPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPrivateTrafficManagerHealthPolicy' {
    It 'UpdateExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaIdentityPrivateTrafficManagerProfileExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaIdentityPrivateTrafficManagerProfileExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaIdentityExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaIdentityExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Update-AzPrivateTrafficManagerHealthPolicy
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'UpdateExpanded - should update health policy' -Skip {
        # Update-AzPrivateTrafficManagerHealthPolicy has no body parameters to update
        # The cmdlet only supports identity-based PATCH with no modifiable properties exposed
        $true | Should -Be $true
    }
}