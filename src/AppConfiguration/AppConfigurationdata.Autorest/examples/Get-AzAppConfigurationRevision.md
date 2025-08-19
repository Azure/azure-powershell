### Example 1: List the revision of all the key-values in an App Configuration store
```powershell
Get-AzAppConfigurationRevision -Endpoint $endpoint
```

```output
ContentType Etag                                        Key      Label LastModified       Locked SyncToken Value
----------- ----                                        ---      ----- ------------       ------ --------- -----
            VYZXW_mkOPtFCaCR1Yo1UPXrU-4eBSj2zSzIdnOfCiU keyName2 label 7/21/2023 02:37:01 False            value2
            8btgGKjTObZloa_EsIB-WHozAI4-laTWdc-nr2IGAQ0 keyName4 label 7/21/2023 02:36:18 False            value4
            6tRurLbnyEBDKT7ynXV4F3mZpfA2hf_5z58cK2LDsHY keyName3       7/21/2023 02:22:55 False            value3
            EAy26mDBHMBrUohZn-uJhNTTxoeKiMRin9h1OpfGpZc keyName2       7/21/2023 02:22:50 False            value2
            7VYSVQjjNgQ987zh8bjsXeDqgdAUkspRblp6Ceh-Zb0 keyName1       7/21/2023 02:22:45 False            value1
```

List the revision of all the key-values in an App Configuration store

### Example 2: List the revision of a key-value in an App Configuration store
```powershell
Get-AzAppConfigurationRevision -Endpoint $endpoint -Key keyName2
```

```output
ContentType Etag                                        Key      Label LastModified       Locked SyncToken Value
----------- ----                                        ---      ----- ------------       ------ --------- -----
            VYZXW_mkOPtFCaCR1Yo1UPXrU-4eBSj2zSzIdnOfCiU keyName2 label 7/21/2023 02:37:01 False            value2
            EAy26mDBHMBrUohZn-uJhNTTxoeKiMRin9h1OpfGpZc keyName2       7/21/2023 02:22:50 False            value2
```

List the revision of a key-value in an App Configuration store

