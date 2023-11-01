### Example 1: create action group email receiver
```powershell
New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user1
```

```output
EmailAddress     Name  Status UseCommonAlertSchema
------------     ----  ------ --------------------
user@example.com user1 
```

This command creates action group email receiver object.
