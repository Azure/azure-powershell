---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportticketsnosubscription
schema: 2.0.0
---

# Get-AzSupportTicketsNoSubscription

## SYNOPSIS
Gets details for a specific support ticket.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.

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

## EXAMPLES

### Example 1: Gets list of support tickets at tenant level
```powershell
 Get-AzSupportTicketsNoSubscription
```

```output
Name                                       ResourceGroupName
----                                       -----------------
test1-5dda17d0-a60d-4f4c-82e3-0fe3604c0ed4
test-5dda17d0-a60d-4f4c-82e3-0fe3604c0ed4
test1-8fd280ac-966b-41da-b6f5-ad630c784feb
test-8fd280ac-966b-41da-b6f5-ad630c784feb
test1-a31f113b-8f99-4a8d-8016-33aec8165a20
test-a31f113b-8f99-4a8d-8016-33aec8165a20
test1-9fbdfed4-20e5-47ee-b36e-455ca16bb46b
test-9fbdfed4-20e5-47ee-b36e-455ca16bb46b
test-1c0ad9a1-f2fb-44a7-b776-7400e0b286a8
```

Lists all the support tickets.

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

Lists all the support tickets

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
Aliases:

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

