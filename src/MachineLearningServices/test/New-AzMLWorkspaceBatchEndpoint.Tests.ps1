if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceBatchEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceBatchEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceBatchEndpoint' {
    # New operation InternalServerError
    It 'CreateExpanded' -skip {
        { 
            New-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name be-asd98 -AuthMode 'Key' -Location 'eastus'
            Update-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name be-asd98 -Tag @{'key'='value'}
            Remove-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name be-asd98
        } | Should -Not -Throw
    }
}
