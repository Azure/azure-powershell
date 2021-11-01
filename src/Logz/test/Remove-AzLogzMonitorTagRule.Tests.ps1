if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzLogzMonitorTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzLogzMonitorTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzLogzMonitorTagRule' {
    It 'Delete' {
        { 
            New-AzLogzMonitorTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
            Remove-AzLogzMonitorTagRule -ResourceGroupName $env.resourceGroup-MonitorName $env.monitorName01  
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $tagRule = New-AzLogzMonitorTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
            Remove-AzLogzMonitorTagRule -InputObject $tagRule 
        } | Should -Not -Throw
    }
}
