### Example 1: Test the availability of an used trusted signing account name
```powershell
Test-AzTrustedSigningAccountNameAvailability -Name unavaliable
```

```output
Message                      NameAvailable Reason
-------                      ------------- ------
Resource name already exists         False AlreadyExists
```

This commands tests the availability of trusted signing account name `unavaliable`.
The results shows `unavaliable` is occupied.

### Example 2: Test the availability of an unused trusted signing account name
```powershell
Test-AzTrustedSigningAccountNameAvailability -Name available
```

```output
NameAvailable
-------------
         True
```

This commands tests the availability of trusted signing account name `available`.
The results shows `available` is not occupied.
