### Example 1: Add receiver to specified action group
```powershell
$enventhub = New-AzActionGroupEventHubReceiverObject -EventHubName "testEventHub" -EventHubNameSpace "actiongrouptest" -Name "sample eventhub" -SubscriptionId '{subid}'
Update-AzActionGroup -Name actiongroup1 -ResourceGroupName monitor-action -EventHubReceiver $enventhub
```

```output
ArmRoleReceiver           : {}
AutomationRunbookReceiver : {}
AzureAppPushReceiver      : {}
AzureFunctionReceiver     : {}
EmailReceiver             : {{
                              "name": "user1",
                              "emailAddress": "{user}@microsoft.com",
                              "useCommonAlertSchema": false,
                              "status": "Enabled"
                            }}
Enabled                   : False
EventHubReceiver          : {{
                              "name": "sample eventhub",
                              "eventHubNameSpace": "actiongrouptest",
                              "eventHubName": "testEventHub",
                              "useCommonAlertSchema": false,
                              "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47",
                              "subscriptionId": "{subid}"
                            }}
GroupShortName            : ag1
Id                        : /subscriptions/{subid}/resourceGroups/monitor-action/providers/microsoft.insights/actionGroups/actiongroup1
ItsmReceiver              : {}
Location                  : southcentralus
LogicAppReceiver          : {}
Name                      : actiongroup1
ResourceGroupName         : monitor-action
SmsReceiver               : {{
                              "name": "user2",
                              "countryCode": "{code}",
                              "phoneNumber": "{phonenumber}",
                              "status": "Enabled"
                            }}
Tag                       : {
                            }
Type                      : Microsoft.Insights/ActionGroups
VoiceReceiver             : {}
WebhookReceiver           : {}
```

This command updates specified action group with name and group.

### Example 2: Delete receiver to specified action group
```powershell
$ag = Get-AzActionGroup -Name actiongroup1 -ResourceGroupName monitor-action
Update-AzActionGroup -InputObject $ag -EventHubReceiver $null
```

```output
ArmRoleReceiver           : {}
AutomationRunbookReceiver : {}
AzureAppPushReceiver      : {}
AzureFunctionReceiver     : {}
EmailReceiver             : {{
                              "name": "user1",
                              "emailAddress": "{user}@microsoft.com",
                              "useCommonAlertSchema": false,
                              "status": "Enabled"
                            }}
Enabled                   : False
EventHubReceiver          : {}
GroupShortName            : ag1
Id                        : /subscriptions/{subid}/resourceGroups/Monitor-Action/providers/microsoft.insights/actionGroups/actiongroup1
ItsmReceiver              : {}
Location                  : southcentralus
LogicAppReceiver          : {}
Name                      : actiongroup1
ResourceGroupName         : Monitor-Action
SmsReceiver               : {{
                              "name": "user2",
                              "countryCode": "{code}",
                              "phoneNumber": "{phonenumber}",
                              "status": "Enabled"
                            }}
Tag                       : {
                            }
Type                      : Microsoft.Insights/ActionGroups
VoiceReceiver             : {}
WebhookReceiver           : {}
```

The first command get specified action group. The final command updates specified action group with action group object.

