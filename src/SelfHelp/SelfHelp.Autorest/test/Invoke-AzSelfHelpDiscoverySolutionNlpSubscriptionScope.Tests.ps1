if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSelfHelpDiscoverySolutionNlpSubscriptionScope'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSelfHelpDiscoverySolutionNlpSubscriptionScope.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSelfHelpDiscoverySolutionNlpSubscriptionScope' -Tag 'LiveOnly'{
    It 'PostExpanded' {
        { 
            Invoke-AzSelfHelpDiscoverySolutionNlpSubscriptionScope -SubscriptionId $env.SubscriptionId -IssueSummary "Billing Issues"
        } | Should -Not -Throw
    }
}
