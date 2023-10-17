if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataFlowObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataFlowObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataFlowObject' {
    It '__AllParameterSets' {
        {
            New-AzDataFlowObject -Stream Microsoft-Perf,Microsoft-Syslog,Microsoft-WindowsEvent -Destination eastusWorkSpace
        } | Should -Not -Throw
    }
}
