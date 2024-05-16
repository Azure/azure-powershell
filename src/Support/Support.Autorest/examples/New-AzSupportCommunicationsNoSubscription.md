### Example 1: Create a new communication under a no subscription ticket
```powershell
New-AzSupportCommunicationsNoSubscription -SupportTicketName test1234 -Name testCommunication2 -Subject test -Body test
```

```output
Body                   : <pre>test</pre>
CommunicationDirection : Inbound
CommunicationType      : Web
CreatedDate            : 3/11/2024 2:21:32 PM
Id                     : /providers/Microsoft.Support/supportTickets/test-7d6ad184-eb1d-40b1-ae43-5b4312b702d4/communications/33445ea3-b
                         2df-ee11-904d-00224835ac0b
Name                   : 33445ea3-b2df-ee11-904d-00224835ac0b
ResourceGroupName      :
Sender                 : bhshah@TestTest06172019GBL.onmicrosoft.com
Subject                : test - TrackingID#2403070040015890
Type                   : Microsoft.Support/communications
```

Create a new communication under a no subscription ticket


