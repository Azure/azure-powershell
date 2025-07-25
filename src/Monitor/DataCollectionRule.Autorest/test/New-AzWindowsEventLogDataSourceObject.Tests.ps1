if(($null -eq $TestName) -or ($TestName -contains 'New-AzWindowsEventLogDataSourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWindowsEventLogDataSourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWindowsEventLogDataSourceObject' {
    It '__AllParameterSets' {
        {
            New-AzWindowsEventLogDataSourceObject -Name cloudSecurityTeamEvents -Stream Microsoft-WindowsEvent -XPathQuery "Security!"
        } | Should -Not -Throw
    }
}
