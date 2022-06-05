if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceModelContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceModelContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceModelContainer' {
    It 'CreateExpanded' {
        { 
            New-AzMLWorkspaceModelContainer -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name modelcontainerpwsh01 -Description "code container for test."
            Remove-AzMLWorkspaceModelContainer -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name modelcontainerpwsh01
        } | Should -Not -Throw
    }
}
