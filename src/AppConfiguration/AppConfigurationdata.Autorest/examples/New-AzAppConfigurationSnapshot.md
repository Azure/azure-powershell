### Example 1: Create a snapshot with a key filter
```powershell
$filter = @{ Key = "app/*" }
New-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -Filter $filter
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Create a key-value snapshot that captures all key-values matching the key filter "app/*".

### Example 2: Create a snapshot with a retention period and composition type
```powershell
$filter = @{ Key = "app/*"; Label = "prod" }
New-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "prodSnapshot" -Filter $filter -CompositionType "key_label" -RetentionPeriod 7776000
```

```output
Name         Status CompositionType Created               Expires                RetentionPeriod Size ItemsCount Etag
----         ------ --------------- -------               -------                --------------- ---- ---------- ----
prodSnapshot ready  key_label       7/21/2023 02:40:00    10/19/2023 02:40:00    7776000         2048 10         ghijkl
```

Create a snapshot with key_label composition type and a 90-day retention period, filtering by both key and label.

