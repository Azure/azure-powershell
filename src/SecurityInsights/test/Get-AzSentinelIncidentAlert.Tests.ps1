if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelIncidentAlert'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelIncidentAlert.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelIncidentAlert' {
    It 'List' {
        $incidentAlerts = Get-AzSentinelIncidentAlert -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.GetIncidentId
        $incidentAlerts.Count | Should -BeGreaterorEqual 1
    }
}
