---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznetworkwatcherflowlogconfiguration
schema: 2.0.0
---

# Set-AzNetworkWatcherFlowLogConfiguration

## SYNOPSIS
Configures flow log  and traffic analytics (optional) on a specified resource.

## SYNTAX

### Set (Default)
```
Set-AzNetworkWatcherFlowLogConfiguration -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Parameter <IFlowLogInformation>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### SetExpanded
```
Set-AzNetworkWatcherFlowLogConfiguration -NetworkWatcherName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -Enabled -NetworkWatcherFlowAnalyticConfigurationEnabled
 -NetworkWatcherFlowAnalyticConfigurationWorkspaceId <String>
 -NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion <String>
 -NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId <String> -StorageId <String>
 -TargetResourceId <String> [-FormatType <FlowLogFormatType>] [-FormatVersion <Int32>]
 [-NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval <Int32>] [-RetentionPolicyDay <Int32>]
 [-RetentionPolicyEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzNetworkWatcherFlowLogConfiguration -InputObject <INetworkIdentity> -Enabled
 -NetworkWatcherFlowAnalyticConfigurationEnabled -NetworkWatcherFlowAnalyticConfigurationWorkspaceId <String>
 -NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion <String>
 -NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId <String> -StorageId <String>
 -TargetResourceId <String> [-FormatType <FlowLogFormatType>] [-FormatVersion <Int32>]
 [-NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval <Int32>] [-RetentionPolicyDay <Int32>]
 [-RetentionPolicyEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentity
```
Set-AzNetworkWatcherFlowLogConfiguration -InputObject <INetworkIdentity> [-Parameter <IFlowLogInformation>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Configures flow log  and traffic analytics (optional) on a specified resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
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
Dynamic: False
```

### -Enabled
Flag to enable/disable flow logging.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FormatType
The file type of flow log.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FormatVersion
The version (revision) of the flow log.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: SetViaIdentityExpanded, SetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherFlowAnalyticConfigurationEnabled
Flag to enable/disable traffic analytics.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval
The interval in minutes which would decide how frequently TA service should do flow analytics

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherFlowAnalyticConfigurationWorkspaceId
The resource guid of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion
The location of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId
Resource Id of the attached workspace 

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkWatcherName
The name of the network watcher resource.

```yaml
Type: System.String
Parameter Sets: Set, SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Information on the configuration of flow log and traffic analytics (optional) .

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation
Parameter Sets: Set, SetViaIdentity
Aliases: NetworkWatcher

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the network watcher resource group.

```yaml
Type: System.String
Parameter Sets: Set, SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RetentionPolicyDay
Number of days to retain flow log records.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RetentionPolicyEnabled
Flag to enable/disable retention.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageId
ID of the storage account which is used to store the flow log.

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Set, SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceId
The ID of the resource to configure for flow log and traffic analytics (optional) .

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation

## ALIASES

### Set-AzNetworkWatcherConfigFlowLog

## RELATED LINKS

