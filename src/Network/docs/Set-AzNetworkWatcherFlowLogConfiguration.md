---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznetworkwatcherflowlogconfiguration
schema: 2.0.0
---

# Set-AzNetworkWatcherFlowLogConfiguration

## SYNOPSIS
Configures flow log  and traffic analytics (optional) on a specified resource.

## SYNTAX

### SetSubscriptionIdViaHost (Default)
```
Set-AzNetworkWatcherFlowLogConfiguration -NetworkWatcherName <String> -ResourceGroupName <String>
 [-Parameter <IFlowLogInformation>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetExpanded
```
Set-AzNetworkWatcherFlowLogConfiguration -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -Enabled <Boolean> [-FormatType <FlowLogFormatType>] [-FormatVersion <Int32>]
 -NetworkWatcherFlowAnalyticsConfigurationEnabled <Boolean>
 [-NetworkWatcherFlowAnalyticsConfigurationTrafficAnalyticsInterval <Int32>]
 -NetworkWatcherFlowAnalyticsConfigurationWorkspaceId <String>
 -NetworkWatcherFlowAnalyticsConfigurationWorkspaceRegion <String>
 -NetworkWatcherFlowAnalyticsConfigurationWorkspaceResourceId <String> [-RetentionPolicyDay <Int32>]
 [-RetentionPolicyEnabled <Boolean>] -StorageId <String> -TargetResourceId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set
```
Set-AzNetworkWatcherFlowLogConfiguration -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Parameter <IFlowLogInformation>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SetSubscriptionIdViaHostExpanded
```
Set-AzNetworkWatcherFlowLogConfiguration -NetworkWatcherName <String> -ResourceGroupName <String>
 -Enabled <Boolean> [-FormatType <FlowLogFormatType>] [-FormatVersion <Int32>]
 -NetworkWatcherFlowAnalyticsConfigurationEnabled <Boolean>
 [-NetworkWatcherFlowAnalyticsConfigurationTrafficAnalyticsInterval <Int32>]
 -NetworkWatcherFlowAnalyticsConfigurationWorkspaceId <String>
 -NetworkWatcherFlowAnalyticsConfigurationWorkspaceRegion <String>
 -NetworkWatcherFlowAnalyticsConfigurationWorkspaceResourceId <String> [-RetentionPolicyDay <Int32>]
 [-RetentionPolicyEnabled <Boolean>] -StorageId <String> -TargetResourceId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Configures flow log  and traffic analytics (optional) on a specified resource.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Enabled
Flag to enable/disable flow logging.

```yaml
Type: System.Boolean
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -FormatType
The file type of flow log.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FormatVersion
The version (revision) of the flow log.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherFlowAnalyticsConfigurationEnabled
Flag to enable/disable traffic analytics.

```yaml
Type: System.Boolean
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherFlowAnalyticsConfigurationTrafficAnalyticsInterval
The interval in minutes which would decide how frequently TA service should do flow analytics

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherFlowAnalyticsConfigurationWorkspaceId
The resource guid of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherFlowAnalyticsConfigurationWorkspaceRegion
The location of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherFlowAnalyticsConfigurationWorkspaceResourceId
Resource Id of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkWatcherName
The name of the network watcher resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Information on the configuration of flow log and traffic analytics (optional) .

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation
Parameter Sets: SetSubscriptionIdViaHost, Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the network watcher resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionPolicyDay
Number of days to retain flow log records.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionPolicyEnabled
Flag to enable/disable retention.

```yaml
Type: System.Boolean
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageId
ID of the storage account which is used to store the flow log.

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: SetExpanded, Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
The ID of the resource to configure for flow log and traffic analytics (optional) .

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznetworkwatcherflowlogconfiguration](https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznetworkwatcherflowlogconfiguration)

