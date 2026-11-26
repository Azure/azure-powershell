### Example 1: Disable the compliance lock on a storage
```powershell
Disable-AzCommvaultStorageComplianceLock -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -StorageName storage-hot
```

Starts the multi-person authorization approval workflow to disable the compliance lock.
The compliance lock status changes to `DisablementPending` until the approval completes.

