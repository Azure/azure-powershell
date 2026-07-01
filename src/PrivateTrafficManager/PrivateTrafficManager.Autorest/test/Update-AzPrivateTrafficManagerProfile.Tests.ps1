if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPrivateTrafficManagerProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPrivateTrafficManagerProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPrivateTrafficManagerProfile' {
    It 'UpdateExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaJsonString - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaJsonString' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaJsonFilePath - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaJsonFilePath' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'UpdateViaIdentityExpanded - should have correct parameter set' {
        $cmd = Get-Command Update-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'UpdateViaIdentityExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Update-AzPrivateTrafficManagerProfile
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'UpdateExpanded - should update profile properties' {
        $result = Update-AzPrivateTrafficManagerProfile `
            -PrivateTrafficManagerProfileName $env.profileName `
            -ResourceGroupName $env.resourceGroupName `
            -Tag @{ "env" = "test"; "updated" = "true" }
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.profileName
    }
}