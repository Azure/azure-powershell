### Example 1: Get all the key-values in an App Configuration store
```powershell
Get-AzAppConfigurationKeyValue -Endpoint $endpoint
```

```output
ContentType Etag                                        Key      Label LastModified       Locked SyncToken Value
----------- ----                                        ---      ----- ------------       ------ --------- -----
            7VYSVQjjNgQ987zh8bjsXeDqgdAUkspRblp6Ceh-Zb0 keyName1 label 7/21/2023 02:22:45 False            value1
            EAy26mDBHMBrUohZn-uJhNTTxoeKiMRin9h1OpfGpZc keyName2 label 7/21/2023 02:22:50 False            value2
            6tRurLbnyEBDKT7ynXV4F3mZpfA2hf_5z58cK2LDsHY keyName3 label 7/21/2023 02:22:55 False            value3
```

Get all the key-values in an App Configuration store

### Example 2: List by key-values with wildcard
```powershell
Get-AzAppConfigurationKeyValue -Endpoint $endpoint -Key "key*"
```

```output
ContentType Etag                                        Key      Label LastModified       Locked SyncToken Value
----------- ----                                        ---      ----- ------------       ------ --------- -----
            7VYSVQjjNgQ987zh8bjsXeDqgdAUkspRblp6Ceh-Zb0 keyName1 label 7/21/2023 02:22:45 False            value1
            EAy26mDBHMBrUohZn-uJhNTTxoeKiMRin9h1OpfGpZc keyName2 label 7/21/2023 02:22:50 False            value2
            6tRurLbnyEBDKT7ynXV4F3mZpfA2hf_5z58cK2LDsHY keyName3 label 7/21/2023 02:22:55 False            value3
```

You can use wildcard to list key-values in an App Configuration store

### Example 3: Get a key-value in an App Configuration store
```powershell
Get-AzAppConfigurationKeyValue -Endpoint $endpoint -Key "keyName1"
```

```output
ContentType Etag                                        Key      Label LastModified       Locked SyncToken Value
----------- ----                                        ---      ----- ------------       ------ --------- -----
            7VYSVQjjNgQ987zh8bjsXeDqgdAUkspRblp6Ceh-Zb0 keyName1 label 7/21/2023 02:22:45 False            value1
```

You can get a key-value in an App Configuration store with the key name.
