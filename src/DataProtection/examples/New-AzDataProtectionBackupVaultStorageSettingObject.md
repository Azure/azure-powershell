### Example 1: Create a new vault storage setting object
```powershell
New-AzDataProtectionBackupVaultStorageSettingObject -Type GeoRedundant -DataStoreType VaultStore
```

```output
DatastoreType Type
------------- ----
VaultStore    GeoRedundant
```

This command creates a new vault storage setting object which is used to create a backup vault.
