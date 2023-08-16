### Example 1: List available Storage SKUs for a subscription 
```powershell
Get-AzStorageSku
```

```output
Kind             Name            Tier     Location             ResourceType
----             ----            ----     --------             ------------
BlockBlobStorage Premium_LRS     Premium  {australiacentral}   storageAccounts
BlockBlobStorage Premium_LRS     Premium  {australiaeast}      storageAccounts
BlockBlobStorage Premium_LRS     Premium  {australiasoutheast} storageAccounts
BlockBlobStorage Premium_LRS     Premium  {brazilsouth}        storageAccounts
BlockBlobStorage Premium_LRS     Premium  {brazilsoutheast}    storageAccounts
BlockBlobStorage Premium_LRS     Premium  {canadacentral}      storageAccounts
BlockBlobStorage Premium_LRS     Premium  {canadaeast}         storageAccounts
BlockBlobStorage Premium_LRS     Premium  {centralindia}       storageAccounts
BlockBlobStorage Premium_LRS     Premium  {centralus}          storageAccounts
```

This command lists all the available Storage SKUs for a subscription.
