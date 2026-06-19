if(($null -eq $TestName) -or ($TestName -contains 'New-AzPrivateTrafficManagerProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPrivateTrafficManagerProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPrivateTrafficManagerProfile' {
    It 'CreateExpanded - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonFilePath - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonFilePath' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonString - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerProfile
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonString' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help New-AzPrivateTrafficManagerProfile
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'CreateExpanded - should create a new profile' {
        $newProfileName = "ptm-new-$($env.randomStr)"
        $newProfileJson = @{
            location = "global"
            properties = @{
                trafficRoutingMethod = "Weighted"
                profileStatus = "Enabled"
                customTopologyMapMode = "Disabled"
                dnsConfig = @{
                    recordType = "CNAME"
                    ttl = 30
                }
            }
        } | ConvertTo-Json -Depth 5
        $result = New-AzPrivateTrafficManagerProfile `
            -PrivateTrafficManagerProfileName $newProfileName `
            -ResourceGroupName $env.resourceGroupName `
            -JsonString $newProfileJson
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $newProfileName
        Remove-AzPrivateTrafficManagerProfile `
            -PrivateTrafficManagerProfileName $newProfileName `
            -ResourceGroupName $env.resourceGroupName
    }
}