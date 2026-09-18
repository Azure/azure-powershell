if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleGoldenGateConnectionAssignedDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleGoldenGateConnectionAssignedDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleGoldenGateConnectionAssignedDeployment' {
    # Playback requires this file's recording; use test-module.ps1 -Record to create it.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and -not [string]::IsNullOrWhiteSpace($env.goldenGateConnectionName) -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Lists deployments assigned to the GoldenGate connection' -Skip:(-not $canRun) {
        {
            $assignments = @(Get-AzOracleGoldenGateConnectionAssignedDeployment -GoldenGateConnectionName $env.goldenGateConnectionName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId)
            $assignments | Should -Not -BeNull
        } | Should -Not -Throw
    }
}
