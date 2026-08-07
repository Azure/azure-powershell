if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMonitorHealthModel'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMonitorHealthModel.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Playback-safe surface tests: the CloudHealth data plane has no recorded cassettes in this
# environment (live integration is tracked separately), so these assertions exercise the
# imported cmdlets' exported surface and parameter binding rather than issuing ARM calls.
Describe 'HealthModel resource family' {
    $verbCases = @(
        @{ Verb = 'Get' }
        @{ Verb = 'New' }
        @{ Verb = 'Update' }
        @{ Verb = 'Remove' }
    )

    It '<Verb>-AzMonitorHealthModel is exported' -TestCases $verbCases {
        param($Verb)
        Get-Command "$Verb-AzMonitorHealthModel" -Module 'Az.CloudHealth' -ErrorAction SilentlyContinue | Should -Not -BeNullOrEmpty
    }

    It 'Get-AzMonitorHealthModel binds the ARM lookup parameters' {
        $cmd = Get-Command 'Get-AzMonitorHealthModel' -Module 'Az.CloudHealth'
        $cmd.Parameters.Keys | Should -Contain 'ResourceGroupName'
        $cmd.Parameters.Keys | Should -Contain 'SubscriptionId'
    }

    It 'Get-AzMonitorHealthModel uses the MonitorHealthModel subject prefix' {
        (Get-Command 'Get-AzMonitorHealthModel' -Module 'Az.CloudHealth').Noun | Should -BeLike 'AzMonitorHealthModel*'
    }
}
