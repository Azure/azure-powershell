---
external help file: Az.Support-help.xml
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportticketsnosubscription
schema: 2.0.0
---

# Get-AzSupportTicketsNoSubscription

## SYNOPSIS
Gets details for a specific support ticket.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.
If no parameters are specified, then this command will retrieve all tickets created in the last week by default.

## SYNTAX

### List (Default)
```
Get-AzSupportTicketsNoSubscription [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSupportTicketsNoSubscription -SupportTicketName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportTicketsNoSubscription -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets details for a specific support ticket.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.
If no parameters are specified, then this command will retrieve all tickets created in the last week by default.

## EXAMPLES

### Example 1: Gets list of support tickets at tenant level
```powershell
Get-AzSupportTicketsNoSubscription
```

```output
Name                                      Title                                 SupportTicketId  Severity ServiceDisplayName CreatedDate
----                                      -----                                 ---------------  -------- ------------------ -----------
2403110040009092                          test ticket please ignore and close   2403110040009092 Minimal  Billing            3/11/2024 3:46:20 PM
test-41b4ec72-8634-4e03-978e-15bde625be00 test ticket - please ignore and close 2403070040010395 Minimal  Billing            3/7/2024 5:35:55 PM
test-270a8ba4-7083-4b02-8b32-b5c2cdc55e78 test ticket - please ignore and close 2403070040010346 Minimal  Billing            3/7/2024 5:32:40 PM
test-8dad4b97-5ff5-4a1e-bb6e-d323348db3f2 test ticket - please ignore and close 2403070040009816 Minimal  Billing            3/7/2024 5:04:36 PM
test-0d8ee1f2-89d6-4078-8c1a-5845673966a1 test ticket - please ignore and close 2403070040009769 Minimal  Billing            3/7/2024 5:02:44 PM
```

Lists all the support tickets.
If no parameters are specified, then this command will retrieve all tickets created in the last week by default.

### Example 2: Get support ticket at tenant level
```powershell
Get-AzSupportTicketsNoSubscription -SupportTicketName "test1-5dda17d0-a60d-4f4c-82e3-0fe3604c0ed4"
```

```output
AdvancedDiagnosticConsent                  : No
ContactDetailAdditionalEmailAddress        :
ContactDetailCountry                       : USA
ContactDetailFirstName                     : test
ContactDetailLastName                      : test
ContactDetailPhoneNumber                   :
ContactDetailPreferredContactMethod        : Email
ContactDetailPreferredSupportLanguage      : en-US
ContactDetailPreferredTimeZone             : Pacific Standard Time
ContactDetailPrimaryEmailAddress           : test@test.com
CreatedDate                                : 2/22/2024 12:56:11 AM
Description                                : test ticket - please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 2402220010000453
Id                                         : /providers/Microsoft.Support/supportTickets/test1-5dda17d0-a60d-4f4c-82e3-
                                             0fe3604c0ed4
ModifiedDate                               : 2/22/2024 5:49:09 AM
Name                                       : test1-5dda17d0-a60d-4f4c-82e3-0fe3604c0ed4
ProblemClassificationDisplayName           : Add or update VAT, tax id, PO number or profile information
ProblemClassificationId                    : /providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc
                                             /problemClassifications/3ec1a070-f242-9ecf-5a7c-e1a88ce029ef
ProblemScopingQuestion                     :
ProblemStartTime                           :
QuotaTicketDetailQuotaChangeRequest        :
QuotaTicketDetailQuotaChangeRequestSubType :
QuotaTicketDetailQuotaChangeRequestVersion :
Require24X7Response                        : False
ResourceGroupName                          :
SecondaryConsent                           :
ServiceDisplayName                         : Billing
ServiceId                                  : /providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc
ServiceLevelAgreementExpirationTime        : 2/22/2024 8:57:00 PM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 2/22/2024 12:56:11 AM
Severity                                   : Minimal
Status                                     : Updating
SupportEngineerEmailAddress                :test@test.com
SupportPlanDisplayName                     : Basic support
SupportPlanId                              : U291cmNlOkZyZWUsRnJlZUlkOjAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwOS
                                             w=
SupportPlanType                            : Basic
SupportTicketId                            : 2402220010000453
TechnicalTicketDetailResourceId            :
Title                                      : test ticket - please ignore and close
Type                                       : Microsoft.Support/supportTickets
```

Gets details of a support ticket

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Filter
The filter to apply on the operation.
We support 'odata v4.0' filter semantics.
\<a target='_blank' href='https://docs.microsoft.com/odata/concepts/queryoptions-overview'\>Learn more\</a\> \<br/\>\<i\>Status\</i\> , \<i\>ServiceId\</i\>, and \<i\>ProblemClassificationId\</i\> filters can only be used with 'eq' operator.
For \<i\>CreatedDate\</i\> filter, the supported operators are 'gt' and 'ge'.
When using both filters, combine them using the logical 'AND'.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SupportTicketName
Support ticket name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of values to return in the collection.
Default is 25 and max is 100.

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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportTicketDetails

## NOTES

## RELATED LINKS
