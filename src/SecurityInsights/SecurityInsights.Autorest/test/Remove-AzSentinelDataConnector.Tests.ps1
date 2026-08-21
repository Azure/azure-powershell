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
    # Changed from MicrosoftCloudAppSecurity to GenericUI - MCAS needs a service license we don't have.
    It 'Delete' {
        $dataConnector = New-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
           -Id $env.RemoveDataConnectorId -Kind 'GenericUI' `
           -UiConfigTitle "Test" -UiConfigPublisher "Test" -UiConfigDescriptionMarkdown "Test" `
           -UiConfigGraphQueriesTableName "TestTable_CL" `
           -UiConfigGraphQuery @(@{metricName="Events";legend="Events";baseQuery="TestTable_CL"}) `
           -UiConfigSampleQuery @(@{description="All";query="TestTable_CL"}) `
           -UiConfigDataType @(@{name="TestTable_CL";lastDataReceivedQuery="TestTable_CL | summarize max(TimeGenerated)"}) `
           -UiConfigConnectivityCriterion @(@{type="IsConnectedQuery";value=@("TestTable_CL | take 1")}) `
           -AvailabilityIsPreview $true -AvailabilityStatus 1 `
           -UiConfigInstructionStep @(@{title="Connect";description="Test"}) `
           -PermissionCustom @(@{name="TestPermission";description="Test permission"})
        { Remove-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $dataConnector.Name } | Should -Not -Throw
    } 

    It 'DeleteViaIdentity' {
        $dataConnector = New-AzSentinelDataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.RemoveDataConnectorIdInputObject -Kind 'GenericUI' `
            -UiConfigTitle "Test2" -UiConfigPublisher "Test" -UiConfigDescriptionMarkdown "Test" `
            -UiConfigGraphQueriesTableName "TestTable_CL" `
            -UiConfigGraphQuery @(@{metricName="Events";legend="Events";baseQuery="TestTable_CL"}) `
            -UiConfigSampleQuery @(@{description="All";query="TestTable_CL"}) `
            -UiConfigDataType @(@{name="TestTable_CL";lastDataReceivedQuery="TestTable_CL | summarize max(TimeGenerated)"}) `
            -UiConfigConnectivityCriterion @(@{type="IsConnectedQuery";value=@("TestTable_CL | take 1")}) `
            -AvailabilityIsPreview $true -AvailabilityStatus 1 `
            -UiConfigInstructionStep @(@{title="Connect";description="Test"}) `
            -PermissionCustom @(@{name="TestPermission";description="Test permission"})
        { Remove-AzSentinelDataConnector -InputObject $dataConnector } | Should -Not -Throw
    }
}
 