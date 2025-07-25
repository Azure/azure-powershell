### Example 1: Test the availability of an unused vault name
```powershell
Test-AzKeyVaultNameAvailability -Name test-kv0818
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

This commands tests the availability of vault name `test-kv0818`. The results shows `test-kv0818` is not occupied.

### Example 2: Test the availability of an used vault name
```powershell
Test-AzKeyVaultNameAvailability -Name testkv
```

```output
Message
-------                                                                                                                                                                      
The vault name 'testkv' is already in use. Vault names are globally unique so it is possible that the name is already taken. If you are sure that the vault name was not … 
```

This commands tests the availability of vault name `testkv`. The results shows `testkv` is already in use.
