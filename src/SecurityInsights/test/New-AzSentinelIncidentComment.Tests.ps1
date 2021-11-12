if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelIncidentComment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelIncidentComment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelIncidentComment' {
    It 'CreateExpanded' {
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id ((New-Guid).Guid) -Severity Informational -Status New -Title "NewIncidentCommentPSTest"
        $incidentComment = New-AzSentinelIncidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id ((New-Guid).Guid) -IncidentId $incident.Name -Message "NewIncidentCommentPSTest"
        $incidentComment.Message | Should -Be "NewIncidentCommentPSTest"
    }
}
