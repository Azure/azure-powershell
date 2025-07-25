if(($null -eq $TestName) -or ($TestName -contains 'WorkspaceCleanRemoveOnlineEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'WorkspaceCleanRemoveOnlineEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'WorkspaceCleanRemoveOnlineEndpoint' {
    It 'DeleteOnlineDeployment' {
        {
            Remove-AzMLWorkspaceOnlineDeployment -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -EndpointName $env.onlineEndpoint -Name $env.onlineDeployment
        } | Should -Not -Throw
    }

    It 'DeleteOnlineEndpoint' {
        {
            Remove-AzMLWorkspaceOnlineEndpoint -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.onlineEndpoint
        } | Should -Not -Throw
    }
}
