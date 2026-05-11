### Example 1: List all snapshots in an App Configuration store
```powershell
Get-AzAppConfigurationSnapshot -Endpoint $endpoint
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

List all key-value snapshots in an App Configuration store.

### Example 2: Get a specific snapshot by name
```powershell
Get-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot"
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Get a single key-value snapshot by name from an App Configuration store.

