### Example 1: Get a file share snapshot properties
```powershell
Get-AzFileShareSnapshot -ResourceName "testshare" -ResourceGroupName "myresourcegroup" -Name s123
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.FileShares/fileShares/testshare/fileShareSnapshots/s123
InitiatorId                  :
Metadata                     : {
                                 "meta1": "value1"
                               }
Name                         : s123
ResourceGroupName            : myresourcegroup
SnapshotTime                 : 2026-02-26T08:30:05Z
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.FileShares/fileShareSnapshots
```

This command gets a file share snapshot properties.

