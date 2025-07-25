if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceComponentContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceComponentContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceComponentContainer' { #Moved
    It 'CreateExpanded' -skip {
        { 
            New-AzMLWorkspaceComponentContainer -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name component-pwsh01 -IsArchived
            # Operation DeleteComponentContainer Not Allowed
            # Remove-AzMLWorkspaceComponentContainer -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name component-pwsh01
        } | Should -Not -Throw
    }
}
