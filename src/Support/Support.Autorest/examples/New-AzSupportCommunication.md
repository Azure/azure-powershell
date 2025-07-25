### Example 1: Adds communication to a support ticket at subscription level
```powershell
 New-AzSupportCommunication -Name "test123" -SupportTicketName "test12345678" -Body "this is a test message from PS" -Subject "test subject" -Sender "test@test.com"
```

```output
Body                   : <pre>this is a test message from PS</pre>
CommunicationDirection : Inbound
CommunicationType      : Web
CreatedDate            : 2/22/2024 6:54:29 AM
Id                     : /subscriptions/76cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft.Support/supportTickets
                         45678/communications/test123
Name                   : test123
ResourceGroupName      :
Sender                 : test@test.com
Subject                : test subject - TrackingID#2402220010002574
Type                   : Microsoft.Support/communications
```

Adds a new customer communication to an Azure support ticket