if(($null -eq $TestName) -or ($TestName -contains 'New-AzIisLogsDataSourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzIisLogsDataSourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzIisLogsDataSourceObject' {
    It '__AllParameterSets' {
        {
            New-AzIisLogsDataSourceObject -Stream "Microsoft-W3CIISLog" -LogDirectory "c:\\test" -Name "iisLogsDataSource"
        } | Should -Not -Throw
    }
}
