### Example 1: Archive a snapshot
```powershell
Update-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -Status "archived"
```

```output
Name       Status   CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------   --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot archived key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Archive a snapshot by updating its status to "archived".

### Example 2: Recover an archived snapshot
```powershell
Update-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -Status "ready"
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Recover an archived snapshot by updating its status back to "ready".

