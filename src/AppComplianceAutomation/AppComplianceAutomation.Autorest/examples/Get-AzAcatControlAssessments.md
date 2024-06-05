### Example 1: Get control assessments of a report
```powershell
$assessments = Get-AzAcatControlAssessments -ReportName "test-report"
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

### Example 2: Get failed control assessments of a report
```powershell
$assessments = Get-AzAcatControlAssessments -ReportName "test-report" -ComplianceStatus "Failed"
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
