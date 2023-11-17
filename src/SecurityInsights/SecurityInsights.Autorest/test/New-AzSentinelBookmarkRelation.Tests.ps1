if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelBookmarkRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelBookmarkRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelBookmarkRelation' {
    It 'CreateExpanded' {
        $bookmark = New-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName `
            -WorkspaceName $env.workspaceName -Id $env.NewbookmarkRelationBookmarkId -DisplayName $env.NewbookmarkRelationBookmarkName -Query "SecurityEvent\n| take 1" `
            -QueryStartTime (get-date).AddDays(-1).ToUniversalTime() -QueryEndTime (get-date).ToUniversalTime() -EventTime (get-date).ToUniversalTime()
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.NewBookmarkRelationIncidentId -Severity Informational -Status New -Title $env.NewbookmarkRelationIncidentName
        $bookmarkRelation = New-AzSentinelBookmarkRelation -BookmarkId $bookmark.Name -RelationName $env.NewBookmarkRelationId `
            -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RelatedResourceId $incident.Id
        $bookmarkRelation.RelatedResourceId | Should -Be $incident.Id
    }
} 
