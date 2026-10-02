if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleGoldenGateDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOracleGoldenGateDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzOracleGoldenGateDeployment' {
    # Playback requires this file's recording; run test-module.ps1 -Record after supplying the live fields below.
    # Live/record fixture contract: enableGoldenGateMutationTests='true', goldenGateDeploymentUpdateDisposableName (pre-provisioned/resettable), resourceGroup, SubscriptionId.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and $env.enableGoldenGateMutationTests -eq 'true' -and -not [string]::IsNullOrWhiteSpace($env.goldenGateDeploymentUpdateDisposableName) -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Updates tags on the configured disposable GoldenGate deployment' -Skip:(-not $canRun) {
        {
            $tags = @{ updatedBy = 'Pester'; apiVersion = '2026-06-01' }
            Update-AzOracleGoldenGateDeployment -Name $env.goldenGateDeploymentUpdateDisposableName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -Tag $tags | Out-Null
            $deployment = Get-AzOracleGoldenGateDeployment -Name $env.goldenGateDeploymentUpdateDisposableName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
            $deployment.Tag['updatedBy'] | Should -Be 'Pester'
        } | Should -Not -Throw
    }
}
