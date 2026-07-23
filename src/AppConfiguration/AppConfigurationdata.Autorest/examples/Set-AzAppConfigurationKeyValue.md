### Example 1: Set a key-value in an App Configurations store
```powershell
Set-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName2 -Label label -Value value2
```

```output
ContentType  :
Etag         : VYZXW_mkOPtFCaCR1Yo1UPXrU-4eBSj2zSzIdnOfCiU
Key          : keyName2
Label        : label
LastModified : 7/21/2023 02:37:01
Locked       : False
SyncToken    : xxxxx
Tag          : {
               }
Value        : value2
```

Set a key-value in an App Configurations store. If the key does not exist, it will be created. If the key exists, the value will be updated.

