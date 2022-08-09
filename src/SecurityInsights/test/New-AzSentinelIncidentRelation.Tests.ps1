if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelIncidentRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelIncidentRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelIncidentRelation' {
    It 'CreateExpanded' {
        $bookmark = New-AzSentinelBookmark  -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -DisplayName "NewIncidentRelationPSTest" -Query "SecurityEvent\n| take 1" `
            -QueryStartTime (get-date).AddDays(-1).ToUniversalTime() -QueryEndTime (get-date).ToUniversalTime() -EventTime (get-date).ToUniversalTime()
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Severity Informational -Status New -Title "NewIncidentRelationPSTest"
        $incidentRelation = New-AzSentinelIncidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -IncidentId $incident.Name -RelatedResourceId $bookmark.Id
        $incidentRelation.RelatedResourceId | Should -Be $bookmark.Id
    }
}
