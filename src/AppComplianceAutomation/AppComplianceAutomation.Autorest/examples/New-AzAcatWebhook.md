### Example 1: Create a webhook under a report with default values.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhook -Name "test-webhook" -ReportName "test-report" -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 8:28:56 AM test@hotmail.com    User                    7/27/2023 8:28:56 AM     test@hotmail.…
```

Create a webhook under a report with default values.

### Example 2: Create a webhook under a report.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhook -Name "test-webhook" -ReportName "test-report" -EnableSslVerification "true"  -Disable -TriggerMode "all" -PayloadUrl "https://example.com" -ContentType "application/json" -Secret $secret
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 8:28:56 AM test@hotmail.com    User                    7/27/2023 8:28:56 AM     test@hotmail.…
```

Create a webhook under a report.

### Example 3: Create a webhook under a report use parameter object.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
$param = New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
$param | New-AzAcatWebhook -Name "test-webhook" -ReportName "test-report"
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 8:28:56 AM test@hotmail.com    User                    7/27/2023 8:28:56 AM     test@hotmail.…
```

Create a webhook under a report use parameter object.
