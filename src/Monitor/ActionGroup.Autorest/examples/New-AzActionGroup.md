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

The first two commands create two receivers. The final command creates an action group including the two receivers.

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

