### Example 1: Send test notifications to provided receiver
```powershell
$sms1 = New-AzActionGroupSmsReceiverObject -CountryCode 86 -Name user1 -PhoneNumber 'phonenumber'
$email2 = New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user2
Test-AzActionGroup -ActionGroupName actiongroup1 -ResourceGroupName monitor-action -AlertType servicehealth -Receiver $email2,$sms1
```

```output
ActionDetail              : {{
                              "MechanismType": "Email",
                              "Name": "user2",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-11-08T05:16:09.6280455+00:00"
                            }, {
                              "MechanismType": "Sms",
                              "Name": "user1",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-11-08T05:16:09.642967+00:00"
                            }}
CompletedTime             : 2023-11-08T05:18:10.6755827+00:00
ContextNotificationSource : Microsoft.Insights/TestNotification
ContextType               : Microsoft.Insights/ServiceHealth
CreatedTime               : 2023-11-08T05:16:00.7951739+00:00
State                     : Complete
```

This command sends test notifications to a set of provided receivers.

