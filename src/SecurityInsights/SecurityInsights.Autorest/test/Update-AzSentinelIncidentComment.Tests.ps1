if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelIncidentComment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelIncidentComment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelIncidentComment' {
    It 'UpdateExpanded' {
         $incidentComment = Update-AzSentinelIncidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -IncidentId $env.UpdateincidentCommentIncidentId -Id $env.UpdateincidentCommentId -Message "UpdateIncidentCommentPSTest"
        $incidentComment.Message | Should -Be "UpdateIncidentCommentPSTest"
    }

    It 'UpdateViaIdentityExpanded' {
        $incidentComment = Get-AzSentinelIncidentComment -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -IncidentId $env.UpdateincidentCommentIncidentId -Id $env.UpdateincidentCommentId 
        $incidentCommentUpdate = Update-AzSentinelIncidentComment -InputObject $incidentComment -Message "UpdateIncidentCommentPSTest"
        $incidentCommentUpdate.Message | Should -Be "UpdateIncidentCommentPSTest"
    }
}
