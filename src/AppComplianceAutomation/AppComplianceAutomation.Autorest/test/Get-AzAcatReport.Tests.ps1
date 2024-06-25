if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAcatReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAcatReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAcatReport' {
    It 'List' {
        $reports = Get-AzAcatReport
        $reports.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $report = Get-AzAcatReport -Name $env.GeneratedReportName
        $report.Name | Should -Be $env.GeneratedReportName
    }
}
