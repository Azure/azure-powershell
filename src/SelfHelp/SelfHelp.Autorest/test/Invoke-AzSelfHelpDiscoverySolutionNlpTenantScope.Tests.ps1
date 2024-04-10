if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope' -Tag 'LiveOnly'{
    It 'PostExpanded' {
        { 
            Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope -IssueSummary "Billing Issues"
        } | Should -Not -Throw
    }
}
