if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceConnection' { #Moved
    It 'CreateExpanded' -skip {
        { 
            New-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name test01 -AuthType 'None' -Category 'ContainerRegistry' -Target "www.facebook.com"
            Remove-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name test01
        } | Should -Not -Throw
    }
}
