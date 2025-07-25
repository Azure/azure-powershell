if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelDataConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelDataConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelDataConnector' {
    It 'Delete' {
        $dataConnector = New-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
           -Id $env.RemoveDataConnectorId -Kind 'MicrosoftCloudAppSecurity' -Alerts "Enabled" -DiscoveryLog "Disabled"
        { Remove-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $dataConnector.Name } | Should -Not -Throw
    } 

    It 'DeleteViaIdentity' {
        $dataConnector = New-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.RemoveDataConnectorIdInputObject -Kind 'MicrosoftCloudAppSecurity' -Alerts "Enabled" -DiscoveryLog "Disabled"
        { Remove-AzSentinelDataConnector -InputObject $dataConnector } | Should -Not -Throw
    }
}
 