### Example 1: Test a key-value in an App Configuration store
```powershell
Test-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName1
```

Test a key-value in an App Configuration store

### Example 2: Test a key-value in an App Configuration store with wildcard
```powershell
Test-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName*
```

Test a key-value in an App Configuration store with wildcard

### Example 3: Test a key-value in an App Configuration store
```powershell
Test-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName5
```

```output
Test-AzAppConfigurationKeyValue_Check: The server responded with a Request Error, Status: NotFound
```

If the key-value does not exist, the cmdlet will throw an error.