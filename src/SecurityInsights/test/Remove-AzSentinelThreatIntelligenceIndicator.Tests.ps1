if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelThreatIntelligenceIndicator'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelThreatIntelligenceIndicator.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelThreatIntelligenceIndicator' {
    It 'Delete' {
        { Remove-AzSentinelThreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.RemovethreatIntelligenceIndicatorId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        $threatIntelligenceIndicator =  Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name $env.RemoveViaIdthreatIntelligenceIndicatorId
        { Remove-AzSentinelThreatIntelligenceIndicator -InputObject $threatIntelligenceIndicator } | Should -Not -Throw
    }
}
