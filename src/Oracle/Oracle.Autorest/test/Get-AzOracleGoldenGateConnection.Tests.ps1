if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleGoldenGateConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleGoldenGateConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleGoldenGateConnection' {
    # Playback requires this file's recording; use test-module.ps1 -Record to create it.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Lists GoldenGate connections in the test resource group' -Skip:(-not $canRun) {
        {
            $connections = @(Get-AzOracleGoldenGateConnection -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId)
            $connections | Should -Not -BeNull
        } | Should -Not -Throw
    }
}
