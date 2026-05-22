if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelIncidentRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelIncidentRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelIncidentRelation' {
    # The incidents/relations endpoint returns 409 when updating an existing relation's target.

    It 'UpdateExpanded' {
        $bookmark = New-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName `
            -Id $env.UpdateincidentRelationBookmarkId2 -WorkspaceName $env.workspaceName -DisplayName $env.UpdateincidentRelationBookmarkName2 -Query "SecurityEvent\n| take 1" `
            -QueryStartTime (get-date).ToUniversalTime() -QueryEndTime (get-date).AddDays(-1).ToUniversalTime() -EventTime (get-date).ToUniversalTime()
        { Update-AzSentinelIncidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -IncidentId $env.UpdateincidentRelationIncidentId -RelationName $env.UpdateincidentRelationId -RelatedResourceId $bookmark.Id } | Should -Throw "already exists on incident"
    }

    It 'UpdateViaIdentityExpanded' {
        $bookmark = New-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName `
            -Id $env.UpdateViaIdincidentRelationBookmarkId2 -WorkspaceName $env.workspaceName -DisplayName $env.UpdateViaIdincidentRelationBookmarkName2 -Query "SecurityEvent\n| take 1" `
            -QueryStartTime (get-date).ToUniversalTime() -QueryEndTime (get-date).AddDays(-1).ToUniversalTime() -EventTime (get-date).ToUniversalTime()
        $incidentRelation = Get-AzSentinelIncidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -IncidentId $env.UpdateViaIdincidentRelationIncidentId -RelationName $env.UpdateViaIdincidentRelationId 
        { Update-AzSentinelIncidentRelation -InputObject $IncidentRelation -RelatedResourceId $bookmark.Id } | Should -Throw "already exists on incident"
    }
}
