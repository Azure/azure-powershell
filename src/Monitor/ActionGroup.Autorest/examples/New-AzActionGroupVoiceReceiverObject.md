### Example 1: create action group voice receiver
```powershell
New-AzActionGroupVoiceReceiverObject -CountryCode 86 -Name "sample voice" -PhoneNumber 01234567890
```

```output
CountryCode Name         PhoneNumber                                                                                                   
----------- ----         -----------
86          sample voice 01234567890
```

This command creates action group voice receiver object.

