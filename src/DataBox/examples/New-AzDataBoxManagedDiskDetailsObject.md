### Example 1: {{ ManagedDisk object }}
```powershell
PS C:\> $managedDiskAccount=New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/randommanagedisk1" -StagingStorageAccountId "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/dhja/providers/Microsoft.Storage/storageAccounts/manageddiskstrg" -DataAccountType "ManagedDisk"
```

{{ Creates a in-memory managed disk object }}

