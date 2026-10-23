if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzOracleUnassignGoldenGateDeploymentConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzOracleUnassignGoldenGateDeploymentConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzOracleUnassignGoldenGateDeploymentConnection' {
    # Playback requires this file's recording; run test-module.ps1 -Record after supplying the live fields below.
    # Live/record fixture contract: enableGoldenGateMutationTests='true', goldenGateDeploymentUnassignConnectionDeploymentName and goldenGateDeploymentUnassignConnectionConnectionName (a resettable assigned pair), resourceGroup, SubscriptionId.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and $env.enableGoldenGateMutationTests -eq 'true' -and -not [string]::IsNullOrWhiteSpace($env.goldenGateDeploymentUnassignConnectionDeploymentName) -and -not [string]::IsNullOrWhiteSpace($env.goldenGateDeploymentUnassignConnectionConnectionName) -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Unassigns the configured disposable connection from a deployment' -Skip:(-not $canRun) {
        {
            $connection = Get-AzOracleGoldenGateConnection -Name $env.goldenGateDeploymentUnassignConnectionConnectionName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
            Invoke-AzOracleUnassignGoldenGateDeploymentConnection -GoldenGateDeploymentName $env.goldenGateDeploymentUnassignConnectionDeploymentName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -ConnectionId $connection.Id | Out-Null
            $assignments = @(Get-AzOracleGoldenGateDeploymentAssignedConnection -GoldenGateDeploymentName $env.goldenGateDeploymentUnassignConnectionDeploymentName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId)
            ($assignments.ConnectionId -contains $connection.Id) | Should -BeFalse
        } | Should -Not -Throw
    }
}
