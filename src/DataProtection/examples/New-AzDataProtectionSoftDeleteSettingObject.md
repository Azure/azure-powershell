### Example 1: Create a new vault soft delete setting object
```powershell
New-AzDataProtectionSoftDeleteSettingObject -RetentionDurationInDay 100 -State On
```

```output
RetentionDurationInDay State
---------------------- -----
100                    On
```

This command creates a new vault soft delete setting object which is used to create a backup vault.
