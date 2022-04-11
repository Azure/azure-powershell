### Example 1: Test vault name whether is valid and is not already in use
```powershell
Test-AzKeyVaultNameAvailability -Name test-kv20220411
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

This command tests the vault name 'test-kv20220411' whether is valid and is not already in use.