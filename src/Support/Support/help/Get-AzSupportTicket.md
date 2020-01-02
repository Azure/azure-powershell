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
Get-AzSupportTicket [-Filter <String>] [-Top <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzSupportTicket -Name <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSupportTicket -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NextLinkParameterSet
```
Get-AzSupportTicket [-NextLink <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get support tickets. You can filter the results by *Status*, and *CreatedDate* using *Filter* parameter. Output will be a paged result with *NextLink* if there are more results available. This can be used to retrieve the next page of results.


## EXAMPLES

### Example 1: Get support ticket list
```powershell
PS C:\> Get-AzSupportTicket | fl

SupportTickets : {test1, test2, test3, test4...}
NextLink       : https://management.azure.com:443/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets?api-version=2019-05-01-preview&$skipToken=xxxx
```

### Example 2: Get a support ticket by name
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

### Example 3: Get support ticket list filtered by Status
```powershell
PS C:\> $a = Get-AzSupportTicket -Filter "Status eq 'Closed'"
PS C:\> $a.SupportTickets

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : test title 1
SupportTicketId                  : 117123121000744
Description                      : test description 1
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassificaiton_guid}
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
CreatedDate                      : 12/31/2019 11:13:04 PM
ModifiedDate                     : 1/1/2020 12:04:18 AM
TechnicalTicketDetails           :
QuotaTicketDetails               :

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test2
Name                             : test2
Type                             : Microsoft.Support/supportTickets
Title                            : test title 2
SupportTicketId                  : 117123021000824
Description                      : test description 2
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : New subscription provisioning
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{servivce_guid}
ServiceDisplayName               : Subscription management
Status                           : Closed
CreatedDate                      : 12/30/2019 7:30:37 PM
ModifiedDate                     : 12/30/2019 7:53:20 PM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

You can also filter results by *CreatedDate*. If you want all tickets created on or after 2019-12-30T17:00:00Z, specify *Filter* as  "CreatedDate ge 2019-12-30T17:00:00Z". 


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

### -NextLink
The link for the next page of SupportTicket resources to be obtained.
This value is obtained with the first Get-AzSupportTicket cmdlet call when more resources are still available to be queried.

```yaml
Type: System.String
Parameter Sets: NextLinkParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Arm ResourceId of SupportTicket resource that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Max number of results that will be returned by this cmdlet.

```yaml
Type: System.Nullable`1[System.Int32]
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportTicket

### Microsoft.Azure.Commands.Support.Models.PSSupportTicketPage

## NOTES

## RELATED LINKS
