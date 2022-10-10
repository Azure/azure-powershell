if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelIncidentComment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelIncidentComment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelIncidentComment' {
    It 'Delete' {
        { Remove-AzSentinelIncidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -IncidentId $env.RemoveincidentCommentIncidentId -Id $env.RemoveincidentCommentId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $incidentComment = Get-AzSentinelIncidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -IncidentId $env.RemoveViaIdincidentCommentIncidentId -Id $env.RemoveViaIdincidentCommentId 
        { Remove-AzSentinelIncidentComment -InputObject $incidentComment } | Should -Not -Throw
    }
}
