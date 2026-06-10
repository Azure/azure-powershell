if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPrivateTrafficManagerProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPrivateTrafficManagerProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPrivateTrafficManagerProfile' {
    It 'List1 - should have correct parameter set' {
        $cmd = Get-Command -Name Get-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'List1' }
        $paramSet | Should -Not -BeNullOrEmpty
    }

    It 'Get - should have correct parameter set' {
        $cmd = Get-Command -Name Get-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'Get' }
        $paramSet | Should -Not -BeNullOrEmpty
    }

    It 'List - should have correct parameter set' {
        $cmd = Get-Command -Name Get-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'List' }
        $paramSet | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity - should have correct parameter set' {
        $cmd = Get-Command -Name Get-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'GetViaIdentity' }
        $paramSet | Should -Not -BeNullOrEmpty
    }

    It 'Should have help documentation' {
        $help = Get-Help Get-AzPrivateTrafficManagerProfile
        $help | Should -Not -BeNullOrEmpty
    }
}