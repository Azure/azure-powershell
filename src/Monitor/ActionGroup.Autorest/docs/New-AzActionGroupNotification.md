---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azactiongroupnotification
schema: 2.0.0
---

# New-AzActionGroupNotification

## SYNOPSIS
Send test notifications to a set of provided receivers

## SYNTAX

### CreateExpanded (Default)
```
New-AzActionGroupNotification -ActionGroupName <String> -ResourceGroupName <String> -AlertType <String>
 [-SubscriptionId <String>] [-ArmRoleReceiver <IArmRoleReceiver[]>]
 [-AutomationRunbookReceiver <IAutomationRunbookReceiver[]>] [-AzureAppPushReceiver <IAzureAppPushReceiver[]>]
 [-AzureFunctionReceiver <IAzureFunctionReceiver[]>] [-EmailReceiver <IEmailReceiver[]>]
 [-EventHubReceiver <IEventHubReceiver[]>] [-ItsmReceiver <IItsmReceiver[]>]
 [-LogicAppReceiver <ILogicAppReceiver[]>] [-SmsReceiver <ISmsReceiver[]>] [-VoiceReceiver <IVoiceReceiver[]>]
 [-WebhookReceiver <IWebhookReceiver[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzActionGroupNotification -InputObject <IActionGroupIdentity> -AlertType <String>
 [-ArmRoleReceiver <IArmRoleReceiver[]>] [-AutomationRunbookReceiver <IAutomationRunbookReceiver[]>]
 [-AzureAppPushReceiver <IAzureAppPushReceiver[]>] [-AzureFunctionReceiver <IAzureFunctionReceiver[]>]
 [-EmailReceiver <IEmailReceiver[]>] [-EventHubReceiver <IEventHubReceiver[]>]
 [-ItsmReceiver <IItsmReceiver[]>] [-LogicAppReceiver <ILogicAppReceiver[]>] [-SmsReceiver <ISmsReceiver[]>]
 [-VoiceReceiver <IVoiceReceiver[]>] [-WebhookReceiver <IWebhookReceiver[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzActionGroupNotification -ActionGroupName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzActionGroupNotification -ActionGroupName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Send test notifications to a set of provided receivers

## EXAMPLES

### Example 1: Send test notifications to provided receiver
```powershell
$email1 = New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user1
New-AzActionGroupNotification -ActionGroupName actiongroup1 -ResourceGroupName monitor-action -AlertType servicehealth -EmailReceiver $email1
```

```output
ActionDetail              : {{
                              "MechanismType": "Email",
                              "Name": "user1",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-10-20T07:26:08.271003+00:00"
                            }}
CompletedTime             : 2023-10-20T07:28:08.7753691+00:00
ContextNotificationSource : Microsoft.Insights/TestNotification
ContextType               : Microsoft.Insights/ServiceHealth
CreatedTime               : 2023-10-20T07:26:05.2860073+00:00
State                     : Complete
```

This command sends test notifications to a set of provided receivers.

## PARAMETERS

### -ActionGroupName
The name of the action group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArmRoleReceiver
The list of ARM role receivers that are part of this action group.
Roles are Azure RBAC roles and only built-in roles are supported.
To construct, see NOTES section for ARMROLERECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IArmRoleReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -AutomationRunbookReceiver
The list of AutomationRunbook receivers that are part of this action group.
To construct, see NOTES section for AUTOMATIONRUNBOOKRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IAutomationRunbookReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureAppPushReceiver
The list of AzureAppPush receivers that are part of this action group.
To construct, see NOTES section for AZUREAPPPUSHRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IAzureAppPushReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFunctionReceiver
The list of azure function receivers that are part of this action group.
To construct, see NOTES section for AZUREFUNCTIONRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IAzureFunctionReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -EmailReceiver
The list of email receivers that are part of this action group.
To construct, see NOTES section for EMAILRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IEmailReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubReceiver
The list of event hub receivers that are part of this action group.
To construct, see NOTES section for EVENTHUBRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IEventHubReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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

### -ItsmReceiver
The list of ITSM receivers that are part of this action group.
To construct, see NOTES section for ITSMRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IItsmReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogicAppReceiver
The list of logic app receivers that are part of this action group.
To construct, see NOTES section for LOGICAPPRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.ILogicAppReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmsReceiver
The list of SMS receivers that are part of this action group.
To construct, see NOTES section for SMSRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.ISmsReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VoiceReceiver
The list of voice receivers that are part of this action group.
To construct, see NOTES section for VOICERECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IVoiceReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebhookReceiver
The list of webhook receivers that are part of this action group.
To construct, see NOTES section for WEBHOOKRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IWebhookReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.ITestNotificationDetailsResponse

## NOTES

## RELATED LINKS

