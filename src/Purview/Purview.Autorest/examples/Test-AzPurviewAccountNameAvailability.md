### Example 1: Check if account name is available
```powershell
Test-AzPurviewAccountNameAvailability -Name test-pa -Type Tenant
```

```output
Message                                                 NameAvailable Reason
-------                                                 ------------- ------
The name test-pa is invalid, please use another name.   False         Invalid
```

Check if account name 'test-pa' is available.

