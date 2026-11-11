if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleGoldenGateConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleGoldenGateConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleGoldenGateConnection' {
    # Playback requires this file's recording; run test-module.ps1 -Record after supplying the live fields below.
    # Live/record fixture contract: enableGoldenGateMutationTests='true', goldenGateConnectionCreateDisposableName (unused/resettable), resourceGroup, location, SubscriptionId.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and $env.enableGoldenGateMutationTests -eq 'true' -and -not [string]::IsNullOrWhiteSpace($env.goldenGateConnectionCreateDisposableName) -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.location) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Creates the configured disposable GoldenGate connection' -Skip:(-not $canRun) {
        {
            $connection = New-AzOracleGoldenGateConnection -Name $env.goldenGateConnectionCreateDisposableName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -Location $env.location -ConnectionType Generic -DisplayName $env.goldenGateConnectionCreateDisposableName
            $connection | Should -Not -BeNullOrEmpty
            $connection.Name | Should -Be $env.goldenGateConnectionCreateDisposableName
        } | Should -Not -Throw
    }
}
