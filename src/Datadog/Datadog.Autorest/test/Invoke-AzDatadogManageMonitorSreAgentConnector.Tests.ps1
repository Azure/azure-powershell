if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDatadogManageMonitorSreAgentConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDatadogManageMonitorSreAgentConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDatadogManageMonitorSreAgentConnector' {
    It 'ManageViaIdentity' {
        $mcpConnectorResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/agents/$($env.monitorName01)Agent/connectors/testConnector"
        $monitor = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        { Invoke-AzDatadogManageMonitorSreAgentConnector -InputObject $monitor -Request @{ action = 'Add'; mcpConnectorResourceIdList = @(@{ mcpConnectorResourceId = $mcpConnectorResourceId }) } -WhatIf } | Should -Not -Throw
    }

    It 'ManageViaJsonString' {
        $mcpConnectorResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/agents/$($env.monitorName01)Agent/connectors/testConnector"
        $jsonString = @{ action = 'Add'; mcpConnectorResourceIdList = @(@{ mcpConnectorResourceId = $mcpConnectorResourceId }) } | ConvertTo-Json -Depth 4
        { Invoke-AzDatadogManageMonitorSreAgentConnector -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -JsonString $jsonString -WhatIf } | Should -Not -Throw
    }

    It 'ManageViaJsonFilePath' {
        $mcpConnectorResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/agents/$($env.monitorName01)Agent/connectors/testConnector"
        $tempFile = New-TemporaryFile
        @{ action = 'Add'; mcpConnectorResourceIdList = @(@{ mcpConnectorResourceId = $mcpConnectorResourceId }) } | ConvertTo-Json -Depth 4 | Set-Content -Path $tempFile.FullName
        { Invoke-AzDatadogManageMonitorSreAgentConnector -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -JsonFilePath $tempFile.FullName -WhatIf } | Should -Not -Throw
        Remove-Item -Path $tempFile.FullName -Force
    }

    It 'ManageExpanded' {
        $mcpConnectorResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/agents/$($env.monitorName01)Agent/connectors/testConnector"
        { Invoke-AzDatadogManageMonitorSreAgentConnector -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubscriptionId $env.SubscriptionId -Action Add -McpConnectorResourceIdList @(@{ McpConnectorResourceId = $mcpConnectorResourceId }) -WhatIf } | Should -Not -Throw
    }

    It 'Manage' {
        $mcpConnectorResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/agents/$($env.monitorName01)Agent/connectors/testConnector"
        { Invoke-AzDatadogManageMonitorSreAgentConnector -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubscriptionId $env.SubscriptionId -Request @{ action = 'Add'; mcpConnectorResourceIdList = @(@{ mcpConnectorResourceId = $mcpConnectorResourceId }) } -WhatIf } | Should -Not -Throw
    }

    It 'ManageViaIdentityExpanded' {
        $mcpConnectorResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/agents/$($env.monitorName01)Agent/connectors/testConnector"
        $monitor = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        { Invoke-AzDatadogManageMonitorSreAgentConnector -InputObject $monitor -Action Add -McpConnectorResourceIdList @(@{ McpConnectorResourceId = $mcpConnectorResourceId }) -WhatIf } | Should -Not -Throw
    }
}
