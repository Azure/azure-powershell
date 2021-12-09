if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelIncidentRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelIncidentRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelIncidentRelation' {
    It 'Delete' {
        { Remove-AzSentinelIncidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.RemoveincidentCommentIncidentId -RelationName $env.RemoveincidentRelationId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        $incidentRelation = Get-AzSentinelIncidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -IncidentId $env.RemoveViaIdincidentCommentIncidentId -RelationName $env.RemoveViaIdincidentRelationId
        { $incidentRelation | Remove-AzSentinelIncidentRelation } | Should -Not -Throw
    }
}
