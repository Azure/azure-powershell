if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelBookmarkRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelBookmarkRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelBookmarkRelation' {
    It 'UpdateExpanded' {
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Severity Informational -Status New -Title "UpdateBookmarkRelationPSTest"
        $bookmarkRelation = Update-AzSentinelBookmarkRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -BookmarkId $env.UpdatebookmarkRelationBookmarkId -RelationName $env.UpdateBookmarkRelationId -RelatedResourceId $incident.Id
        $bookmarkRelation.RelatedResourceId | Should -Be $incident.Id
    }

    It 'UpdateViaIdentityExpanded' {
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Severity Informational -Status New -Title "UpdateViaIdBookmarkRelationPSTest"
        $bookmarkRelation = Get-AzSentinelBookmarkRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -BookmarkId $env.UpdateViaIdbookmarkRelationBookmarkId -RelationName $env.UpdateViaIdBookmarkRelationId
        $bookmarkRelationUpdate = Update-AzSentinelBookmarkRelation -InputObject $bookmarkRelation -RelatedResourceId $incident.Id
        $bookmarkRelationUpdate.RelatedResourceId | Should -Be $incident.Id
    }
}
