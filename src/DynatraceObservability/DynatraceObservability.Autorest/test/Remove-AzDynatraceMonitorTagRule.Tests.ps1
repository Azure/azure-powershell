if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDynatraceMonitorTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDynatraceMonitorTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDynatraceMonitorTagRule' {
    It 'Delete' {
        { Remove-AzDynatraceMonitorTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {             
            $tagFilter = New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
            $obj = New-AzDynatraceMonitorTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -LogRuleFilteringTag $tagFilter
            Remove-AzDynatraceMonitorTagRule -InputObject $obj
        } | Should -Not -Throw
    }
}
