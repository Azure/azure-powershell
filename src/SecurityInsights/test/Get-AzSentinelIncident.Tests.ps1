if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelIncident'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelIncident.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelIncident' {
    It 'List' {
        $incidents = Get-AzSentinelincident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $incidents.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $incident = Get-AzSentinelincident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetincidentId
        $incident.Name | Should -Be $env.incidentId
    }

    It 'GetViaIdentity' {
        $incident = Get-AzSentinelincident -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetincidentId
        $incidentviaId = $incident | Get-AzSentinelincident
        $incidentviaId.Name | Should -Be $env.GetincidentId
    }
}
