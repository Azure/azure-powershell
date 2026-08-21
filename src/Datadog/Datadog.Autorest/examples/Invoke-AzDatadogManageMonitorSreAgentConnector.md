### Example 1: Add a Datadog MCP connector for the SRE Agent
```powershell
$connectors = @(
  @{ McpConnectorResourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.App/agents/mySreAgent/connectors/myMcpConnector" }
)
Invoke-AzDatadogManageMonitorSreAgentConnector -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Action Add -McpConnectorResourceIdList $connectors
```

```output
McpConnectorResourceId
----------------------
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.App/agents/mySreAgent/connectors/myMcpConnector
```

This command adds a Datadog MCP connector to the SRE Agent for the given monitor resource. Pass `-Action Remove` to detach a connector.

