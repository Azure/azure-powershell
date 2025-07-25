---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/save-azpaloaltonetworksfirewalllogprofile
schema: 2.0.0
---

# Save-AzPaloAltoNetworksFirewallLogProfile

## SYNOPSIS
Log Profile for Firewall

## SYNTAX

### SaveExpanded (Default)
```
Save-AzPaloAltoNetworksFirewallLogProfile -FirewallName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ApplicationInsightId <String>] [-ApplicationInsightKey <String>]
 [-CommonDestinationEventHubConfigurationsId <String>] [-CommonDestinationEventHubConfigurationsName <String>]
 [-CommonDestinationEventHubConfigurationsNameSpace <String>]
 [-CommonDestinationEventHubConfigurationsPolicyName <String>]
 [-CommonDestinationEventHubConfigurationsSubscriptionId <String>]
 [-CommonDestinationMonitorConfigurationsId <String>]
 [-CommonDestinationMonitorConfigurationsPrimaryKey <String>]
 [-CommonDestinationMonitorConfigurationsSecondaryKey <String>]
 [-CommonDestinationMonitorConfigurationsSubscriptionId <String>]
 [-CommonDestinationMonitorConfigurationsWorkspace <String>]
 [-CommonDestinationStorageConfigurationsAccountName <String>]
 [-CommonDestinationStorageConfigurationsId <String>]
 [-CommonDestinationStorageConfigurationsSubscriptionId <String>]
 [-DecryptLogDestinationEventHubConfigurationsId <String>]
 [-DecryptLogDestinationEventHubConfigurationsName <String>]
 [-DecryptLogDestinationEventHubConfigurationsNameSpace <String>]
 [-DecryptLogDestinationEventHubConfigurationsPolicyName <String>]
 [-DecryptLogDestinationEventHubConfigurationsSubscriptionId <String>]
 [-DecryptLogDestinationMonitorConfigurationsId <String>]
 [-DecryptLogDestinationMonitorConfigurationsPrimaryKey <String>]
 [-DecryptLogDestinationMonitorConfigurationsSecondaryKey <String>]
 [-DecryptLogDestinationMonitorConfigurationsSubscriptionId <String>]
 [-DecryptLogDestinationMonitorConfigurationsWorkspace <String>]
 [-DecryptLogDestinationStorageConfigurationsAccountName <String>]
 [-DecryptLogDestinationStorageConfigurationsId <String>]
 [-DecryptLogDestinationStorageConfigurationsSubscriptionId <String>] [-LogOption <String>] [-LogType <String>]
 [-ThreatLogDestinationEventHubConfigurationsId <String>]
 [-ThreatLogDestinationEventHubConfigurationsName <String>]
 [-ThreatLogDestinationEventHubConfigurationsNameSpace <String>]
 [-ThreatLogDestinationEventHubConfigurationsPolicyName <String>]
 [-ThreatLogDestinationEventHubConfigurationsSubscriptionId <String>]
 [-ThreatLogDestinationMonitorConfigurationsId <String>]
 [-ThreatLogDestinationMonitorConfigurationsPrimaryKey <String>]
 [-ThreatLogDestinationMonitorConfigurationsSecondaryKey <String>]
 [-ThreatLogDestinationMonitorConfigurationsSubscriptionId <String>]
 [-ThreatLogDestinationMonitorConfigurationsWorkspace <String>]
 [-ThreatLogDestinationStorageConfigurationsAccountName <String>]
 [-ThreatLogDestinationStorageConfigurationsId <String>]
 [-ThreatLogDestinationStorageConfigurationsSubscriptionId <String>]
 [-TrafficLogDestinationEventHubConfigurationsId <String>]
 [-TrafficLogDestinationEventHubConfigurationsName <String>]
 [-TrafficLogDestinationEventHubConfigurationsNameSpace <String>]
 [-TrafficLogDestinationEventHubConfigurationsPolicyName <String>]
 [-TrafficLogDestinationEventHubConfigurationsSubscriptionId <String>]
 [-TrafficLogDestinationMonitorConfigurationsId <String>]
 [-TrafficLogDestinationMonitorConfigurationsPrimaryKey <String>]
 [-TrafficLogDestinationMonitorConfigurationsSecondaryKey <String>]
 [-TrafficLogDestinationMonitorConfigurationsSubscriptionId <String>]
 [-TrafficLogDestinationMonitorConfigurationsWorkspace <String>]
 [-TrafficLogDestinationStorageConfigurationsAccountName <String>]
 [-TrafficLogDestinationStorageConfigurationsId <String>]
 [-TrafficLogDestinationStorageConfigurationsSubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SaveViaIdentityExpanded
```
Save-AzPaloAltoNetworksFirewallLogProfile -InputObject <IPaloAltoNetworksIdentity>
 [-ApplicationInsightId <String>] [-ApplicationInsightKey <String>]
 [-CommonDestinationEventHubConfigurationsId <String>] [-CommonDestinationEventHubConfigurationsName <String>]
 [-CommonDestinationEventHubConfigurationsNameSpace <String>]
 [-CommonDestinationEventHubConfigurationsPolicyName <String>]
 [-CommonDestinationEventHubConfigurationsSubscriptionId <String>]
 [-CommonDestinationMonitorConfigurationsId <String>]
 [-CommonDestinationMonitorConfigurationsPrimaryKey <String>]
 [-CommonDestinationMonitorConfigurationsSecondaryKey <String>]
 [-CommonDestinationMonitorConfigurationsSubscriptionId <String>]
 [-CommonDestinationMonitorConfigurationsWorkspace <String>]
 [-CommonDestinationStorageConfigurationsAccountName <String>]
 [-CommonDestinationStorageConfigurationsId <String>]
 [-CommonDestinationStorageConfigurationsSubscriptionId <String>]
 [-DecryptLogDestinationEventHubConfigurationsId <String>]
 [-DecryptLogDestinationEventHubConfigurationsName <String>]
 [-DecryptLogDestinationEventHubConfigurationsNameSpace <String>]
 [-DecryptLogDestinationEventHubConfigurationsPolicyName <String>]
 [-DecryptLogDestinationEventHubConfigurationsSubscriptionId <String>]
 [-DecryptLogDestinationMonitorConfigurationsId <String>]
 [-DecryptLogDestinationMonitorConfigurationsPrimaryKey <String>]
 [-DecryptLogDestinationMonitorConfigurationsSecondaryKey <String>]
 [-DecryptLogDestinationMonitorConfigurationsSubscriptionId <String>]
 [-DecryptLogDestinationMonitorConfigurationsWorkspace <String>]
 [-DecryptLogDestinationStorageConfigurationsAccountName <String>]
 [-DecryptLogDestinationStorageConfigurationsId <String>]
 [-DecryptLogDestinationStorageConfigurationsSubscriptionId <String>] [-LogOption <String>] [-LogType <String>]
 [-ThreatLogDestinationEventHubConfigurationsId <String>]
 [-ThreatLogDestinationEventHubConfigurationsName <String>]
 [-ThreatLogDestinationEventHubConfigurationsNameSpace <String>]
 [-ThreatLogDestinationEventHubConfigurationsPolicyName <String>]
 [-ThreatLogDestinationEventHubConfigurationsSubscriptionId <String>]
 [-ThreatLogDestinationMonitorConfigurationsId <String>]
 [-ThreatLogDestinationMonitorConfigurationsPrimaryKey <String>]
 [-ThreatLogDestinationMonitorConfigurationsSecondaryKey <String>]
 [-ThreatLogDestinationMonitorConfigurationsSubscriptionId <String>]
 [-ThreatLogDestinationMonitorConfigurationsWorkspace <String>]
 [-ThreatLogDestinationStorageConfigurationsAccountName <String>]
 [-ThreatLogDestinationStorageConfigurationsId <String>]
 [-ThreatLogDestinationStorageConfigurationsSubscriptionId <String>]
 [-TrafficLogDestinationEventHubConfigurationsId <String>]
 [-TrafficLogDestinationEventHubConfigurationsName <String>]
 [-TrafficLogDestinationEventHubConfigurationsNameSpace <String>]
 [-TrafficLogDestinationEventHubConfigurationsPolicyName <String>]
 [-TrafficLogDestinationEventHubConfigurationsSubscriptionId <String>]
 [-TrafficLogDestinationMonitorConfigurationsId <String>]
 [-TrafficLogDestinationMonitorConfigurationsPrimaryKey <String>]
 [-TrafficLogDestinationMonitorConfigurationsSecondaryKey <String>]
 [-TrafficLogDestinationMonitorConfigurationsSubscriptionId <String>]
 [-TrafficLogDestinationMonitorConfigurationsWorkspace <String>]
 [-TrafficLogDestinationStorageConfigurationsAccountName <String>]
 [-TrafficLogDestinationStorageConfigurationsId <String>]
 [-TrafficLogDestinationStorageConfigurationsSubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Log Profile for Firewall

## EXAMPLES

### Example 1: Log Profile for Firewall.
```powershell
Save-AzPaloAltoNetworksFirewallLogProfile -FirewallName azps-firewall -ResourceGroupName azps_test_group_pan -LogType TRAFFIC -LogOption SAME_DESTINATION -CommonDestinationMonitorConfigurationsId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/sudh_fire_test/providers/Microsoft.OperationalInsights/workspaces/testAnalyticsX -CommonDestinationMonitorConfigurationsPrimaryKey 7******Q== -CommonDestinationMonitorConfigurationsSecondaryKey 7******w== -CommonDestinationMonitorConfigurationsSubscriptionId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX -CommonDestinationMonitorConfigurationsWorkspace XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX -PassThru
```

```output
True
```

Log Profile for Firewall.

## PARAMETERS

### -ApplicationInsightId
Resource id for Application Insights

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationInsightKey
Application Insights key

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationEventHubConfigurationsId
Resource ID of EventHub

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationEventHubConfigurationsName
EventHub name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationEventHubConfigurationsNameSpace
EventHub namespace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationEventHubConfigurationsPolicyName
EventHub policy name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationEventHubConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationMonitorConfigurationsId
Resource ID of MonitorLog

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationMonitorConfigurationsPrimaryKey
Primary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationMonitorConfigurationsSecondaryKey
Secondary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationMonitorConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationMonitorConfigurationsWorkspace
MonitorLog workspace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationStorageConfigurationsAccountName
Storage account name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationStorageConfigurationsId
Resource ID of storage account

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDestinationStorageConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationEventHubConfigurationsId
Resource ID of EventHub

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationEventHubConfigurationsName
EventHub name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationEventHubConfigurationsNameSpace
EventHub namespace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationEventHubConfigurationsPolicyName
EventHub policy name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationEventHubConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationMonitorConfigurationsId
Resource ID of MonitorLog

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationMonitorConfigurationsPrimaryKey
Primary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationMonitorConfigurationsSecondaryKey
Secondary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationMonitorConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationMonitorConfigurationsWorkspace
MonitorLog workspace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationStorageConfigurationsAccountName
Storage account name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationStorageConfigurationsId
Resource ID of storage account

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptLogDestinationStorageConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

### -FirewallName
Firewall resource name

```yaml
Type: System.String
Parameter Sets: SaveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: SaveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LogOption
Log option SAME/INDIVIDUAL

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogType
One of possible log type

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: SaveExpanded
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
Parameter Sets: SaveExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationEventHubConfigurationsId
Resource ID of EventHub

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationEventHubConfigurationsName
EventHub name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationEventHubConfigurationsNameSpace
EventHub namespace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationEventHubConfigurationsPolicyName
EventHub policy name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationEventHubConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationMonitorConfigurationsId
Resource ID of MonitorLog

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationMonitorConfigurationsPrimaryKey
Primary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationMonitorConfigurationsSecondaryKey
Secondary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationMonitorConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationMonitorConfigurationsWorkspace
MonitorLog workspace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationStorageConfigurationsAccountName
Storage account name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationStorageConfigurationsId
Resource ID of storage account

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatLogDestinationStorageConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationEventHubConfigurationsId
Resource ID of EventHub

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationEventHubConfigurationsName
EventHub name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationEventHubConfigurationsNameSpace
EventHub namespace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationEventHubConfigurationsPolicyName
EventHub policy name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationEventHubConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationMonitorConfigurationsId
Resource ID of MonitorLog

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationMonitorConfigurationsPrimaryKey
Primary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationMonitorConfigurationsSecondaryKey
Secondary Key value for Monitor

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationMonitorConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationMonitorConfigurationsWorkspace
MonitorLog workspace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationStorageConfigurationsAccountName
Storage account name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationStorageConfigurationsId
Resource ID of storage account

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficLogDestinationStorageConfigurationsSubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
