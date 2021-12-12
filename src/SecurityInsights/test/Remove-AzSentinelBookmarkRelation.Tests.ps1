if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelBookmarkRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelBookmarkRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelBookmarkRelation' {
    It 'Delete' {
        { Remove-AzSentinelBookmarkRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -BookmarkId $env.RemovebookmarkRelationBookmarkId -RelationName $env.RemoveBookmarkRelationId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $bookmarkRelation = Get-AzSentinelBookmarkRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -BookmarkId $env.RemoveViaIdbookmarkRelationBookmarkId -RelationName $env.RemoveViaIdBookmarkRelationId
        { Remove-AzSentinelBookmarkRelation -InputObject $bookmarkRelation } | Should -Not -Throw
    }
}
