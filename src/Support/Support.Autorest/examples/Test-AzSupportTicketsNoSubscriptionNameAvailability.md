### Example 1: Check support ticket friendly name availability
```powershell
Test-AzSupportTicketsNoSubscriptionNameAvailability -Name "testSupportTicketName" -Type "Microsoft.Support/supportTickets"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

Check the availability of a resource name. This API should be used to check the uniqueness of the name for support ticket creation for the selected subscription.
If the provided type is neither Microsoft.Support/supportTickets nor Microsoft.Support/fileWorkspaces, then it will default to Microsoft.Support/supportTickets.

### Example 2: Check file workspace friendly name availability
```powershell
Test-AzSupportTicketsNoSubscriptionNameAvailability -Name "testFileWorkspaceName" -Type "Microsoft.Support/fileWorkspaces"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

Check the availability of a resource name. This API should be used to check the uniqueness of the name for file workspace creation for the selected subscription.
If the provided type is neither Microsoft.Support/supportTickets nor Microsoft.Support/fileWorkspaces, then it will default to Microsoft.Support/supportTickets.
