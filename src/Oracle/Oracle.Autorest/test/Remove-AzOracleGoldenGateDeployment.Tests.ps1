if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleGoldenGateDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleGoldenGateDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOracleGoldenGateDeployment' {
    # Playback requires this file's recording; run test-module.ps1 -Record after supplying the live fields below.
    # Live/record fixture contract: enableGoldenGateMutationTests='true', goldenGateDeploymentDeleteDisposableName (pre-provisioned/resettable), resourceGroup, SubscriptionId.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and $env.enableGoldenGateMutationTests -eq 'true' -and -not [string]::IsNullOrWhiteSpace($env.goldenGateDeploymentDeleteDisposableName) -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Deletes the configured disposable GoldenGate deployment' -Skip:(-not $canRun) {
        {
            Remove-AzOracleGoldenGateDeployment -Name $env.goldenGateDeploymentDeleteDisposableName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -Confirm:$false
        } | Should -Not -Throw
    }
}
