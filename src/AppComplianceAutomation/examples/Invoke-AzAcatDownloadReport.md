### Example 1: Download resource list (csv) of a report.
```powershell
Invoke-AzAcatDownloadReport -Name "test-report" -DownloadType ResourceList -Path "C:\Documents" -FileName "test-report-resourceList"
```

```output
    Directory: C:\Documents

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---           7/19/2023  3:18 PM            155 test-report-resourceList.csv
```

Download resource list (csv) of a report.

### Example 2: Download compliance assessments (csv) of a report.
```powershell
Invoke-AzAcatDownloadReport -Name "test-report" -DownloadType ComplianceReport -Path "C:\Documents" -FileName "test-report-assessments"
```

```output
    Directory: C:\Documents

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---           7/19/2023  3:18 PM         336104 test-report-assessments.csv
```

Download compliance assessments (csv) of a report.

### Example 3: Download compliance report (pdf) of a report.
```powershell
Invoke-AzAcatDownloadReport -Name "test-report" -DownloadType CompliancePdfReport -Path "C:\Documents" -FileName "test-report-complianceReport"
```

```output
    Directory: C:\Documents

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---           7/19/2023  3:19 PM         308946 test-report-complianceReport.pdf
```

Download compliance report (pdf) of a report.

### Example 4: Download detailed compliance report (pdf) of a report.
```powershell
Invoke-AzAcatDownloadReport -Name "test-report" -DownloadType ComplianceDetailedPdfReport -Path "C:\Documents" -FileName "test-report-detailedComplianceReport"
```

```output
    Directory: C:\Documents

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---           7/19/2023  3:19 PM         308946 test-report-detailedComplianceReport.pdf
```

Download detailed compliance report (pdf) of a report.
