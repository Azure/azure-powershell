---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/invoke-azdatadogmanagemonitorsreagentconnector
schema: 2.0.0
---

# Invoke-AzDatadogManageMonitorSreAgentConnector

## SYNOPSIS
Manages Datadog MCP connectors to add/remove for the SRE Agent.

## SYNTAX

### ManageViaIdentity (Default)
```
Invoke-AzDatadogManageMonitorSreAgentConnector -InputObject <IDatadogIdentity>
 -Request <ISreAgentConnectorRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageViaJsonString
```
Invoke-AzDatadogManageMonitorSreAgentConnector -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageViaJsonFilePath
```
Invoke-AzDatadogManageMonitorSreAgentConnector -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageExpanded
```
Invoke-AzDatadogManageMonitorSreAgentConnector -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Action <String> -McpConnectorResourceIdList <ISreAgentConfiguration[]>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Manage
```
Invoke-AzDatadogManageMonitorSreAgentConnector -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Request <ISreAgentConnectorRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageViaIdentityExpanded
```
Invoke-AzDatadogManageMonitorSreAgentConnector -InputObject <IDatadogIdentity> -Action <String>
 -McpConnectorResourceIdList <ISreAgentConfiguration[]> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Manages Datadog MCP connectors to add/remove for the SRE Agent.

## EXAMPLES

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

This command adds a Datadog MCP connector to the SRE Agent for the given monitor resource.
Pass `-Action Remove` to detach a connector.

## PARAMETERS

### -Action
Add/Remove action.

```yaml
Type: System.String
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: ManageViaIdentity, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Manage operation

```yaml
Type: System.String
Parameter Sets: ManageViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Manage operation

```yaml
Type: System.String
Parameter Sets: ManageViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -McpConnectorResourceIdList
The list of ARM resource ID of the MCP connector integrated with SRE Agent resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ISreAgentConfiguration[]
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: ManageViaJsonString, ManageViaJsonFilePath, ManageExpanded, Manage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
Request for adding/removing Datadog MCP connectors on SRE Agent resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ISreAgentConnectorRequest
Parameter Sets: ManageViaIdentity, Manage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ManageViaJsonString, ManageViaJsonFilePath, ManageExpanded, Manage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: ManageViaJsonString, ManageViaJsonFilePath, ManageExpanded, Manage
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ISreAgentConnectorRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ISreAgentConfigurationListResponse

## NOTES

## RELATED LINKS
