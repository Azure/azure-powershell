---
external help file:
Module Name: Az.Support
online version: https://docs.microsoft.com/en-us/powershell/module/az.support/new-azsupportticket
schema: 2.0.0
---

# New-AzSupportTicket

## SYNOPSIS
Creates a new support ticket for Subscription and Service limits (Quota), Technical, Billing, and Subscription Management issues for the specified subscription.
Learn the [prerequisites](https://aka.ms/supportAPI) required to create a support ticket.\<br/\>\<br/\>Always call the Services and ProblemClassifications API to get the most recent set of services and problem categories required for support ticket creation.\<br/\>\<br/\>Adding attachments is not currently supported via the API.
To add a file to an existing support ticket, visit the [Manage support ticket](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/managesupportrequest) page in the Azure portal, select the support ticket, and use the file upload control to add a new file.\<br/\>\<br/\>Providing consent to share diagnostic information with Azure support is currently not supported via the API.
The Azure support engineer working on your ticket will reach out to you for consent if your issue requires gathering diagnostic information from your Azure resources.\<br/\>\<br/\>**Creating a support ticket for on-behalf-of**: Include _x-ms-authorization-auxiliary_ header to provide an auxiliary token as per [documentation](https://docs.microsoft.com/azure/azure-resource-manager/management/authenticate-multi-tenant).
The primary token will be from the tenant for whom a support ticket is being raised against the subscription, i.e.
Cloud solution provider (CSP) customer tenant.
The auxiliary token will be from the Cloud solution provider (CSP) partner tenant.

## SYNTAX

```
New-AzSupportTicket -Name <String> [-SubscriptionId <String>]
 [-ContactDetailAdditionalEmailAddress <String[]>] [-ContactDetailCountry <String>]
 [-ContactDetailFirstName <String>] [-ContactDetailLastName <String>] [-ContactDetailPhoneNumber <String>]
 [-ContactDetailPreferredContactMethod <PreferredContactMethod>]
 [-ContactDetailPreferredSupportLanguage <String>] [-ContactDetailPreferredTimeZone <String>]
 [-ContactDetailPrimaryEmailAddress <String>] [-Description <String>] [-ProblemClassificationId <String>]
 [-ProblemStartTime <DateTime>] [-QuotaTicketDetailQuotaChangeRequest <IQuotaChangeRequest[]>]
 [-QuotaTicketDetailQuotaChangeRequestSubType <String>] [-QuotaTicketDetailQuotaChangeRequestVersion <String>]
 [-Require24X7Response] [-ServiceId <String>] [-Severity <SeverityLevel>] [-SupportTicketId <String>]
 [-TechnicalTicketDetailResourceId <String>] [-Title <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new support ticket for Subscription and Service limits (Quota), Technical, Billing, and Subscription Management issues for the specified subscription.
Learn the [prerequisites](https://aka.ms/supportAPI) required to create a support ticket.\<br/\>\<br/\>Always call the Services and ProblemClassifications API to get the most recent set of services and problem categories required for support ticket creation.\<br/\>\<br/\>Adding attachments is not currently supported via the API.
To add a file to an existing support ticket, visit the [Manage support ticket](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/managesupportrequest) page in the Azure portal, select the support ticket, and use the file upload control to add a new file.\<br/\>\<br/\>Providing consent to share diagnostic information with Azure support is currently not supported via the API.
The Azure support engineer working on your ticket will reach out to you for consent if your issue requires gathering diagnostic information from your Azure resources.\<br/\>\<br/\>**Creating a support ticket for on-behalf-of**: Include _x-ms-authorization-auxiliary_ header to provide an auxiliary token as per [documentation](https://docs.microsoft.com/azure/azure-resource-manager/management/authenticate-multi-tenant).
The primary token will be from the tenant for whom a support ticket is being raised against the subscription, i.e.
Cloud solution provider (CSP) customer tenant.
The auxiliary token will be from the Cloud solution provider (CSP) partner tenant.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -ContactDetailAdditionalEmailAddress
Additional email addresses listed will be copied on any correspondence about the support ticket.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Support.PreferredContactMethod
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
Learn more at [Azure Severity and responsiveness](https://azure.microsoft.com/support/plans/response).
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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Description
Detailed description of the question or issue.

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

### -Name
Support ticket name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SupportTicketName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ProblemClassificationId
Each Azure service has its own set of issue categories, also known as problem classification.
This parameter is the unique Id for the type of problem you are experiencing.

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

### -ProblemStartTime
Time in UTC (ISO 8601 format) when the problem started.

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

### -QuotaTicketDetailQuotaChangeRequest
This property is required for providing the region and new quota limits.
To construct, see NOTES section for QUOTATICKETDETAILQUOTACHANGEREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.Api20200401.IQuotaChangeRequest[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuotaTicketDetailQuotaChangeRequestSubType
Required for certain quota types when there is a sub type, such as Batch, for which you are requesting a quota increase.

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

### -QuotaTicketDetailQuotaChangeRequestVersion
Quota change request version.

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

### -Require24X7Response
Indicates if this requires a 24x7 response from Azure.

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

### -ServiceId
This is the resource Id of the Azure service resource associated with the support ticket.

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

### -Severity
A value that indicates the urgency of the case, which in turn determines the response time according to the service level agreement of the technical support plan you have with Azure.
Note: 'Highest critical impact', also known as the 'Emergency - Severe impact' level in the Azure portal is reserved only for our Premium customers.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Support.SeverityLevel
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportTicketId
System generated support ticket Id that is unique.

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

### -TechnicalTicketDetailResourceId
This is the resource Id of the Azure service resource (For example: A virtual machine resource or an HDInsight resource) for which the support ticket is created.

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

### -Title
Title of the support ticket.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.Api20200401.ISupportTicketDetails

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


QUOTATICKETDETAILQUOTACHANGEREQUEST <IQuotaChangeRequest[]>: This property is required for providing the region and new quota limits.
  - `[Payload <String>]`: Payload of the quota increase request.
  - `[Region <String>]`: Region for which the quota increase request is being made.

## RELATED LINKS

