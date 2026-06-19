if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPrivateTrafficManagerHealthPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPrivateTrafficManagerHealthPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPrivateTrafficManagerHealthPolicy' {
    It 'List - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'List' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'GetViaIdentityPrivateTrafficManagerProfile - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'GetViaIdentityPrivateTrafficManagerProfile' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Get - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'Get' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'GetViaIdentity - should have correct parameter set' {
        $cmd = Get-Command Get-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'GetViaIdentity' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help Get-AzPrivateTrafficManagerHealthPolicy
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'Get - should retrieve a specific health policy by name' {
        $result = Get-AzPrivateTrafficManagerHealthPolicy `
            -Name $env.healthPolicyName `
            -PrivateTrafficManagerProfileName $env.profileName `
            -ResourceGroupName $env.resourceGroupName
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.healthPolicyName
    }

    It 'List - should list health policies in a profile' {
        $result = Get-AzPrivateTrafficManagerHealthPolicy `
            -PrivateTrafficManagerProfileName $env.profileName `
            -ResourceGroupName $env.resourceGroupName
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 2
    }
}