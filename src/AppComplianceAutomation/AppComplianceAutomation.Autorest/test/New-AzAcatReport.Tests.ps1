if(($null -eq $TestName) -or ($TestName -contains 'New-AzAcatReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAcatReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAcatReport' {
    It 'Create' {
        $param = New-AzAcatReportResourceObject -Resource @(@{ResourceId = $env.ResourceId})
        $report = $param | New-AzAcatReport -Name $env.ReportName
        $report.Name | Should -Be $env.ReportName
    }

    It 'CreateExpanded' {
        $report = New-AzAcatReport -Name $env.ReportName -Resource @(@{ResourceId = $env.ResourceId})
        $report.Name | Should -Be $env.ReportName
    }
}
