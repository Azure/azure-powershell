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

