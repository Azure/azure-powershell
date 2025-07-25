if(($null -eq $TestName) -or ($TestName -contains 'Sync-AzMLWorkspaceKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzMLWorkspaceKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Sync-AzMLWorkspaceKey' {
    It 'Resync' {
        { Sync-AzMLWorkspaceKey -ResourceGroupName $env.DataGroupName -Name $env.computeworkspace } | Should -Not -Throw
    }
}
