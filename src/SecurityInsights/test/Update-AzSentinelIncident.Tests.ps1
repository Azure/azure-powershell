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
        $incident = Update-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.UpdateincidentId -Status "Active"
        $incident.Status | Should -Be "Active"
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $incident = Get-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.UpdateViaincidentId 
        $incidentUpdate = $incident | Update-AzSentinelIncident -Status "Active"
        $incidentUpdate.Status | Should -Be "Active"
    }
}
