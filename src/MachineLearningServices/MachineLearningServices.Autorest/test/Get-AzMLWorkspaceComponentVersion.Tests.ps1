if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceComponentVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceComponentVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceComponentVersion' {
    It 'List' {
        { Get-AzMLWorkspaceComponentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeworkspace -Name $env.componentName } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMLWorkspaceComponentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeworkspace -Name $env.componentName -Version 1 } | Should -Not -Throw
    }
}
