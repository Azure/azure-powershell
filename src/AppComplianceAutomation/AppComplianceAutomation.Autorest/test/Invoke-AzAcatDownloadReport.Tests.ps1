if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzAcatDownloadReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzAcatDownloadReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzAcatDownloadReport' {
    It 'Download' {
        $fileName = "test-download-report"
        $fullFileName = $fileName + ".csv"
        $filePath = Join-Path "." -ChildPath $fullFileName

        Invoke-AzAcatDownloadReport -Name $env.GeneratedReportName -DownloadType "ComplianceReport" -Path "." -FileName $fileName
        Test-Path -Path $filePath | Should -BeTrue
        Remove-Item -Path $filePath
    }
}
