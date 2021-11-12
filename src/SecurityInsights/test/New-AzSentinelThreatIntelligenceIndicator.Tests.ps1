if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelThreatIntelligenceIndicator'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelThreatIntelligenceIndicator.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelThreatIntelligenceIndicator' {
    It 'CreateExpanded' {
        $threatIntelligenceIndicator =  New-AzSentinelThreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Confidence 10 -DisplayName "NewTIPSTest" -Pattern "[ipv4-addr:value = '8.8.8.8']" -PatternType "ipv4-addr" `
            -ValidFrom ((get-date).ToUniversalTime() | Get-Date -Format "ddd, dd MMM yyyy hh:00:00 'GMT'")  -Source "Azure Sentinel" -ThreatType (@("Unknown"))
        $threatIntelligenceIndicator.DisplayName | Should -Be "NewTIPSTest"
    }
}