if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelBookmark'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelBookmark.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelBookmark' {
    It 'Delete' {
        { Remove-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.RemoveBookmarkId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $bookmark = Get-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
        -Id $env.RemoveViaIdBookmarkId
        { Remove-AzSentinelBookmark -InputObject $bookmark } | Should -Not -Throw
    }
}
