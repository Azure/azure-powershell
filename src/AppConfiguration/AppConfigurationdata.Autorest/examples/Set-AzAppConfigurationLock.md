### Example 1: Lock a key-value in an App Configuration store
```powershell
Set-AzAppConfigurationLock -Endpoint $endpoint -Key keyName1
```

```output
ContentType  :
Etag         : jXrYtz3qx3qEP0icqPfFWmD24a6qvOnR5LO08NseiR0
Key          : keyName1
Label        :
LastModified : 7/21/2023 02:49:20
Locked       : True
SyncToken    : xxxxxx
Tag          : {
               }
Value        : value1
```

Lock a key-value in an App Configuration store. This key-value will be locked and can not be modified.

