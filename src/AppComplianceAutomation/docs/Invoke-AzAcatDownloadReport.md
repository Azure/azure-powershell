---
external help file:
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/invoke-azacatdownloadreport
schema: 2.0.0
---

# Invoke-AzAcatDownloadReport

## SYNOPSIS
Download compliance needs, like: Compliance Report, Resource List.

## SYNTAX

```
Invoke-AzAcatDownloadReport -DownloadType <DownloadType> -Name <String> -Path <String> -ReportName <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Download compliance needs, like: Compliance Report, Resource List.

## EXAMPLES

### Example 1: Download resource list (csv) of a report.
```powershell
Invoke-AzAcatDownloadReport -ReportName "test-report" -DownloadType ResourceList -Path "C:\Documents" -Name "test-report-resourceList"
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
Invoke-AzAcatDownloadReport -ReportName "test-report" -DownloadType ComplianceReport -Path "C:\Documents" -Name "test-report-assessments"
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
Invoke-AzAcatDownloadReport -ReportName "test-report" -DownloadType CompliancePdfReport -Path "C:\Documents" -Name "test-report-complianceReport"
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
Invoke-AzAcatDownloadReport -ReportName "test-report" -DownloadType ComplianceDetailedPdfReport -Path "C:\Documents" -Name "test-report-detailedComplianceReport"
```

```output
    Directory: C:\Documents

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---           7/19/2023  3:19 PM         308946 test-report-detailedComplianceReport.pdf
```

Download detailed compliance report (pdf) of a report.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DownloadType
Indicates the download type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.DownloadType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Downloaded file name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
File download destination path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReportName
Report Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

## RELATED LINKS

