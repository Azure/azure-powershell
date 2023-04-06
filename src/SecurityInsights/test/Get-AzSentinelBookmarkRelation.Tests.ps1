if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelBookmarkRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelBookmarkRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelBookmarkRelation' {
    It 'List'  {
        $bookmarkRelations = Get-AzSentinelbookmarkRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -BookmarkId $env.GetbookmarkRelationBookmarkId
        $bookmarkRelations.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $bookmarkRelation = Get-AzSentinelbookmarkRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -BookmarkId $env.GetbookmarkRelationBookmarkId -RelationName $env.GetbookmarkRelationId
        $bookmarkRelation.Name | Should -Be $env.GetbookmarkRelationId
    }

    It 'GetViaIdentity' {
        $bookmarkRelation = Get-AzSentinelbookmarkRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -BookmarkId $env.GetbookmarkRelationBookmarkId -RelationName $env.GetbookmarkRelationId
        $bookmarkRelationViaIdentity = Get-AzSentinelbookmarkRelation -InputObject $bookmarkRelation
        $bookmarkRelationViaIdentity.Name | Should -Be $env.GetbookmarkRelationId
    }
}
