if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelIncidentTeam'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelIncidentTeam.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelIncidentTeam' {
    It 'CreateExpanded' {
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.NewincidentTeamIncidentId -Severity Informational -Status New -Title $env.NewincidentTeamIncidentName
        $team = New-AzSentinelIncidentTeam -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -TeamName "NITPSTest" -IncidentId $incident.Name
        $team.Name | Should -Be "NITPSTest"
    }
}
