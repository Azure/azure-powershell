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
    It 'CreateViaIdentityIncidentExpanded' {
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
        -Id $env.NewIncidentCommentIncidentId -Severity Informational -Status New -Title "New incident comment incident name"
        $incidentComment = New-AzSentinelIncidentComment -IncidentInputObject $incident -Id $env.NewIncidentCommentId -Message $env.NewIncidentCommentName
        $incidentComment.Message | Should -Be $env.NewIncidentCommentName
    }
}
