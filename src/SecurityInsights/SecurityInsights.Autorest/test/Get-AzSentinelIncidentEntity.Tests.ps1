if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelIncidentEntity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelIncidentEntity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelIncidentEntity' {
    It 'List' {
       $incident = Get-AzSentinelIncident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName | Where {$_.Title -eq "Sign-ins from IPs that attempt sign-ins to disabled accounts"}
       $incidentEntity = Get-AzSentinelIncidentEntity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $incident.Name
       $incidentEntity | Should -Not -Be $null
    }
}
