---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/update-aznewrelicmonitoredsubscription
schema: 2.0.0
---

# Update-AzNewRelicMonitoredSubscription

## SYNOPSIS
Update the subscriptions that are being monitored by the NewRelic monitor resource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNewRelicMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-PatchOperation <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNewRelicMonitoredSubscription -InputObject <INewRelicIdentity>
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-PatchOperation <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzNewRelicMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzNewRelicMonitoredSubscription -MonitorName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update the subscriptions that are being monitored by the NewRelic monitor resource

## EXAMPLES

### Example 1: Update the subscriptions that are being monitored by the NewRelic monitor resource
```powershell
$includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
$sub1 = New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail user1@outlook.com -Status Active -SubscriptionId 11111111-2222-3333-4444-123456789101
Update-AzNewRelicMonitoredSubscription -MonitorName test-01 -ResourceGroupName group-test -PatchOperation AddComplete -MonitoredSubscriptionList $sub1
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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoredSubscriptionList
List of subscriptions and the state of the monitoring.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IMonitoredSubscription[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

