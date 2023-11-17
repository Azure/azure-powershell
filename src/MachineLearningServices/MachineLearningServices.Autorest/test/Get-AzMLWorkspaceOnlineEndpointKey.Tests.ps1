if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceOnlineEndpointKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceOnlineEndpointKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceOnlineEndpointKey' {
    It 'List' {
        { Get-AzMLWorkspaceOnlineEndpointKey -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-cli01 } | Should -Not -Throw
    }
}
