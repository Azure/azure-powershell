if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzOracleUnassignGoldenGateConnectionDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzOracleUnassignGoldenGateConnectionDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzOracleUnassignGoldenGateConnectionDeployment' {
    # Playback requires this file's recording; run test-module.ps1 -Record after supplying the live fields below.
    # Live/record fixture contract: enableGoldenGateMutationTests='true', goldenGateConnectionUnassignDeploymentConnectionName and goldenGateConnectionUnassignDeploymentDeploymentName (a resettable assigned pair), resourceGroup, SubscriptionId.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and $env.enableGoldenGateMutationTests -eq 'true' -and -not [string]::IsNullOrWhiteSpace($env.goldenGateConnectionUnassignDeploymentConnectionName) -and -not [string]::IsNullOrWhiteSpace($env.goldenGateConnectionUnassignDeploymentDeploymentName) -and -not [string]::IsNullOrWhiteSpace($env.resourceGroup) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Unassigns the configured disposable deployment from a connection' -Skip:(-not $canRun) {
        {
            $deployment = Get-AzOracleGoldenGateDeployment -Name $env.goldenGateConnectionUnassignDeploymentDeploymentName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
            Invoke-AzOracleUnassignGoldenGateConnectionDeployment -GoldenGateConnectionName $env.goldenGateConnectionUnassignDeploymentConnectionName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -DeploymentId $deployment.Id | Out-Null
            $assignments = @(Get-AzOracleGoldenGateConnectionAssignedDeployment -GoldenGateConnectionName $env.goldenGateConnectionUnassignDeploymentConnectionName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId)
            ($assignments.DeploymentId -contains $deployment.Id) | Should -BeFalse
        } | Should -Not -Throw
    }
}
