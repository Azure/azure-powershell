if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelIncidentComment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelIncidentComment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelIncidentComment' {
    It 'List' {
        $incidentComments = Get-AzSentinelincidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.GetIncidentId
        $incidentComments.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $incidentComment = Get-AzSentinelincidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.GetIncidentId -Id $env.GetIncidentCommentId
        $incidentComment.Name | Should -Be $env.GetIncidentCommentId
    }

    It 'GetViaIdentity' -skip {
        $incidentComment = Get-AzSentinelincidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.GetIncidentId -Id $env.GetIncidentCommentId
        $incidentCommentViaId = Get-AzSentinelincident -InputObject $incidentComment
        $incidentCommentViaId.Name | Should -Be $env.GetIncidentCommentId
    }
}
