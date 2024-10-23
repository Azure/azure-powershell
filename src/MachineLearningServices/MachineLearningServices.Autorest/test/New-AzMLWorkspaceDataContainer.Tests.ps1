if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceDataContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceDataContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceDataContainer' { #Moved
    It 'CreateExpanded' -skip {
        { 
            New-AzMLWorkspaceDataContainer -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name datacontainer-pwsh01 -DataType 'uri_file' 
            # InternalServerError
            # Remove-AzMLWorkspaceDataContainer -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name datacontainer-pwsh01
        } | Should -Not -Throw
    }
}
