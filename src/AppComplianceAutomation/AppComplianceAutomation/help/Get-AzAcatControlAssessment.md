---
external help file: Az.AppComplianceAutomation-help.xml
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/get-azacatcontrolassessment
schema: 2.0.0
---

# Get-AzAcatControlAssessment

## SYNOPSIS
Get the AppComplianceAutomation report's control assessments.

## SYNTAX

```
Get-AzAcatControlAssessment -ReportName <String> [-ComplianceStatus <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get the AppComplianceAutomation report's control assessments.

## EXAMPLES

### Example 1: Get control assessment of a report
```powershell
$assessments = Get-AzAcatControlAssessment -ReportName "test-report"
$assessments.ControlFamily
```

```output
Name                    Status
----                    ------
Operational Security    Failed
Data Security & Privacy Failed

Name                                          Status
----                                          ------
Malware Protection - Anti-Virus               Failed
Malware Protection - Application Control      NotApplicable
Patch Management - Risk Ranking               NotApplicable
Patch Management - Patching                   NotApplicable
Vulnerability Scanning                        NotApplicable
Firewall - Firewalls                          Failed
Firewall - WAFs (OPTIONAL)                    Failed
Change Control                                NotApplicable
Secure Software Development/Deployment        NotApplicable
Account Management                            Failed
Intrusion Detection and Prevention (OPTIONAL) Failed
Security Event Logging                        Failed
Reviewing (Logging Data)                      NotApplicable
Security Event Alerting                       Failed
Information Security Risk Management          NotApplicable
Incident Response                             NotApplicable
Data in Transit                               Failed
Data At Rest                                  Passed
Data Retention and Disposal                   NotApplicable
Data Access Management                        NotApplicable
GDPR                                          NotApplicable
```

Get control assessments of a report

### Example 2: Get failed control assessment of a report
```powershell
$assessments = Get-AzAcatControlAssessment -ReportName "test-report" -ComplianceStatus "Failed"
$assessments.ControlFamily
```

```output
Name                    Status
----                    ------
Operational Security    Failed
Data Security & Privacy Failed

Name                                          Status
----                                          ------
Malware Protection - Anti-Virus               Failed
Firewall - Firewalls                          Failed
Firewall - WAFs (OPTIONAL)                    Failed
Account Management                            Failed
Intrusion Detection and Prevention (OPTIONAL) Failed
Security Event Logging                        Failed
Security Event Alerting                       Failed
Data in Transit                               Failed
```

Get failed control assessments of a report

## PARAMETERS

### -ComplianceStatus
Compliance Status.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.ICategory[]

## NOTES

## RELATED LINKS
