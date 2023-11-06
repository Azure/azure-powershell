---
external help file: Az.ActionGroup.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azactiongroup
schema: 2.0.0
---

# Get-AzActionGroup

## SYNOPSIS
Get an action group.

## SYNTAX

### List (Default)
```
Get-AzActionGroup [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzActionGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzActionGroup -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzActionGroup -InputObject <IActionGroupIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get an action group.

## EXAMPLES

### Example 1: Get action groups by subscription ID
```powershell
Get-AzActionGroup -SubscriptionId '{subid}'
```

```output
Location       Name         ResourceGroupName
--------       ----         -----------------
northcentralus actiongroup1 Monitor-Action
northcentralus actiongroup2 Monitor-Action
```

This command gets list of action groups by specified subscription.

### Example 2: Get specific action groups with specified resource group
```powershell
Get-AzActionGroup -Name actiongroup1 -ResourceGroupName monitor-action
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

This command gets specific action group with specified resource group.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the action group.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
