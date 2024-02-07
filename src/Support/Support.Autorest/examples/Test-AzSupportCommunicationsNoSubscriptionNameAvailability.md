### Example 1: Check friendly name availability of a communication for a support ticket
```powershell
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -Name "testCommunication" -SupportTicketName "2402084010005835" -Type "Microsoft.Support/communications"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

Check the availability of a resource name. This API should be used to check the uniqueness of the name for adding a new communication to the support ticket.
