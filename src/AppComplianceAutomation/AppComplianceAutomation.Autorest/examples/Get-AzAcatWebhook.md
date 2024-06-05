### Example 1: List webhooks under a report.
```powershell
Get-AzAcatWebhook -ReportName "test-report"
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook2 7/19/2023 6:32:51 AM                     User                    7/19/2023 6:32:51 AM
test-webhook  3/1/2023 5:17:12 AM                      User                    7/18/2023 6:23:55 PM     FunctionApp
```

List webhooks under a report.

### Example 2: List top 2 webhooks under a report.
```powershell
Get-AzAcatReport -SkipToken 0 -Top 2
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook2 7/19/2023 6:32:51 AM                     User                    7/19/2023 6:32:51 AM
test-webhook  3/1/2023 5:17:12 AM                      User                    7/18/2023 6:23:55 PM     FunctionApp
```

List top 2 webhooks under a report.

### Example 3: Get webhook under a report by webhook name.
```powershell
Get-AzAcatWebhook -ReportName "test-report" -Name "test-webhook"
```

```output
Name         SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastMod
                                                                                                      ifiedBy
----         ------------------- ------------------- ----------------------- ------------------------ -----------------
test-webhook 3/1/2023 5:17:12 AM                     User                    7/18/2023 6:23:55 PM     FunctionApp
```

Get webhook under a report by webhook name.

### Example 4: Select specific property of webhooks.
```powershell
Get-AzAcatWebhook -ReportName "test-report" -Select "name"
```

```output
Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastMo
                                                                                                       difiedBy
----          ------------------- ------------------- ----------------------- ------------------------ ----------------
test-webhook2
test-webhook
```

Select specific property of webhooks.
