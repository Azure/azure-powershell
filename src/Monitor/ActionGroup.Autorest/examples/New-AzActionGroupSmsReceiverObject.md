### Example 1: create action group sms receiver
```powershell
New-AzActionGroupSmsReceiverObject -CountryCode 86 -Name user1 -PhoneNumber '01234567890'
```

```output
CountryCode Name  PhoneNumber Status
----------- ----  ----------- ------
86          user1 01234567890
```

This command creates action group sms receiver object.
