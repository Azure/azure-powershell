if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceStorageAccountKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceStorageAccountKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceStorageAccountKey' {
     # Include secrets 
    It 'List' -skip {
        { Get-AzMLWorkspaceStorageAccountKey -ResourceGroupName ml-rg-test -Name mlworkspace-cli01 } | Should -Not -Throw
    }
}
