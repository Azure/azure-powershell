if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSentinelThreatIntelligenceIndicatorQuery'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSentinelThreatIntelligenceIndicatorQuery.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSentinelThreatIntelligenceIndicatorQuery' {
    It 'QueryExpanded' {
        $threatIntelligenceIndicators = Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceName -IncludeDisabled -PageSize 10
        $threatIntelligenceIndicators | Should -Not -Be $null
    }
}
