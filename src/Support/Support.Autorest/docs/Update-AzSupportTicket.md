---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/update-azsupportticket
schema: 2.0.0
---

# Update-AzSupportTicket

## SYNOPSIS
This API allows you to update the severity level, ticket status, advanced diagnostic consent and your contact information in the support ticket.\<br/\>\<br/\>Note: The severity levels cannot be changed if a support ticket is actively being worked upon by an Azure support engineer.
In such a case, contact your support engineer to request severity update by adding a new communication using the Communications API.

## SYNTAX

### UpdateExpanded1 (Default)
```
Update-AzSupportTicket -Name <String> [-AdvancedDiagnosticConsent <String>]
 [-ContactDetailAdditionalEmailAddress <String[]>] [-ContactDetailCountry <String>]
 [-ContactDetailFirstName <String>] [-ContactDetailLastName <String>] [-ContactDetailPhoneNumber <String>]
 [-ContactDetailPreferredContactMethod <String>] [-ContactDetailPreferredSupportLanguage <String>]
 [-ContactDetailPreferredTimeZone <String>] [-ContactDetailPrimaryEmailAddress <String>]
 [-SecondaryConsent <ISecondaryConsent[]>] [-Severity <String>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzSupportTicket -Name <String> -SubscriptionId <String> [-AdvancedDiagnosticConsent <String>]
 [-ContactDetailAdditionalEmailAddress <String[]>] [-ContactDetailCountry <String>]
 [-ContactDetailFirstName <String>] [-ContactDetailLastName <String>] [-ContactDetailPhoneNumber <String>]
 [-ContactDetailPreferredContactMethod <String>] [-ContactDetailPreferredSupportLanguage <String>]
 [-ContactDetailPreferredTimeZone <String>] [-ContactDetailPrimaryEmailAddress <String>]
 [-SecondaryConsent <ISecondaryConsent[]>] [-Severity <String>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSupportTicket -InputObject <ISupportIdentity> [-AdvancedDiagnosticConsent <String>]
 [-ContactDetailAdditionalEmailAddress <String[]>] [-ContactDetailCountry <String>]
 [-ContactDetailFirstName <String>] [-ContactDetailLastName <String>] [-ContactDetailPhoneNumber <String>]
 [-ContactDetailPreferredContactMethod <String>] [-ContactDetailPreferredSupportLanguage <String>]
 [-ContactDetailPreferredTimeZone <String>] [-ContactDetailPrimaryEmailAddress <String>]
 [-SecondaryConsent <ISecondaryConsent[]>] [-Severity <String>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzSupportTicket -InputObject <ISupportIdentity> [-AdvancedDiagnosticConsent <String>]
 [-ContactDetailAdditionalEmailAddress <String[]>] [-ContactDetailCountry <String>]
 [-ContactDetailFirstName <String>] [-ContactDetailLastName <String>] [-ContactDetailPhoneNumber <String>]
 [-ContactDetailPreferredContactMethod <String>] [-ContactDetailPreferredSupportLanguage <String>]
 [-ContactDetailPreferredTimeZone <String>] [-ContactDetailPrimaryEmailAddress <String>]
 [-SecondaryConsent <ISecondaryConsent[]>] [-Severity <String>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This API allows you to update the severity level, ticket status, advanced diagnostic consent and your contact information in the support ticket.\<br/\>\<br/\>Note: The severity levels cannot be changed if a support ticket is actively being worked upon by an Azure support engineer.
In such a case, contact your support engineer to request severity update by adding a new communication using the Communications API.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases: SupportTicketName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryConsent
This property indicates secondary consents for the support ticket
To construct, see NOTES section for SECONDARYCONSENT properties and create a hash table.

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
Azure subscription Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportTicketDetails

## NOTES

## RELATED LINKS

