---
external help file:
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/get-azacatreport
schema: 2.0.0
---

# Get-AzAcatReport

## SYNOPSIS
Get the AppComplianceAutomation report and its properties.

## SYNTAX

### List (Default)
```
Get-AzAcatReport [-Select <String>] [-SkipToken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzAcatReport -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the AppComplianceAutomation report and its properties.

## EXAMPLES

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

## PARAMETERS

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

### -Name
Report Name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ReportName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Select
OData Select statement.
Limits the properties on each entry to just those requested, e.g.
?$select=reportName,id.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skip over when retrieving results.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Number of elements to return when retrieving results.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource

## NOTES

ALIASES

## RELATED LINKS

