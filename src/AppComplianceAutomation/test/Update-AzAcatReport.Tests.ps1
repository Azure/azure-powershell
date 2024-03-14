if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAcatReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAcatReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAcatReport' {
    It 'UpdateExpanded' {
        $oldReport = Get-AzAcatReport -Name $env.GeneratedReportName

        $report = Update-AzAcatReport -Name $env.GeneratedReportName `
            -Resource $oldReport.Resource `
            -TimeZone $env.TimeZone `
            -TriggerTime $oldReport.TriggerTime
        $report.TimeZone | Should -Be $env.TimeZone
    }

    It 'Update' {
        $oldReport = Get-AzAcatReport -Name $env.GeneratedReportName
        $oldReport.TimeZone = $env.TimeZone
        $report = $oldReport | Update-AzAcatReport -Name $env.GeneratedReportName
        $report.TimeZone | Should -Be $env.TimeZone
    }
}
