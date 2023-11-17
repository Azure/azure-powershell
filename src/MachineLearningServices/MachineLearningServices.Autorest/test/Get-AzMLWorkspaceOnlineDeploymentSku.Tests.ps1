if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceOnlineDeploymentSku'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceOnlineDeploymentSku.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceOnlineDeploymentSku' {
    It 'List' {
        { Get-AzMLWorkspaceOnlineDeploymentSku -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-cli01 -Name blue } | Should -Not -Throw
    }
}
