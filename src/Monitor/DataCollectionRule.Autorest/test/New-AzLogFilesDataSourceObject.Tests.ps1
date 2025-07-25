if(($null -eq $TestName) -or ($TestName -contains 'New-AzLogFilesDataSourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLogFilesDataSourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzLogFilesDataSourceObject' {
    It '__AllParameterSets' {
        {
            New-AzLogFilesDataSourceObject -FilePattern "C:\\JavaLogs\\*.log" -Stream "Custom-TabularData-ABC" -Name myTabularLogDataSource -SettingTextRecordStartTimestampFormat "yyyy-MM-ddTHH:mm:ssK"
        } | Should -Not -Throw
    }
}
