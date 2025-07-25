### Example 1: Create a daily retention lifecycle
```powershell
New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
```

```output
DeleteAfterDuration        : P30D
DeleteAfterObjectType      : AbsoluteDeleteOption
SourceDataStoreObjectType  : DataStoreInfoBase
SourceDataStoreType        : OperationalStore
TargetDataStoreCopySetting :
```

This command creates a lifecycle object which stores the backup data in operational store for 30 days.

### Example 2: Create a weekly retention lifecycle.
```powershell
New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 20
```

```output
DeleteAfterDuration        : P20W
DeleteAfterObjectType      : AbsoluteDeleteOption
SourceDataStoreObjectType  : DataStoreInfoBase
SourceDataStoreType        : OperationalStore
TargetDataStoreCopySetting :
```

This command creates a lifecycle object which stores the backup data in operational store for 20 weeks.

