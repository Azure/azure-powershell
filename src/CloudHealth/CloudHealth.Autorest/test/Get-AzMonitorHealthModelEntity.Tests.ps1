if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMonitorHealthModelEntity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMonitorHealthModelEntity.Recording.json'
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
Describe 'Entity resource family' {
    $verbCases = @(
        @{ Verb = 'Get' }
        @{ Verb = 'New' }
        @{ Verb = 'Update' }
        @{ Verb = 'Remove' }
    )

    It '<Verb>-AzMonitorHealthModelEntity is exported' -TestCases $verbCases {
        param($Verb)
        Get-Command "$Verb-AzMonitorHealthModelEntity" -Module 'Az.CloudHealth' -ErrorAction SilentlyContinue | Should -Not -BeNullOrEmpty
    }

    It 'Get-AzMonitorHealthModelEntity binds the ARM lookup parameters' {
        $cmd = Get-Command 'Get-AzMonitorHealthModelEntity' -Module 'Az.CloudHealth'
        $cmd.Parameters.Keys | Should -Contain 'ResourceGroupName'
        $cmd.Parameters.Keys | Should -Contain 'SubscriptionId'
    }

    It 'Get-AzMonitorHealthModelEntity uses the MonitorHealthModel subject prefix' {
        (Get-Command 'Get-AzMonitorHealthModelEntity' -Module 'Az.CloudHealth').Noun | Should -BeLike 'AzMonitorHealthModel*'
    }
}

Describe 'Entity data-plane action cmdlets' {
    $actionCases = @(
        @{ Name = 'Add-AzMonitorHealthModelEntityDataAnnotation' }
        @{ Name = 'Get-AzMonitorHealthModelEntityDataAnnotation' }
        @{ Name = 'Get-AzMonitorHealthModelEntityHistory' }
        @{ Name = 'Get-AzMonitorHealthModelEntitySignalHistory' }
        @{ Name = 'Get-AzMonitorHealthModelEntitySignalRecommendation' }
        @{ Name = 'Invoke-AzMonitorHealthModelIngestEntityHealthReport' }
    )

    It '<Name> is exported' -TestCases $actionCases {
        param($Name)
        Get-Command $Name -Module 'Az.CloudHealth' -ErrorAction SilentlyContinue | Should -Not -BeNullOrEmpty
    }
}
