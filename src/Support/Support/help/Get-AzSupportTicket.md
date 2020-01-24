---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Support.dll-Help.xml
Module Name: Az.Support
online version:
schema: 2.0.0
---

# Get-AzSupportTicket

## SYNOPSIS
Get support tickets.

## SYNTAX

### ListParameterSet (Default)
```
Get-AzSupportTicket [-Filter <String>] [-First <UInt32>] [-Skip <UInt32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzSupportTicket -Name <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of support tickets. It will retrieve all the support tickets if you do not specify any parameters. You can also filter the support tickets by Status or CreatedDate using the Filter parameter. Here are some examples of filter values that you can specify.

| Scenario                                                         | Filter                                           |
|------------------------------------------------------------------|--------------------------------------------------|
| Get tickets that are in open state                               | "Status eq 'Open'"                               |
| Get tickets that are in closed state                             | "Status eq 'Closed'"                             |
| Get tickets that were created on or after 20th Dec, 2019         | "CreatedDate ge 2019-12-20"                      |
| Get tickets that were created after 20th Dec, 2019               | "CreatedDate gt 2019-12-20"                      |
| Gets tickets created after 20th Dec, 2019 that are in open state | "CreatedDate gt 2019-12-20 and Status eq 'Open'" |


This cmdlet supports paging via First and Skip parameters.

You can also retrieve a single support ticket by specifying the ticket name. 
 

## EXAMPLES

### Example 1: Get first 2 tickets
```powershell
PS C:\> Get-AzSupportTicket -First 2

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : test title 1
SupportTicketId                  : 117122721000811
Description                      : test description 1
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Closed
CreatedDate                      : 12/27/2019 8:46:14 PM
ModifiedDate                     : 12/27/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test2
Name                             : test2
Type                             : Microsoft.Support/supportTickets
Title                            : test title 2
SupportTicketId                  : 117122721000812
Description                      : test description 2
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Closed
CreatedDate                      : 12/28/2019 8:46:14 PM
ModifiedDate                     : 12/29/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

### Example 2: Get first 2 tickets after skipping the first 2
```powershell
PS C:\> Get-AzSupportTicket -Skip 2 -First 2

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test3
Name                             : test3
Type                             : Microsoft.Support/supportTickets
Title                            : test title 3
SupportTicketId                  : 117122721000811
Description                      : test description 3
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Closed
CreatedDate                      : 12/27/2019 8:46:14 PM
ModifiedDate                     : 12/27/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test4
Name                             : test4
Type                             : Microsoft.Support/supportTickets
Title                            : test title 4
SupportTicketId                  : 117122721000812
Description                      : test description 4
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Closed
CreatedDate                      : 12/28/2019 8:46:14 PM
ModifiedDate                     : 12/29/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

### Example 3: Get a support ticket by name
```powershell
PS C:\> Get-AzSupportTicket -Name test1

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : test title
SupportTicketId                  : 117122721000811
Description                      : test description
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Closed
CreatedDate                      : 12/27/2019 8:46:14 PM
ModifiedDate                     : 12/27/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

### Example 3: Get first 2 support tickets filtered by status
```powershell
PS C:\> Get-AzSupportTicket -Filter "Status eq 'Closed'" -First 2

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : test title
SupportTicketId                  : 117122721000811
Description                      : test description
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Closed
CreatedDate                      : 12/27/2019 8:46:14 PM
ModifiedDate                     : 12/27/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test2
Name                             : test2
Type                             : Microsoft.Support/supportTickets
Title                            : test title 2
SupportTicketId                  : 117122721000812
Description                      : test description 2
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Closed
CreatedDate                      : 12/27/2019 8:46:14 PM
ModifiedDate                     : 12/27/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

### Example 3: Get all support tickets that are in Open state and created after Dec 20th, 2019
```powershell
PS C:\> Get-AzSupportTicket -Filter "Status eq 'Open' and CreatedDate gt 2019-12-20"

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : test title
SupportTicketId                  : 117122721000811
Description                      : test description
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Open
CreatedDate                      : 12/27/2019 8:46:14 PM
ModifiedDate                     : 12/27/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test2
Name                             : test2
Type                             : Microsoft.Support/supportTickets
Title                            : test title 2
SupportTicketId                  : 117122721000812
Description                      : test description 2
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Open
CreatedDate                      : 12/27/2019 8:46:14 PM
ModifiedDate                     : 12/27/2019 10:21:38 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

## PARAMETERS

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

### -Filter
Filter to be applied to the results of this cmdlet.

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of SupportTicket resource that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the first N results and then gets the remaining results.

```yaml
Type: System.UInt32
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Maximum number of results that will be returned by this cmdlet.

```yaml
Type: System.UInt32
Parameter Sets: ListParameterSet
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportTicket

## NOTES

## RELATED LINKS
