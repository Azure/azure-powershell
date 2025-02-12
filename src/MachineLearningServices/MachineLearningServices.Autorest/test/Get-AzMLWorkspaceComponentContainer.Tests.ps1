if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceComponentContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceComponentContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceComponentContainer' {
    It 'List' {
        { Get-AzMLWorkspaceComponentContainer -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeworkspace } | Should -Not -Throw
    }

    It 'Get' {
        {  Get-AzMLWorkspaceComponentContainer -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeworkspace -Name $env.componentName } | Should -Not -Throw
    }
}
