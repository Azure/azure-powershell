### Example 1: Test the availability of an unused HSM name
```powershell
Test-AzKeyVaultManagedHsmNameAvailability -Name testmhsm0818
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

This commands tests the availability of vault name `testmhsm0818`. The results shows `testmhsm0818` is not occupied.

### Example 2: Test the availability of an used HSM name
```powershell
Test-AzKeyVaultNameAvailability -Name testmhsm
```

```output
Message                               NameAvailable Reason
-------                               ------------- ------
The name 'testmhsm' is already in use.         False AlreadyExists
```

This commands tests the availability of HSM name `testmhsm`. The results shows `testmhsm` is already in use.
