if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelIncident'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelIncident.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelIncident' {
    It 'UpdateExpanded' {
        $getIncident = Get-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.UpdateincidentId
        $incident = Update-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.UpdateincidentId -Status "Active" -Title $getIncident.Title -Severity $getIncident.Severity
        $incident.Status | Should -Be "Active"
    }

    It 'UpdateViaIdentityExpanded' {
        $incident = Get-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.UpdateViaIdincidentId 
        $incidentUpdate = Update-AzSentinelIncident -InputObject $incident -Status "Active" -Title $incident.Title -Severity $incident.Severity
        $incidentUpdate.Status | Should -Be "Active"
    }
}
