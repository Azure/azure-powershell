---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/new-azactiongroup
schema: 2.0.0
---

# New-AzActionGroup

## SYNOPSIS
Create a new action group or update an existing one.

## SYNTAX

### Create (Default)
```
New-AzActionGroup -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-ActionGroup <IActionGroupResource>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzActionGroup -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Enabled
 -GroupShortName <String> -Location <String> [-ArmRoleReceiver <IArmRoleReceiver[]>]
 [-AutomationRunbookReceiver <IAutomationRunbookReceiver[]>] [-AzureAppPushReceiver <IAzureAppPushReceiver[]>]
 [-AzureFunctionReceiver <IAzureFunctionReceiver[]>] [-EmailReceiver <IEmailReceiver[]>]
 [-ItsmReceiver <IItsmReceiver[]>] [-LogicAppReceiver <ILogicAppReceiver[]>] [-SmsReceiver <ISmsReceiver[]>]
 [-Tag <IResourceTags>] [-VoiceReceiver <IVoiceReceiver[]>] [-WebhookReceiver <IWebhookReceiver[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzActionGroup -InputObject <IMonitorIdentity> -Enabled -GroupShortName <String> -Location <String>
 [-ArmRoleReceiver <IArmRoleReceiver[]>] [-AutomationRunbookReceiver <IAutomationRunbookReceiver[]>]
 [-AzureAppPushReceiver <IAzureAppPushReceiver[]>] [-AzureFunctionReceiver <IAzureFunctionReceiver[]>]
 [-EmailReceiver <IEmailReceiver[]>] [-ItsmReceiver <IItsmReceiver[]>]
 [-LogicAppReceiver <ILogicAppReceiver[]>] [-SmsReceiver <ISmsReceiver[]>] [-Tag <IResourceTags>]
 [-VoiceReceiver <IVoiceReceiver[]>] [-WebhookReceiver <IWebhookReceiver[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzActionGroup -InputObject <IMonitorIdentity> [-ActionGroup <IActionGroupResource>]
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

### -ActionGroup
An action group resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IActionGroupResource
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ArmRoleReceiver
The list of ARM role receivers that are part of this action group.
Roles are Azure RBAC roles and only built-in roles are supported.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IArmRoleReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IAutomationRunbookReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IAzureAppPushReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IAzureFunctionReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IEmailReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GroupShortName
The short name of the action group.
This will be used in SMS messages.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.IMonitorIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ItsmReceiver
The list of ITSM receivers that are part of this action group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IItsmReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.ILogicAppReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SmsReceiver
The list of SMS receivers that are part of this action group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.ISmsReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IResourceTags
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IVoiceReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IWebhookReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IActionGroupResource

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.IMonitorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20190301.IActionGroupResource

## ALIASES

## RELATED LINKS

