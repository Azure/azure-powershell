### Example 1: Check if account name is available
```powershell
PS C:\> Test-AzPurviewAccountNameAvailability -Name test-pa -Type Tenant

Message                                                 NameAvailable Reason
-------                                                 ------------- ------
The name test-pa is invalid, please use another name. False         Invalid
```

Check if account name 'test-pa' is available.

