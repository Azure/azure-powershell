if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleGoldenGateDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleGoldenGateDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleGoldenGateDeployment' {
    # Playback requires this file's recording; use test-module.ps1 -Record to create it.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Lists GoldenGate deployments in the test resource group' -Skip:(-not $canRun) {
        {
            $deployments = @(Get-AzOracleGoldenGateDeployment -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId)
            $deployments | Should -Not -BeNull
        } | Should -Not -Throw
    }
}
