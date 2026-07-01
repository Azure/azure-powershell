if(($null -eq $TestName) -or ($TestName -contains 'New-AzPrivateTrafficManagerHealthPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPrivateTrafficManagerHealthPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPrivateTrafficManagerHealthPolicy' {
    It 'CreateExpanded - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonString - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonString' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaJsonFilePath - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaJsonFilePath' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'CreateViaIdentityPrivateTrafficManagerProfileExpanded - should have correct parameter set' {
        $cmd = Get-Command New-AzPrivateTrafficManagerHealthPolicy
        $paramSet = $cmd.ParameterSets | Where-Object { $_.Name -eq 'CreateViaIdentityPrivateTrafficManagerProfileExpanded' }
        $paramSet | Should Not BeNullOrEmpty
    }
    It 'Should have help documentation' {
        $help = Get-Help New-AzPrivateTrafficManagerHealthPolicy
        $help.Description | Should Not BeNullOrEmpty
    }

    It 'CreateViaJsonString - should create a new health policy' {
        $newHpName = "ptm-hp-new-$($env.randomStr)"
        $hpJson = @{
            properties = @{
                name = $newHpName
                probeConfig = @{
                    protocol = "HTTPS"
                    port = 8443
                    path = "/status"
                    intervalInSeconds = 30
                    timeoutInSeconds = 10
                    toleratedNumberOfFailures = 3
                }
            }
            kind = "Probe"
        } | ConvertTo-Json -Depth 5
        $result = New-AzPrivateTrafficManagerHealthPolicy `
            -Name $newHpName `
            -PrivateTrafficManagerProfileName $env.profileName `
            -ResourceGroupName $env.resourceGroupName `
            -JsonString $hpJson
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $newHpName
        Remove-AzPrivateTrafficManagerHealthPolicy `
            -Name $newHpName `
            -PrivateTrafficManagerProfileName $env.profileName `
            -ResourceGroupName $env.resourceGroupName
    }
}