### Example 1: List reports under current tenant.
```powershell
Get-AzAcatReport
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     2/1/2023 3:24:37 AM                      Application             2/1/2023 3:24:37 AM
test-report2    1/10/2023 6:17:51 AM                     User                    7/12/2023 7:08:15 AM
```

List reports under current tenant.

### Example 2: List top 2 report under current tenant.
```powershell
Get-AzAcatReport -SkipToken 0 -Top 2
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     2/1/2023 3:24:37 AM                      Application             2/1/2023 3:24:37 AM
test-report2    1/10/2023 6:17:51 AM                     User                    7/12/2023 7:08:15 AM
```

List top 2 report under current tenant.

### Example 3: Get report by report name.
```powershell
Get-AzAcatReport -Name "test-report"
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----        ------------------- ------------------- ----------------------- ------------------------ ------------------
test-report 2/1/2023 3:24:37 AM                     Application             2/1/2023 3:24:37 AM
```

Get report by report name.

### Example 4: Select specific property of reports.
```powershell
Get-AzAcatReport -Select "reportName"
```

```output
Name            SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLast
                                                                                                         ModifiedBy
----            ------------------- ------------------- ----------------------- ------------------------ --------------
test-report
qinzhou-report2
qinzhou-test1
```

Select specific property of reports.
