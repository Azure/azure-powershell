### Example 1: Test The Availability Of An Used Trusted Signing Account Name
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

### Example 2: Test The Availability Of An Unused Trusted Signing Account Name
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
