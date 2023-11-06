---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azactiongroup
schema: 2.0.0
---

# New-AzActionGroup

## SYNOPSIS
Create a new action group or update an existing one.

## SYNTAX

### CreateExpanded (Default)
```
New-AzActionGroup -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-ArmRoleReceiver <IArmRoleReceiver[]>] [-AutomationRunbookReceiver <IAutomationRunbookReceiver[]>]
 [-AzureAppPushReceiver <IAzureAppPushReceiver[]>] [-AzureFunctionReceiver <IAzureFunctionReceiver[]>]
 [-EmailReceiver <IEmailReceiver[]>] [-Enabled] [-EventHubReceiver <IEventHubReceiver[]>]
 [-GroupShortName <String>] [-ItsmReceiver <IItsmReceiver[]>] [-LogicAppReceiver <ILogicAppReceiver[]>]
 [-SmsReceiver <ISmsReceiver[]>] [-Tag <Hashtable>] [-VoiceReceiver <IVoiceReceiver[]>]
 [-WebhookReceiver <IWebhookReceiver[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzActionGroup -InputObject <IActionGroupIdentity> -Location <String>
 [-ArmRoleReceiver <IArmRoleReceiver[]>] [-AutomationRunbookReceiver <IAutomationRunbookReceiver[]>]
 [-AzureAppPushReceiver <IAzureAppPushReceiver[]>] [-AzureFunctionReceiver <IAzureFunctionReceiver[]>]
 [-EmailReceiver <IEmailReceiver[]>] [-Enabled] [-EventHubReceiver <IEventHubReceiver[]>]
 [-GroupShortName <String>] [-ItsmReceiver <IItsmReceiver[]>] [-LogicAppReceiver <ILogicAppReceiver[]>]
 [-SmsReceiver <ISmsReceiver[]>] [-Tag <Hashtable>] [-VoiceReceiver <IVoiceReceiver[]>]
 [-WebhookReceiver <IWebhookReceiver[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzActionGroup -Name <String> -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzActionGroup -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new action group or update an existing one.

## EXAMPLES

### Example 1: Create an action group
```powershell
$email1 = New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user1
$sms1 = New-AzActionGroupSmsReceiverObject -CountryCode '{countrycode}' -Name user2 -PhoneNumber '{phonenumber}'
New-AzActionGroup -Name 'actiongroup1' -ResourceGroupName 'Monitor-Action' -Location northcentralus -GroupShortName ag1 -EmailReceiver $email1 -SmsReceiver $sms1
```

```output
ArmRoleReceiver           : {}
AutomationRunbookReceiver : {}
AzureAppPushReceiver      : {}
AzureFunctionReceiver     : {}
EmailReceiver             : {{
                              "name": "user1",
                              "emailAddress": "user@example.com",
                              "useCommonAlertSchema": false,
                              "status": "Enabled"
                            }}
Enabled                   : False
EventHubReceiver          : {}
GroupShortName            : ag1
Id                        : /subscriptions/{subid}/resourceGroups/Monitor-Action/providers/microsoft.insights/actionGroups/actiongroup1
ItsmReceiver              : {}
Location                  : northcentralus
LogicAppReceiver          : {}
Name                      : actiongroup1
ResourceGroupName         : Monitor-Action
SmsReceiver               : {{
                              "name": "user2",
                              "countryCode": "{countrycode}",
                              "phoneNumber": "{phonenumber}",
                              "status": "Enabled"
                            }}
Tag                       : {
                            }
Type                      : Microsoft.Insights/ActionGroups
VoiceReceiver             : {}
WebhookReceiver           : {}
```

The first two commands create two receivers.
The final command creates an action group including the two receivers.

### Example 2: create another action group
```powershell
New-AzActionGroup -Name 'actiongroup1' -ResourceGroupName 'Monitor-Action' -Location northcentralus -GroupShortName ag1
```

```output
ArmRoleReceiver           : {}
AutomationRunbookReceiver : {}
AzureAppPushReceiver      : {}
AzureFunctionReceiver     : {}
EmailReceiver             : {}
Enabled                   : False
EventHubReceiver          : {}
GroupShortName            : ag1
Id                        : /subscriptions/{subid}/resourceGroups/Monitor-Action/providers/microsoft.insights/actionGroups/actiongroup1
ItsmReceiver              : {}
Location                  : northcentralus
LogicAppReceiver          : {}
Name                      : actiongroup1
ResourceGroupName         : Monitor-Action
SmsReceiver               : {}
Tag                       : {
                            }
Type                      : Microsoft.Insights/ActionGroups
VoiceReceiver             : {}
WebhookReceiver           : {}
```

This command creates an action group with no receiver.

## PARAMETERS

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

### -Enabled
Indicates whether this action group is enabled.
If an action group is not enabled, then none of its receivers will receive communications.

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -GroupShortName
The short name of the action group.
This will be used in SMS messages.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: ShortName

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

### -Location
Resource location

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

### -Name
The name of the action group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: ActionGroupName

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

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupResource

## NOTES

## RELATED LINKS

