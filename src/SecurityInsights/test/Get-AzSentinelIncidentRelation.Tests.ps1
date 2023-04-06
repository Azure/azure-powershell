if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelIncidentRelation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelIncidentRelation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelIncidentRelation' {
    It 'List' {
        $incidentRelations = Get-AzSentinelincidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.GetincidentRelationIncidentId
        $incidentRelations.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $incidentRelation = Get-AzSentinelincidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.GetincidentRelationIncidentId -RelationName $env.GetincidentRelationId
        $incidentRelation.Name | Should -Be $env.GetincidentRelationId
    }

    It 'GetViaIdentity' {
        $incidentRelation = Get-AzSentinelincidentRelation -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.GetincidentRelationIncidentId -RelationName $env.GetincidentRelationId
        $incidentRelationViaIdentity = Get-AzSentinelincidentRelation -InputObject $incidentRelation
        $incidentRelationViaIdentity.Name | Should -Be $env.GetincidentRelationId
    }
}
