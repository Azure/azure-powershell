#### Get-AzAcatControlAssessments

#### SYNOPSIS
Get the AppComplianceAutomation report's control assessments.

#### SYNTAX

```powershell
Get-AzAcatControlAssessments -ReportName <String> [-ComplianceStatus <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get control assessments of a report
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

+ Example 2: Get failed control assessments of a report
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


#### Invoke-AzAcatDownloadReport

#### SYNOPSIS
Download compliance needs, like: Compliance Report, Resource List.

#### SYNTAX

```powershell
Invoke-AzAcatDownloadReport -DownloadType <String> -Name <String> -Path <String> -ReportName <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Download resource list (csv) of a report.
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

+ Example 2: Download compliance assessments (csv) of a report.
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

+ Example 3: Download compliance report (pdf) of a report.
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

+ Example 4: Download detailed compliance report (pdf) of a report.
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


#### Start-AzAcatQuickEvaluation

#### SYNOPSIS
Trigger evaluation for given resourceIds to get quick compliance result.

#### SYNTAX

```powershell
Start-AzAcatQuickEvaluation -Resources <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get resources' quick compliance results.
```powershell
Start-AzAcatQuickEvaluation -Resources @("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm")
```

```output
EvaluationEndTime QuickAssessment ResourceId
----------------- --------------- ----------
                  {}              {/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers…
```

Get resources' quick compliance results.


#### New-AzAcatReport

#### SYNOPSIS
Create a new AppComplianceAutomation report or update an exiting AppComplianceAutomation report.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzAcatReport -Name <String> -Resource <IResourceMetadata[]> [-OfferGuid <String>] [-TimeZone <String>]
 [-TriggerTime <DateTime>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ Create
```powershell
New-AzAcatReport -Name <String> -Parameter <IReportResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a report with default values.
```powershell
New-AzAcatReport -Name "test-report" -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"})
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Create a report with default values.

+ Example 2: Create a report.
```powershell
New-AzAcatReport -Name "test-report" -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"}) -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z" -OfferGuid "00000000-0000-0000-0000-000000000001"
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Create a report.

+ Example 3: Create a report use parameter object.
```powershell
$param = New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"})
$param | New-AzAcatReport -Name "test-report"
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Create a report use parameter object.


#### Get-AzAcatReport

#### SYNOPSIS
Get the AppComplianceAutomation report and its properties.

#### SYNTAX

+ List (Default)
```powershell
Get-AzAcatReport [-Select <String>] [-SkipToken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzAcatReport -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List reports under current tenant.
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

+ Example 2: List top 2 report under current tenant.
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

+ Example 3: Get report by report name.
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

+ Example 4: Select specific property of reports.
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


#### Remove-AzAcatReport

#### SYNOPSIS
Delete an AppComplianceAutomation report.

#### SYNTAX

```powershell
Remove-AzAcatReport -Name <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Delete a report.
```powershell
Remove-AzAcatReport -Name "test-report"
```

Delete a report.


#### Update-AzAcatReport

#### SYNOPSIS
Update an exiting AppComplianceAutomation report.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzAcatReport -Name <String> [-OfferGuid <String>] [-Resource <IResourceMetadata[]>]
 [-TimeZone <String>] [-TriggerTime <DateTime>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ Update
```powershell
Update-AzAcatReport -Name <String> -Parameter <IReportResource> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update certain fields of a report.
```powershell
Update-AzAcatReport -Name "test-report" -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z"
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Update certain fields of a report.

+ Example 2: Update all fields of a report.
```powershell
Update-AzAcatReport -Name "test-report" -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"}) -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z" -OfferGuid "00000000-0000-0000-0000-000000000001"
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Update all fields of a report.

+ Example 3: Update a report use parameter object.
```powershell
$param = New-AzAcatReportResourceObject -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z"
$param | Update-AzAcatReport -Name "test-report"
```

```output
Name            SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                          tModifiedBy
----            -------------------  ------------------- ----------------------- ------------------------ -------------
test-report     7/19/2023 8:56:20 AM                     User                    7/19/2023 8:56:20 AM
```

Update a report use parameter object.


#### New-AzAcatReportResourceObject

#### SYNOPSIS
Create an in-memory object for ReportResource.

#### SYNTAX

```powershell
New-AzAcatReportResourceObject [-OfferGuid <String>] [-Resource <IResourceMetadata[]>] [-TimeZone <String>]
 [-TriggerTime <DateTime>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a ReportResource object with default values.
```powershell
New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"})
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a ReportResource object with default values.

+ Example 2: Create a ReportResource object.
```powershell
New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"}) -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z" -OfferGuid "00000000-0000-0000-0000-000000000001"
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a ReportResource object.


#### New-AzAcatWebhook

#### SYNOPSIS
Create a new AppComplianceAutomation webhook or update an exiting AppComplianceAutomation webhook.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzAcatWebhook -Name <String> -PayloadUrl <String> -ReportName <String> -TriggerMode <String>
 [-ContentType <String>] [-Disable] [-EnableSslVerification <String>] [-Event <String[]>]
 [-Secret <SecureString>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ Create
```powershell
New-AzAcatWebhook -Name <String> -Parameter <IWebhookResource> -ReportName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a webhook under a report with default values.
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

+ Example 2: Create a webhook under a report.
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

+ Example 3: Create a webhook under a report use parameter object.
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


#### Get-AzAcatWebhook

#### SYNOPSIS
Get the AppComplianceAutomation webhook and its properties.

#### SYNTAX

+ List (Default)
```powershell
Get-AzAcatWebhook -ReportName <String> [-Select <String>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzAcatWebhook -Name <String> -ReportName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List webhooks under a report.
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

+ Example 2: List top 2 webhooks under a report.
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

+ Example 3: Get webhook under a report by webhook name.
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

+ Example 4: Select specific property of webhooks.
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


#### Remove-AzAcatWebhook

#### SYNOPSIS
Delete an AppComplianceAutomation webhook.

#### SYNTAX

```powershell
Remove-AzAcatWebhook -Name <String> -ReportName <String> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Delete a webhook under a report.
```powershell
Remove-AzAcatWebhook -Name "test-webhook" -ReportName "test-report"
```

Delete a webhook under a report.


#### Update-AzAcatWebhook

#### SYNOPSIS
Update an exiting AppComplianceAutomation webhook.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzAcatWebhook -Name <String> -ReportName <String> [-ContentType <String>] [-Disable]
 [-EnableSslVerification <String>] [-Event <String[]>] [-PayloadUrl <String>] [-Secret <SecureString>]
 [-TriggerMode <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ Update
```powershell
Update-AzAcatWebhook -Name <String> -Parameter <IWebhookResource> -ReportName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update certain fields of a webhook under a report.
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

+ Example 2: Update all fields of a webhook under a report.
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

+ Example 3: Update a webhook under a report use parameter object.
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


#### New-AzAcatWebhookResourceObject

#### SYNOPSIS
Create an in-memory object for WebhookResource.

#### SYNTAX

```powershell
New-AzAcatWebhookResourceObject [-ContentType <String>] [-Disable] [-EnableSslVerification <String>]
 [-Event <String[]>] [-PayloadUrl <String>] [-Secret <SecureString>] [-TriggerMode <String>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a WebhookResource object with default values.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a WebhookResource object with default values.

+ Example 2: Create a WebhookResource object.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhookResourceObject -EnableSslVerification "true"  -Disable -TriggerMode "all" -PayloadUrl "https://example.com" -ContentType "application/json" -Secret $secret
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a WebhookResource object.


