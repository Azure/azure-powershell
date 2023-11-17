if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelThreatIntelligenceIndicator'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelThreatIntelligenceIndicator.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelThreatIntelligenceIndicator' {
    It 'List' {
        $threatIntelligenceIndicators = Get-AzSentinelthreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $threatIntelligenceIndicators.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $threatIntelligenceIndicator = Get-AzSentinelthreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.GetthreatIntelligenceIndicatorId
        $threatIntelligenceIndicator.Name | Should -Be $env.GetthreatIntelligenceIndicatorId
    }

    It 'GetViaIdentity' -skip {
        $threatIntelligenceIndicator = Get-AzSentinelthreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.GetthreatIntelligenceIndicatorId
        $threatIntelligenceIndicatorViaId = Get-AzSentinelthreatIntelligenceIndicator -InputObject $threatIntelligenceIndicator
        $threatIntelligenceIndicatorViaId.Name | Should -Be $env.GetthreatIntelligenceIndicatorId
    }
}
