---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/get-aznewrelicmonitormonitoredresource
schema: 2.0.0
---

# Get-AzNewRelicMonitorMonitoredResource

## SYNOPSIS
List the resources currently being monitored by the NewRelic monitor resource.

## SYNTAX

```
Get-AzNewRelicMonitorMonitoredResource -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
List the resources currently being monitored by the NewRelic monitor resource.

## EXAMPLES

### Example 1: List the resources currently being monitored by the NewRelic monitor resource.
```powershell
Get-AzNewRelicMonitorMonitoredResource -MonitorName test-03 -ResourceGroupName ps-test | Format-List
```

```output
Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/JOYERTEST
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SERVERFARMS/PSTEST
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/JOYERTEST2
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.INSIGHTS/COMPONENTS/JOYERTEST2
ReasonForLogsStatus    : CapturedByRules
ReasonForMetricsStatus : 
SendingLog             : Enabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/ACCTEST9482/PROVIDERS/MICROSOFT.INSIGHTS/COMPONENTS/TEST3210
ReasonForLogsStatus    : DiagnosticSettingsLimitReached
ReasonForMetricsStatus : 
SendingLog             : Disabled
SendingMetric          : 

Id                     : /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/MC_KANSINGH-RG_TESTNRCLUSTER_EASTUS/PROVIDERS/MICROSOFT.NETWORK/PUBLICIPADDRESSES/99894EC0-4C67-4D40-BF63-B640D5 
                         9E1596
ReasonForLogsStatus    : DiagnosticSettingsLimitReached
ReasonForMetricsStatus : 
SendingLog             : Disabled
SendingMetric          : 
```

List the resources currently being monitored by the NewRelic monitor resource.

## PARAMETERS

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

### -MonitorName
Name of the Monitors resource

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.IMonitoredResource

## NOTES

ALIASES

## RELATED LINKS

