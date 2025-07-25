---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/test-azactiongroup
schema: 2.0.0
---

# Test-AzActionGroup

## SYNOPSIS
Send test notifications to a set of provided receivers

## SYNTAX

### CreateExpanded (Default)
```
Test-AzActionGroup -ActionGroupName <String> -ResourceGroupName <String> -AlertType <String>
 -Receiver <IActionGroupReceiver[]> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
Test-AzActionGroup -InputObject <IActionGroupIdentity> -AlertType <String> -Receiver <IActionGroupReceiver[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Send test notifications to a set of provided receivers

## EXAMPLES

### Example 1: Send test notifications to provided receiver
```powershell
$sms1 = New-AzActionGroupSmsReceiverObject -CountryCode 86 -Name user1 -PhoneNumber 'phonenumber'
$email2 = New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user2
Test-AzActionGroup -ActionGroupName actiongroup1 -ResourceGroupName monitor-action -AlertType servicehealth -Receiver $email2,$sms1
```

```output
ActionDetail              : {{
                              "MechanismType": "Email",
                              "Name": "user2",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-11-08T05:16:09.6280455+00:00"
                            }, {
                              "MechanismType": "Sms",
                              "Name": "user1",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-11-08T05:16:09.642967+00:00"
                            }}
CompletedTime             : 2023-11-08T05:18:10.6755827+00:00
ContextNotificationSource : Microsoft.Insights/TestNotification
ContextType               : Microsoft.Insights/ServiceHealth
CreatedTime               : 2023-11-08T05:16:00.7951739+00:00
State                     : Complete
```

This command sends test notifications to a set of provided receivers.

## PARAMETERS

### -ActionGroupName
The name of the action group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertType
The value of the supported alert type.
Supported alert type values are: servicehealth, metricstaticthreshold, metricsdynamicthreshold, logalertv2, smartalert, webtestalert, logalertv1numresult, logalertv1metricmeasurement, resourcehealth, activitylog, actualcostbudget, forecastedbudget

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Receiver
The list of receivers that are part of this action group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupReceiver[]
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.ITestNotificationDetailsResponse

## NOTES

## RELATED LINKS

