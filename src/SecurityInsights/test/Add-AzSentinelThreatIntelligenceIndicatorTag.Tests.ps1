if(($null -eq $TestName) -or ($TestName -contains 'Add-AzSentinelThreatIntelligenceIndicatorTag'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzSentinelThreatIntelligenceIndicatorTag.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzSentinelThreatIntelligenceIndicatorTag' {
    It 'AppendExpanded' {
        { Add-AzSentinelThreatIntelligenceIndicatorTag -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.GetthreatIntelligenceIndicatorId -ThreatIntelligenceTag @("TestTag") } | Should -Not -Throw
    }

    It 'AppendViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
