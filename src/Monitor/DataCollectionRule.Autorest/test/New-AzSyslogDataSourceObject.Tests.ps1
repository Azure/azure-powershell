if(($null -eq $TestName) -or ($TestName -contains 'New-AzSyslogDataSourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSyslogDataSourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSyslogDataSourceObject' {
    It '__AllParameterSets' {
        {
            New-AzSyslogDataSourceObject -FacilityName syslog -LogLevel Alert,Critical,Emergency -Name syslogBase -Stream Microsoft-Syslog
        } | Should -Not -Throw
    }
}
