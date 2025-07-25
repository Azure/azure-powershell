if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelDataConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelDataConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelDataConnector' -Tag 'LiveOnly' {
    It 'UpdateExpanded' {
        $dataConnector = Update-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.updateDataConnectorId -Office365 -SharePoint "Enabled"
        $dataConnector.SharePointState | Should -Be "Enabled"
    }

    It 'UpdateViaIdentityExpanded' {
        $dataConnector = Get-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.updateDataConnectorId
        $dataConnectorUpdate = Update-AzSentinelDataConnector -InputObject $dataConnector -Office365 -Teams "Enabled"
        $dataConnectorUpdate.TeamState | Should -Be "Enabled"
    }
}
