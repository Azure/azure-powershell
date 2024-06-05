### Example 1: Update certain fields of a webhook under a report.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
Update-AzAcatWebhook -Name "test-webhook" -ReportName "test-report" -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 9:14:20 AM                     User                    7/31/2023 7:50:04 AM
```

Update certain fields of a webhook under a report.

### Example 2: Update all fields of a webhook under a report.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
Update-AzAcatWebhook -Name "test-webhook" -ReportName "test-report" -EnableSslVerification "true"  -Disable -TriggerMode "all" -PayloadUrl "https://example.com" -ContentType "application/json" -Secret $secret
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 9:14:20 AM                     User                    7/31/2023 7:50:04 AM
```

Update all fields of a webhook under a report.

### Example 3: Update a webhook under a report use parameter object.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
$param = New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
$param | Update-AzAcatWebhook -Name "test-webhook" -ReportName "test-report"
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 9:14:20 AM                     User                    7/31/2023 7:50:04 AM
```

Update a webhook under a report use parameter object.
