---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/update-aznewrelicmonitoredsubscription
schema: 2.0.0
---

# Update-AzNewRelicMonitoredSubscription

## SYNOPSIS
Add the subscriptions that should be monitored by the NewRelic monitor resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNewRelicMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-PatchOperation <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNewRelicMonitoredSubscription -InputObject <INewRelicIdentity>
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-PatchOperation <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Add the subscriptions that should be monitored by the NewRelic monitor resource.

## EXAMPLES

### Example 1: Update the subscriptions that are being monitored by the NewRelic monitor resource
```powershell
$includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
$sub1 = New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail user1@outlook.com -Status Active -SubscriptionId 11111111-2222-3333-4444-12345678910122
Update-AzNewRelicMonitoredSubscription -MonitorName test-01 -ResourceGroupName group-test -PatchOperation AddComplete -MonitoredSubscriptionList $sub1
```

```output
Id                        : /subscriptions/11111111-2222-3333-4444-123456789123/resourceGroups/group_test/providers/NewRelic.Observability/monitors/test-01/monitoredSubscriptions/default
MonitoredSubscriptionList : {{
                              "tagRules": {
                                "provisioningState": "Accepted"
                              },
                              "subscriptionId": "00000000-0000-0000-0000-000000000000",
                              "status": "Active"
                            }, {
                              "tagRules": {
                                "provisioningState": "Accepted"
                              },
                              "subscriptionId": "11111111-2222-3333-4444-123456789101",
                              "status": "Active"
                            }}
Name                      : default
PatchOperation            : 
ProvisioningState         : 
ResourceGroupName         : group_test
Type                      : NewRelic.Observability/monitors/monitoredSubscriptions
```

This command updates the subscriptions that are being monitored by the NewRelic monitor resource.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitoredSubscriptionList
List of subscriptions and the state of the monitoring.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IMonitoredSubscription[]
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -PatchOperation
The operation for the patch on the resource.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS
