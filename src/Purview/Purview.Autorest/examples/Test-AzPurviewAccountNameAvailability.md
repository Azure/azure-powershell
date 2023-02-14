### Example 1: Check if account name is available
```powershell
Test-AzPurviewAccountNameAvailability -Name test-pa -Type Tenant
```

```output
Message                                                 NameAvailable Reason
-------                                                 ------------- ------
<<<<<<< HEAD
The name test-pa is invalid, please use another name.   False         Invalid
=======
The name test-pa is invalid, please use another name. False         Invalid
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Check if account name 'test-pa' is available.

