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
 -Severity <String> [-Require24X7Response <Boolean>] -ContactDetails <PSContactProfile>
 [-ProblemStartTime <DateTime>] -ServiceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateTechnicalSupportTicketParameterSet
```
New-AzSupportTicket -Name <String> -Title <String> -Description <String> -ProblemClassificationId <String>
 -Severity <String> [-Require24X7Response <Boolean>] -ContactDetails <PSContactProfile>
 [-ProblemStartTime <DateTime>] -ServiceId <String> [-TechnicalTicketDetails <PSTechnicalTicketDetails>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateQuotaTicketParameterSet
```
New-AzSupportTicket -Name <String> -Title <String> -Description <String> -ProblemClassificationId <String>
 -Severity <String> [-Require24X7Response <Boolean>] -ContactDetails <PSContactProfile>
 [-ProblemStartTime <DateTime>] -ServiceId <String> [-QuotaTicketDetails <PSQuotaTicketDetails>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet can be used to create a support ticket for billing, subscription management, quota or technical issues. Use Get-AzSupportService and Get-AzSupportProblemClassification cmdlets to identify the service and problem classification or issue type for which you want to request support. You must specify the following parameters.

*   Title
*   Description
*   Severity
*   ServiceId
*   ProblemClassificationId
*   ContactDetails 

For technical tickets, you can optionally specify additional details as *TechnicalTicketDetails* and specify the Arm resource id of technical resource that you are requesting support for.

For quota tickets, you can optionally specify additional details as *QuotaTicketDetails* to request automated quota increase for certain quota types. QuotaTicketDetails object consists of 3 properties as described below.

* QuotaChangeRequestSubType <String>

    This is required for certain quota types when there is a sub type that you are requesting quota increase for.

* QuotaChangeRequestVersion <String>

    This is mandatory and indicates the version of the quota change request payload.

* QuotaChangeRequests <List>

    This is mandatory and is a list of PSQuotaChangeRequest objects. PSQuotaChangeRequest object has 2 mandatory properties.

    * Region <String>

        This is the Azure location or region for which you are requesting quota increase. This is the *Location* property of *Get-AzLocation* cmdlet.

    * Payload <String>

        This is quota type specific request payload where you specify the new limits.

Quota types for which you can specify QuotaTicketDetails are as follows.

* Cores

    You do not need to specify QuotaChangeRequestSubType for Cores. Remaining payload properties are as shown in the table below.

    | QuotaChangeRequestVersion | Payload                                         |
    |---------------------------|-------------------------------------------------|
    | 1.0                       | {\"VmFamily\":\"ESv3 Series\",\"NewLimit\":200} |

* Batch
    
     * Payload for requesting increase for Batch *Account*.

        | QuotaChangeRequestVersion | QuotaChangeRequestSubType | Payload                                                                                        |
        |---------------------------|---------------------------|------------------------------------------------------------------------------------------------|
        | 1.0                       | Account                   | {\"AccountName\":\"test\",\"NewLimit\":200,\"Type\":\"LowPriority\"}                           |
        | 1.0                       | Account                   | {\"AccountName\":\"test\",\"VMFamily\":\"Av2 Series\",\"NewLimit\":205,\"Type\":\"Dedicated\"} |
        | 1.0                       | Account                   | {\"AccountName\":\"test\",\"NewLimit\":120,\"Type\":\"Pools\"}                                 |
        | 1.0                       | Account                   | {\"AccountName\":\"test\",\"NewLimit\":150,\"Type\":\"Jobs\"}                                  |


    * Payload for requesting increase for Batch *Subscription*.

        | QuotaChangeRequestVersion | QuotaChangeRequestSubType | Payload                             |
        |---------------------------|---------------------------|-------------------------------------|
        | 1.0                       | Subscription              | {\"NewLimit\":200,\"Type\":Account} |

* SQL Database
    
    * Payload for increasing *DTUs* for SQL Database.

        | QuotaChangeRequestVersion | QuotaChangeRequestSubType | Payload                                           |
        |---------------------------|---------------------------|---------------------------------------------------|
        | 1.0                       | DTUs                      | {\"NewLimit\":54005,\"ServerName\":\"testsever\"} |

    * Payload for increasing *Servers* for SQL Database.

        | QuotaChangeRequestVersion | QuotaChangeRequestSubType | Payload            |
        |---------------------------|---------------------------|--------------------|
        | 1.0                       | Servers                   | {\"NewLimit\":200} |

* SQL Data Warehouse
    
    * Payload for increasing *DTUs* for SQL Data Warehouse.

        | QuotaChangeRequestVersion | QuotaChangeRequestSubType | Payload                                            |
        |---------------------------|---------------------------|----------------------------------------------------|
        | 1.0                       | DTUs                      | {\"NewLimit\":54005,\"ServerName\":\"testsever\"}  |

    * Payload for increasing *Servers* for SQL Data Warehouse.

        | QuotaChangeRequestVersion | QuotaChangeRequestSubType | Payload            |
        |---------------------------|---------------------------|--------------------|
        | 1.0                       | Servers                   | {\"NewLimit\":200} |

## EXAMPLES

### Example 1: Create a support ticket
```powershell
PS C:\> $contactDetails = new-object Microsoft.Azure.Commands.Support.Models.PSContactProfile
PS C:\> $contactDetails.FirstName = "first"
PS C:\> $contactDetails.LastName = "last"
PS C:\> $contactDetails.PreferredContactMethod = "email"
PS C:\> $contactDetails.PrimaryEmailAddress = "user@contoso.com"
PS C:\> $contactDetails.Country = "USA"
PS C:\> $contactDetails.PreferredSupportLanguage = "en-us"
PS C:\> $contactDetails.PreferredTimeZone = "Pacific Standard Time"
PS C:\> New-AzSupportTicket -Name test1 -Title Test -Description Test -Severity minimal -ServiceId /providers/Microsoft.Support/services/{service_guid} -ProblemClassificationId /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid} -ContactDetails $contactDetails

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1
Name                             : test1
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Refund request
Severity                         : Minimal
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              :
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               : Billing
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 3:09:31 AM
TechnicalTicketDetails           :
QuotaTicketDetails               :
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

### -ContactDetails
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
Type: System.Nullable`1[System.DateTime]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuotaTicketDetails
Additional details for a Quota SupportTicket resource.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetails
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
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceId
Arm resource id of Service for which this SupportTicket resource is created.

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

### -Severity
Severity of the SupportTicket resource.

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

### -TechnicalTicketDetails
Additional details for a Technical SupportTicket resource.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSTechnicalTicketDetails
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
