---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznetworkwatcherflowloginformation
schema: 2.0.0
---

# Set-AzNetworkWatcherFlowLogInformation

## SYNOPSIS
Configures flow log  and traffic analytics (optional) on a specified resource.

## SYNTAX

### SetExpanded (Default)
```
Set-AzNetworkWatcherFlowLogInformation -NetworkWatcherName <String> -ResourceGroupName <String> -EnableFlowLog
 -StorageAccountId <String> -TargetResourceId <String> [-SubscriptionId <String>] [-EnableRetention]
 [-EnableTrafficAnalytics] [-FormatType <FlowLogFormatType>] [-FormatVersion <Int32>]
 [-RetentionInDays <Int32>] [-TrafficAnalyticsInterval <Int32>] [-WorkspaceGuid <String>]
 [-WorkspaceLocation <String>] [-WorkspaceResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Set
```
Set-AzNetworkWatcherFlowLogInformation -NetworkWatcherName <String> -ResourceGroupName <String>
 -FlowLogConfiguration <IFlowLogInformation> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Default value: None
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

### -EnableFlowLog
Flag to enable/disable flow logging.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableRetention
Flag to enable/disable retention.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableTrafficAnalytics
Flag to enable/disable traffic analytics.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FlowLogConfiguration
Information on the configuration of flow log and traffic analytics (optional) .
To construct, see NOTES section for FLOWLOGCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation
Parameter Sets: Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -FormatType
The file type of flow log.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType
Parameter Sets: SetExpanded
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
Parameter Sets: SetExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -RetentionInDays
Number of days to retain flow log records.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageAccountId
ID of the storage account which is used to store the flow log.

```yaml
Type: System.String
Parameter Sets: SetExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceId
The ID of the resource to configure for flow log and traffic analytics (optional) .

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TrafficAnalyticsInterval
The interval in minutes which would decide how frequently TA service should do flow analytics

```yaml
Type: System.Int32
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WorkspaceGuid
The resource guid of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WorkspaceLocation
The location of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WorkspaceResourceId
Resource Id of the attached workspace

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation

## ALIASES

### Set-AzNetworkWatcherConfigFlowLog

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### FLOWLOGCONFIGURATION <IFlowLogInformation>: Information on the configuration of flow log and traffic analytics (optional) .
  - `Enabled <Boolean>`: Flag to enable/disable flow logging.
  - `NetworkWatcherFlowAnalyticConfigurationEnabled <Boolean>`: Flag to enable/disable traffic analytics.
  - `NetworkWatcherFlowAnalyticConfigurationWorkspaceId <String>`: The resource guid of the attached workspace
  - `NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion <String>`: The location of the attached workspace
  - `NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId <String>`: Resource Id of the attached workspace 
  - `StorageId <String>`: ID of the storage account which is used to store the flow log.
  - `TargetResourceId <String>`: The ID of the resource to configure for flow log and traffic analytics (optional) .
  - `[FormatType <FlowLogFormatType?>]`: The file type of flow log.
  - `[FormatVersion <Int32?>]`: The version (revision) of the flow log.
  - `[NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval <Int32?>]`: The interval in minutes which would decide how frequently TA service should do flow analytics
  - `[RetentionPolicyDay <Int32?>]`: Number of days to retain flow log records.
  - `[RetentionPolicyEnabled <Boolean?>]`: Flag to enable/disable retention.

## RELATED LINKS

