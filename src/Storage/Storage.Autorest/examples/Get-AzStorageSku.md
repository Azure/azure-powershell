### Example 1: List  SKUs under a subscription
```powershell
Get-AzStorageSku -SubscriptionId $mysubid
```

```output
Capability   : {{
                 "name": "supportsAccountHnsOnMigration",
                 "value": "true"
               }, {
                 "name": "supportsaccountvlw",
                 "value": "true"
               }, {
                 "name": "supportsadlsgen2snapshot",
                 "value": "true"
               }, {
                 "name": "supportsadlsgen2staticwebsite",
                 "value": "true"
               }…}
Kind         : StorageV2
Location     : {westus2}
LocationInfo : {{
                 "location": "westus2",
                 "zones": [ ]
               }}
Name         : Standard_ZRS
ResourceType : storageAccounts
Restriction  : {}
Tier         : Standard
```

This command lists all SKUs under a specified subscription. 


