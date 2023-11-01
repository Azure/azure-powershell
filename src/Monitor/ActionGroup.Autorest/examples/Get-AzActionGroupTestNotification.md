### Example 1: Get test result of specified action group
```powershell
Get-AzActionGroupTestNotification -ActionGroupName actiongroup1 -ResourceGroupName monitor-action -NotificationId 11000009464546
```

```output
ActionDetail              : {{
                              "MechanismType": "Sms",
                              "Name": "user2_-SMSAction-",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-10-20T07:39:58.3543022+00:00"
                            }}
CompletedTime             : 2023-10-20T07:40:30.5419846+00:00
ContextNotificationSource : Microsoft.Insights/TestNotification
ContextType               : Microsoft.Insights/ServiceHealth
CreatedTime               : 2023-10-20T07:39:54.4913346+00:00
State                     : Complete
```

This command gets the test notifications by specified action group and notification id.

