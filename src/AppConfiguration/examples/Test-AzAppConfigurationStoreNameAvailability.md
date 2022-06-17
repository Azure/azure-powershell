### Example 1: Test availability of the app configuration store name
```powershell
Test-AzAppConfigurationStoreNameAvailability -Name appconfig-test01
```
```output
Message                               NameAvailable Reason
-------                               ------------- ------
The specified name is already in use. False         AlreadyExists
```

This command tests availability of the app configuration store name.