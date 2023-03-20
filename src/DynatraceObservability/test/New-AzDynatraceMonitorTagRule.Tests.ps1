if(($null -eq $TestName) -or ($TestName -contains 'New-AzDynatraceMonitorTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDynatraceMonitorTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDynatraceMonitorTagRule' {
    It 'CreateExpanded' {
        {
            $tagFilter = New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
            New-AzDynatraceMonitorTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName02 -LogRuleFilteringTag $tagFilter
        } | Should -Not -Throw
    }
}
