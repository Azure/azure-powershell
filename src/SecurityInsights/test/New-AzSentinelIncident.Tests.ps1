if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelIncident'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelIncident.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelIncident' {
    It 'CreateExpanded' {
        $incident = New-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id ((New-Guid).Guid) -Severity Informational -Status New -Title "NewIncidentPSTest"
        $incident.Title | Should -Be "NewIncidentPSTest"
    }
}
