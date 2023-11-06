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

