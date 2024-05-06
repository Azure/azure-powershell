---
external help file: Az.Support-help.xml
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/update-azsupportticket
schema: 2.0.0
---

# Update-AzSupportTicket

## SYNOPSIS
This API allows you to update the severity level, ticket status, advanced diagnostic consent and your contact information in the support ticket.\<br/\>\<br/\>Note: The severity levels cannot be changed if a support ticket is actively being worked upon by an Azure support engineer.
In such a case, contact your support engineer to request severity update by adding a new communication using the Communications API.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSupportTicket -Name <String> [-SubscriptionId <String>] [-AdvancedDiagnosticConsent <String>]
 [-ContactDetailAdditionalEmailAddress <String[]>] [-ContactDetailCountry <String>]
 [-ContactDetailFirstName <String>] [-ContactDetailLastName <String>] [-ContactDetailPhoneNumber <String>]
 [-ContactDetailPreferredContactMethod <String>] [-ContactDetailPreferredSupportLanguage <String>]
 [-ContactDetailPreferredTimeZone <String>] [-ContactDetailPrimaryEmailAddress <String>]
 [-SecondaryConsent <ISecondaryConsent[]>] [-Severity <String>] [-Status <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSupportTicket -InputObject <ISupportIdentity> [-AdvancedDiagnosticConsent <String>]
 [-ContactDetailAdditionalEmailAddress <String[]>] [-ContactDetailCountry <String>]
 [-ContactDetailFirstName <String>] [-ContactDetailLastName <String>] [-ContactDetailPhoneNumber <String>]
 [-ContactDetailPreferredContactMethod <String>] [-ContactDetailPreferredSupportLanguage <String>]
 [-ContactDetailPreferredTimeZone <String>] [-ContactDetailPrimaryEmailAddress <String>]
 [-SecondaryConsent <ISecondaryConsent[]>] [-Severity <String>] [-Status <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This API allows you to update the severity level, ticket status, advanced diagnostic consent and your contact information in the support ticket.\<br/\>\<br/\>Note: The severity levels cannot be changed if a support ticket is actively being worked upon by an Azure support engineer.
In such a case, contact your support engineer to request severity update by adding a new communication using the Communications API.

## EXAMPLES

### Example 1: - Updates the support ticket at subscription level
```powershell
Update-AzSupportTicket -Name "test12345678" -Status "Closed"
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
CreatedDate                                : 2/22/2024 6:48:38 AM
Description                                : test ticket - please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 2402220010002574
Id                                         : /subscriptions/76cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft.Su
                                             pport/supportTickets/test12345678
ModifiedDate                               : 2/22/2024 7:00:10 AM
Name                                       : test12345678
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
ServiceLevelAgreementExpirationTime        : 2/22/2024 10:00:00 PM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 2/22/2024 6:48:38 AM
Severity                                   : Minimal
Status                                     : Closed
SupportEngineerEmailAddress                :
SupportPlanDisplayName                     : Azure Support Plan - Internal
SupportPlanId                              : U291cmNlOkVBLFN1YnNjcmlwdGlvbklkOjc2Q0I3N0ZBLThCMTctNEVBQi05NDkzLUI2NURBQ0
                                             U5OTgxMyxPZmZlcklkOk1TLUFaUi0wMDE1UCxTb3ZlcmVpZ25DbG91ZDpQdWJsaWMs
SupportPlanType                            : Azure Internal
SupportTicketId                            : 2402220010002574
TechnicalTicketDetailResourceId            :
Title                                      : test ticket - please ignore and close
Type                                       : Microsoft.Support/supportTickets
```

This API allows you to update the severity level, ticket status, advanced diagnostic consent and your contact information in the support ticket.

## PARAMETERS

### -AdvancedDiagnosticConsent
Advanced diagnostic consent to be updated on the support ticket.

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

### -ContactDetailAdditionalEmailAddress
Email addresses listed will be copied on any correspondence about the support ticket.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailCountry
Country of the user.
This is the ISO 3166-1 alpha-3 code.

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

### -ContactDetailFirstName
First name.

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

### -ContactDetailLastName
Last name.

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

### -ContactDetailPhoneNumber
Phone number.
This is required if preferred contact method is phone.

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

### -ContactDetailPreferredContactMethod
Preferred contact method.

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

### -ContactDetailPreferredSupportLanguage
Preferred language of support from Azure.
Support languages vary based on the severity you choose for your support ticket.
Learn more at [Azure Severity and responsiveness](https://azure.microsoft.com/support/plans/response/).
Use the standard language-country code.
Valid values are 'en-us' for English, 'zh-hans' for Chinese, 'es-es' for Spanish, 'fr-fr' for French, 'ja-jp' for Japanese, 'ko-kr' for Korean, 'ru-ru' for Russian, 'pt-br' for Portuguese, 'it-it' for Italian, 'zh-tw' for Chinese and 'de-de' for German.

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

### -ContactDetailPreferredTimeZone
Time zone of the user.
This is the name of the time zone from [Microsoft Time Zone Index Values](https://support.microsoft.com/help/973627/microsoft-time-zone-index-values).

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

### -ContactDetailPrimaryEmailAddress
Primary email address.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Support ticket name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: SupportTicketName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryConsent
This property indicates secondary consents for the support ticket

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISecondaryConsent[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
Severity level.

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

### -Status
Status to be updated on the ticket.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportTicketDetails

## NOTES

## RELATED LINKS
