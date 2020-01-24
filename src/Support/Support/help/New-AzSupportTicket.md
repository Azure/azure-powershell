---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Support.dll-Help.xml
Module Name: Az.Support
online version:
schema: 2.0.0
---

# New-AzSupportTicket

## SYNOPSIS
Creates a support ticket.

## SYNTAX

### CreateSupportTicketParameterSet (Default)
```
New-AzSupportTicket -Name <String> -Title <String> -Description <String> -ProblemClassificationId <String>
 -Severity <Severity> -ContactDetail <PSContactProfile> [-ProblemStartTime <DateTime>]
 [-CSPHomeTenantId <String>] [-Require24X7Response] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateTechnicalSupportTicketParameterSet
```
New-AzSupportTicket -Name <String> -Title <String> -Description <String> -ProblemClassificationId <String>
 -Severity <Severity> -ContactDetail <PSContactProfile> [-ProblemStartTime <DateTime>]
 [-TechnicalTicketDetail <PSTechnicalTicketDetail>] [-CSPHomeTenantId <String>] [-Require24X7Response] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateQuotaTicketParameterSet
```
New-AzSupportTicket -Name <String> -Title <String> -Description <String> -ProblemClassificationId <String>
 -Severity <Severity> -ContactDetail <PSContactProfile> [-ProblemStartTime <DateTime>]
 [-QuotaTicketDetail <PSQuotaTicketDetail>] [-CSPHomeTenantId <String>] [-Require24X7Response] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet can be used to create a support ticket for Billing, Subscription Management, Quota or Technical issues. Use Get-AzSupportService and Get-AzSupportProblemClassification cmdlets to identify the Azure service and it's corresponding problem classifications respectively for which you want to request support. You must specify the following parameters: 

	• Title
	• Description
	• Severity level
	• ProblemClassificationId
	• ContactDetail

You can use New-AzSupportContactProfileObject helper cmdlet to create ContactDetail object.

Cloud Solution Providers can create a support ticket for their customer's subscriptions by logging into their customer's tenant and specifying their home tenant id using *CSPHomeTenantId* parameter.

__For technical tickets:__

To specify the resource name provide the ARM resource ID of the resource under *TechnicalTicketDetail* object. See an example below. 

__For quota tickets:__

To request for quota increase for **Compute VM Cores**, **Batch**, **SQL Database** and **SQL Data Warehouse**, provide additional details under *QuotaTicketDetail* object. QuotaTicketDetail object consists of 3 properties as described below. For detailed documentation, please [click here.](https://aka.ms/supportrpquotarequestpayload)

	• QuotaChangeRequestSubType

        This is required for certain quota types when there is a sub type that you are requesting quota increase for. Example: Batch, SQL Database and SQL Data Warehouse have a sub type.

	• QuotaChangeRequestVersion

        This is required and indicates the version of the quota change request payload.

	• QuotaChangeRequests

        This is required and is a list of PSQuotaChangeRequest objects. PSQuotaChangeRequest object has 2 required properties.

	    ○ Region

            This is the Azure location or region for which you are requesting quota increase. This is the Location property of Get-AzLocation cmdlet.
		
        ○ Payload

            This is where you specify the new limits for the selected quota type.


For detailed documentation on how to construct Payload for various quota types, please [click here](https://aka.ms/supportrpquotarequestpayload)

## EXAMPLES

### Example 1: All examples require creating a PSContactProfile object first. This example shows how to create that object using a helper cmdlet which will be used in all subsequent examples. 
```powershell
PS C:\> $contactDetail = New-AzSupportContactProfileObject -FirstName "first name" -LastName "last name" -PrimaryEmailAddress "user@contoso.com" -PreferredContactMethod "email" -Country "USA" -PreferredSupportLanguage "en-US" -PreferredTimeZone "Pacific Standard Time"
```

### Example 2: Create a Billing or Subscription Management support ticket. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Billing or Subscription Management problem classification for which you want to request support 
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{billing_service_guid}/problemClassifications/{problemClassification_guid} -ContactDetail $contactDetail

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{billing_service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{billing_service_guid}
ServiceDisplayName               : Billing
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

### Example 3: Create a technical support ticket for Virtual Machine for Windows resource. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Virtual Machine for Windows problem classification for which you want to request support 
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{vm_windows_service_guid}/problemClassifications/{problemClassification_guid} -ContactDetail $contactDetail -TechnicalTicketDetail @{ResourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM"}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{vm_windows_service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : VM restarted or stopped unexpectedly / Help diagnose my VM restart issue
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{vm_windows_service_guid}
ServiceDisplayName               : Virtual Machine running Windows
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           : Microsoft.Azure.Commands.Support.Models.PSTechnicalTicketDetail
QuotaTicketDetails               : 
```

### Example 4: Create a quota support ticket to increase quota for Virtual Machine Cores for a specific VM family. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Compute VM Cores problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{cores_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"VMFamily`":`"Dv2 Series`",`"NewLimit`":350}"}, @{Region = "eastus"; Payload = "{`"VMFamily`":`"Dv2 Series`",`"NewLimit`":516}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{cores_problemClassification_guid}
ProblemClassificationDisplayName : Compute-VM (cores-vCPUs) subscription limit increases
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 5: Create a quota support ticket to increase quota for Low-priority cores for a Batch account. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Batch problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "Account" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"AccountName`":`"test`",`"NewLimit`":200,`"Type`":`"LowPriority`"}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid}
ProblemClassificationDisplayName : Batch
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 6: Create a quota support ticket to increase VM cores quota for a specific VM Family for a Batch account. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Batch problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "Account" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"AccountName`":`"test`",`"VMFamily`":`"standardA0_A7Family`",`"NewLimit`":200,`"Type`":`"Dedicated`"}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid}
ProblemClassificationDisplayName : Batch
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 7: Create a quota support ticket to increase Pools quota for a Batch account. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Batch problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "Account" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"AccountName`":`"test`",`"NewLimit`":120,`"Type`":`"Pools`"}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid}
ProblemClassificationDisplayName : Batch
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 8: Create a quota support ticket to increase active Jobs and job schedules quota for a Batch account. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Batch problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "Account" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"AccountName`":`"test`",`"NewLimit`":120,`"Type`":`"Jobs`"}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid}
ProblemClassificationDisplayName : Batch
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 9: Create a quota support ticket to increase number of Batch accounts for a subscription. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Batch problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "Subscription" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"NewLimit`":120,`"Type`":`"Account`"}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{batch_problemClassification_guid}
ProblemClassificationDisplayName : Batch
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 10: Create a quota support ticket to increase quota for DTUs for SQL Database. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota SQL Database problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_database_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "DTUs" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"ServerName`":`"testserver`",`"NewLimit`":54000}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_database_problemClassification_guid}
ProblemClassificationDisplayName : SQL database
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 11: Create a quota support ticket to increase quota for Servers for SQL Database. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota SQL Database problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_database_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "Servers" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"NewLimit`":200}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_database_problemClassification_guid}
ProblemClassificationDisplayName : SQL database
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 12: Create a quota support ticket to increase quota for DTUs for SQL Data Warehouse. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota SQL Date Warehouse problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_datawarehouse_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "DTUs" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"ServerName`":`"testserver`",`"NewLimit`":54000}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_datawarehouse_problemClassification_guid}
ProblemClassificationDisplayName : SQL Data Warehouse
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 13: Create a quota support ticket to increase quota for Servers for SQL Data Warehouse. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota SQL Data Warehouse problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_datawarehouse_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "Servers" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"NewLimit`":200}"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_datawarehouse_problemClassification_guid}
ProblemClassificationDisplayName : SQL Data Warehouse
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 14: Create a quota support ticket to increase quota for Low-priority cores for Machine Learning service. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Machine Learning service problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_datawarehouse_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "BatchAml" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"NewLimit`":200,`"Type`":`"LowPriority`" }"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{machine_learning_service_problemClassification_guid}
ProblemClassificationDisplayName : Machine Learning service
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

### Example 15: Create a quota support ticket to increase VM cores quota for a specific VM Family for Machine Learning service. Use Get-AzSupportService and Get-AzSupportProblemClassification to retrieve correct GUIDs for Quota Machine Learning service problem classification.
```powershell
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ProblemClassificationId /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{sql_datawarehouse_problemClassification_guid} -ContactDetail $contactDetail -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequestSubType = "BatchAml" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"VMFamily`":`"standardDFamily`",`"NewLimit`":200,`"Type`":`"Dedicated`" }"})}

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{machine_learning_service_problemClassification_guid}
ProblemClassificationDisplayName : Machine Learning service
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{quota_service_guid}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -ContactDetail
Contact details associated with SupportTicket resource.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSContactProfile
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CSPHomeTenantId
This is the home tenant id of the Cloud Solution Provider user trying to create a support ticket for their customer.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description of SupportTicket resource.

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

### -Name
Name of SupportTicket resource that this cmdlet creates.

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

### -ProblemClassificationId
Arm resource id of ProblemClassification for which this SupportTicket resource is created.

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

### -ProblemStartTime
Date and time when the problem started.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuotaTicketDetail
Additional details for a Quota SupportTicket resource.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
Parameter Sets: CreateQuotaTicketParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Require24X7Response
Indicates if 24 x 7 response is requested.

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

### -Severity
Severity of the SupportTicket resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.Severity
Parameter Sets: (All)
Aliases:
Accepted values: Minimal, Moderate, Critical

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TechnicalTicketDetail
Additional details for a Technical SupportTicket resource.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSTechnicalTicketDetail
Parameter Sets: CreateTechnicalSupportTicketParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
Title of SupportTicket resource.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportTicket

## NOTES

## RELATED LINKS
