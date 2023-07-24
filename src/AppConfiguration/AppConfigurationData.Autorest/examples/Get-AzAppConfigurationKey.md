### Example 1: List all the keys in an App Configuration store
```powershell
Get-AzAppConfigurationKey -Endpoint $endpoint
```

```output
Name
----
keyName1
keyName2
keyName3
```

List all the keys in an App Configuration store

### Example 2: Get key list in an App Configuration store with wildcard
```powershell
Get-AzAppConfigurationKey -Endpoint $endpoint -Name key*
```

```output
Name
----
keyName1
keyName2
keyName3
```

Get key list in an App Configuration store with wildcard

