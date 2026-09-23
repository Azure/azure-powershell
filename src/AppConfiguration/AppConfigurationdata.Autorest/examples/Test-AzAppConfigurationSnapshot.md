### Example 1: Check if snapshots exist in an App Configuration store
```powershell
Test-AzAppConfigurationSnapshot -Endpoint $endpoint -PassThru
```

```output
True
```

Check whether any snapshots exist in the App Configuration store. Returns True if snapshots are found.

### Example 2: Check if a specific snapshot exists
```powershell
Test-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -PassThru
```

```output
True
```

Check whether a specific snapshot exists in the App Configuration store by name.

