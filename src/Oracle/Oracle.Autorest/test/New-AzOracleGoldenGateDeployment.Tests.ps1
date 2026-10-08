if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleGoldenGateDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleGoldenGateDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleGoldenGateDeployment' {
    # Playback requires this file's recording; run test-module.ps1 -Record after supplying the live fields below.
    # Live/record fixture contract: enableGoldenGateMutationTests='true', goldenGateDeploymentCreateDisposableName (unused/resettable), resourceGroup, location, SubscriptionId.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and $env.enableGoldenGateMutationTests -eq 'true' -and -not [string]::IsNullOrWhiteSpace($env.goldenGateDeploymentCreateDisposableName) -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.location) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Creates the configured disposable GoldenGate deployment' -Skip:(-not $canRun) {
        {
            $deployment = New-AzOracleGoldenGateDeployment -Name $env.goldenGateDeploymentCreateDisposableName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -Location $env.location -DeploymentType Ogg -Category DataReplication -EnvironmentType DevelopmentOrTesting -LicenseModel LicenseIncluded -CpuCoreCount 1 -DisplayName $env.goldenGateDeploymentCreateDisposableName
            $deployment | Should -Not -BeNullOrEmpty
            $deployment.Name | Should -Be $env.goldenGateDeploymentCreateDisposableName
        } | Should -Not -Throw
    }
}
