---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/set-azactiongroup
schema: 2.0.0
---

# Set-AzActionGroup

## SYNOPSIS
Create a new action group or update an existing one.

## SYNTAX

```
Set-AzActionGroup -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-ArmRoleReceiver <IArmRoleReceiver[]>] [-AutomationRunbookReceiver <IAutomationRunbookReceiver[]>]
 [-AzureAppPushReceiver <IAzureAppPushReceiver[]>] [-AzureFunctionReceiver <IAzureFunctionReceiver[]>]
 [-EmailReceiver <IEmailReceiver[]>] [-Enabled] [-ItsmReceiver <IItsmReceiver[]>]
 [-LogicAppReceiver <ILogicAppReceiver[]>] [-ShortName <String>] [-SmsReceiver <ISmsReceiver[]>]
 [-Tag <Hashtable>] [-VoiceReceiver <IVoiceReceiver[]>] [-WebhookReceiver <IWebhookReceiver[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new action group or update an existing one.

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

### -ArmRoleReceiver
The list of ARM role receivers that are part of this action group.
Roles are Azure RBAC roles and only built-in roles are supported.
To construct, see NOTES section for ARMROLERECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IArmRoleReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutomationRunbookReceiver
The list of AutomationRunbook receivers that are part of this action group.
To construct, see NOTES section for AUTOMATIONRUNBOOKRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IAutomationRunbookReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureAppPushReceiver
The list of AzureAppPush receivers that are part of this action group.
To construct, see NOTES section for AZUREAPPPUSHRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IAzureAppPushReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureFunctionReceiver
The list of azure function receivers that are part of this action group.
To construct, see NOTES section for AZUREFUNCTIONRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IAzureFunctionReceiver[]
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

### -EmailReceiver
The list of email receivers that are part of this action group.
To construct, see NOTES section for EMAILRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IEmailReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Enabled
Indicates whether this action group is enabled.
If an action group is not enabled, then none of its receivers will receive communications.

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

### -ItsmReceiver
The list of ITSM receivers that are part of this action group.
To construct, see NOTES section for ITSMRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IItsmReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

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

### -LogicAppReceiver
The list of logic app receivers that are part of this action group.
To construct, see NOTES section for LOGICAPPRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.ILogicAppReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the action group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ActionGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

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

### -ShortName
The short name of the action group.
This will be used in SMS messages.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SmsReceiver
The list of SMS receivers that are part of this action group.
To construct, see NOTES section for SMSRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.ISmsReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The Azure subscription Id.

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

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VoiceReceiver
The list of voice receivers that are part of this action group.
To construct, see NOTES section for VOICERECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IVoiceReceiver[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebhookReceiver
The list of webhook receivers that are part of this action group.
To construct, see NOTES section for WEBHOOKRECEIVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IWebhookReceiver[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IActionGroupResource

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ARMROLERECEIVER <IArmRoleReceiver[]>: The list of ARM role receivers that are part of this action group. Roles are Azure RBAC roles and only built-in roles are supported.
  - `Name <String>`: The name of the arm role receiver. Names must be unique across all receivers within an action group.
  - `RoleId <String>`: The arm role id.
  - `UseCommonAlertSchema <Boolean>`: Indicates whether to use common alert schema.

#### AUTOMATIONRUNBOOKRECEIVER <IAutomationRunbookReceiver[]>: The list of AutomationRunbook receivers that are part of this action group.
  - `AutomationAccountId <String>`: The Azure automation account Id which holds this runbook and authenticate to Azure resource.
  - `IsGlobalRunbook <Boolean>`: Indicates whether this instance is global runbook.
  - `RunbookName <String>`: The name for this runbook.
  - `UseCommonAlertSchema <Boolean>`: Indicates whether to use common alert schema.
  - `WebhookResourceId <String>`: The resource id for webhook linked to this runbook.
  - `[Name <String>]`: Indicates name of the webhook.
  - `[ServiceUri <String>]`: The URI where webhooks should be sent.

#### AZUREAPPPUSHRECEIVER <IAzureAppPushReceiver[]>: The list of AzureAppPush receivers that are part of this action group.
  - `EmailAddress <String>`: The email address registered for the Azure mobile app.
  - `Name <String>`: The name of the Azure mobile app push receiver. Names must be unique across all receivers within an action group.

#### AZUREFUNCTIONRECEIVER <IAzureFunctionReceiver[]>: The list of azure function receivers that are part of this action group.
  - `FunctionAppResourceId <String>`: The azure resource id of the function app.
  - `FunctionName <String>`: The function name in the function app.
  - `HttpTriggerUrl <String>`: The http trigger url where http request sent to.
  - `Name <String>`: The name of the azure function receiver. Names must be unique across all receivers within an action group.
  - `UseCommonAlertSchema <Boolean>`: Indicates whether to use common alert schema.

#### EMAILRECEIVER <IEmailReceiver[]>: The list of email receivers that are part of this action group.
  - `EmailAddress <String>`: The email address of this receiver.
  - `Name <String>`: The name of the email receiver. Names must be unique across all receivers within an action group.
  - `UseCommonAlertSchema <Boolean>`: Indicates whether to use common alert schema.

#### ITSMRECEIVER <IItsmReceiver[]>: The list of ITSM receivers that are part of this action group.
  - `ConnectionId <String>`: Unique identification of ITSM connection among multiple defined in above workspace.
  - `Name <String>`: The name of the Itsm receiver. Names must be unique across all receivers within an action group.
  - `Region <String>`: Region in which workspace resides. Supported values:'centralindia','japaneast','southeastasia','australiasoutheast','uksouth','westcentralus','canadacentral','eastus','westeurope'
  - `TicketConfiguration <String>`: JSON blob for the configurations of the ITSM action. CreateMultipleWorkItems option will be part of this blob as well.
  - `WorkspaceId <String>`: OMS LA instance identifier.

#### LOGICAPPRECEIVER <ILogicAppReceiver[]>: The list of logic app receivers that are part of this action group.
  - `CallbackUrl <String>`: The callback url where http request sent to.
  - `Name <String>`: The name of the logic app receiver. Names must be unique across all receivers within an action group.
  - `ResourceId <String>`: The azure resource id of the logic app receiver.
  - `UseCommonAlertSchema <Boolean>`: Indicates whether to use common alert schema.

#### SMSRECEIVER <ISmsReceiver[]>: The list of SMS receivers that are part of this action group.
  - `CountryCode <String>`: The country code of the SMS receiver.
  - `Name <String>`: The name of the SMS receiver. Names must be unique across all receivers within an action group.
  - `PhoneNumber <String>`: The phone number of the SMS receiver.

#### VOICERECEIVER <IVoiceReceiver[]>: The list of voice receivers that are part of this action group.
  - `CountryCode <String>`: The country code of the voice receiver.
  - `Name <String>`: The name of the voice receiver. Names must be unique across all receivers within an action group.
  - `PhoneNumber <String>`: The phone number of the voice receiver.

#### WEBHOOKRECEIVER <IWebhookReceiver[]>: The list of webhook receivers that are part of this action group.
  - `Name <String>`: The name of the webhook receiver. Names must be unique across all receivers within an action group.
  - `ServiceUri <String>`: The URI where webhooks should be sent.
  - `UseCommonAlertSchema <Boolean>`: Indicates whether to use common alert schema.

## RELATED LINKS

