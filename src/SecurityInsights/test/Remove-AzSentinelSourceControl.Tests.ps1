if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelSourceControl'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelSourceControl.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelSourceControl' {
    It 'Delete' {
        { Remove-AzSentinelSourceControl -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.RemovesourceControlId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $contentTypes = @("Parser","AnalyticsRule","AutomationRule","HuntingQuery","Playbook","Workbook")
        $sourceControl = Get-AzSentinelSourceControl -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.RemoveViaIdsourceControlId
        { $sourceControl | Remove-AzSentinelSourceControl } | Should -Not -Throw
    }
}
