### Example 1: Unlock a key-value in an App Configuration store
```powershell
Remove-AzAppConfigurationLock -Endpoint $endpoint -Key keyName1
```

```output
ContentType  :
Etag         : jXrYtz3qx3qEP0icqPfFWmD24a6qvOnR5LO08NseiR0
Key          : keyName1
Label        :
LastModified : 7/21/2023 02:49:20
Locked       : False
SyncToken    : xxxxxx
Tag          : {
               }
Value        : value1
```

Unlock a key-value in an App Configuration store. This key-value can be modified.


