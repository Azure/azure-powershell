### Example 1: List all communications under a no subscription support ticket 
```powershell
Get-AzSupportCommunicationsNoSubscription -SupportTicketName test1234
```

```output
Name               Sender            Subject                                              CreatedDate
----               ------            -------                                              -----------
testCommunication1 sender@sender.com this is a test subject - TrackingID#2403070040015890 3/11/2024 3:46:43 PM
testCommunication2 sender@sender.com this is a test subject - TrackingID#2403070040015890 3/11/2024 3:46:43 PM
```

List all communications under a no subscription support ticket

### Example 2: Get a communication under a no subscription support ticket
```powershell
Get-AzSupportCommunicationsNoSubscription -SupportTicketName test1234 -Name testCommunication1

```

```output
Body                   : <pre>this is a test body</pre>
CommunicationDirection : Inbound
CommunicationType      : Web
CreatedDate            : 3/7/2024 11:53:33 PM
Id                     : /providers/Microsoft.Support/supportTickets/test1234/communications/testCommunication1
Name                   : testCommunication
ResourceGroupName      :
Sender                 : sender@sender.com
Subject                : this is a test subject - TrackingID#2403070040015890
Type                   : Microsoft.Support/communications
```

Get a communication under a no subscription support ticket

