if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelThreatIntelligenceIndicator'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelThreatIntelligenceIndicator.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelThreatIntelligenceIndicator' {
    It 'UpdateExpanded' {
        $threatIntelligenceIndicator = Update-AzSentinelThreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name $env.UpdatethreatIntelligenceIndicatorId -Confidence 20
        $threatIntelligenceIndicator.Confidence | Should -Be 20
    }

    It 'UpdateViaIdentityExpanded' {
        $threatIntelligenceIndicator = Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name $env.UpdateViaIdthreatIntelligenceIndicatorId 
        threatIntelligenceIndicatorUpdate = threatIntelligenceIndicator | Update-AzSentinelThreatIntelligenceIndicator -Confidence 20
        $threatIntelligenceIndicator.Confidence | Should -Be 20
    }
}
