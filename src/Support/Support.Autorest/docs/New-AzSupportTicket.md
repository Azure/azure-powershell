---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/new-azsupportticket
schema: 2.0.0
---

# New-AzSupportTicket

## SYNOPSIS
Create a new support ticket for Subscription and Service limits (Quota), Technical, Billing, and Subscription Management issues for the specified subscription.
Learn the [prerequisites](https://aka.ms/supportAPI) required to create a support ticket.\<br/\>\<br/\>Always call the Services and ProblemClassifications API to get the most recent set of services and problem categories required for support ticket creation.\<br/\>\<br/\>Adding attachments is not currently supported via the API.
To add a file to an existing support ticket, visit the [Manage support ticket](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/managesupportrequest) page in the Azure portal, select the support ticket, and use the file upload control to add a new file.\<br/\>\<br/\>Providing consent to share diagnostic information with Azure support is currently not supported via the API.
The Azure support engineer working on your ticket will reach out to you for consent if your issue requires gathering diagnostic information from your Azure resources.\<br/\>\<br/\>**Creating a support ticket for on-behalf-of**: Include _x-ms-authorization-auxiliary_ header to provide an auxiliary token as per [documentation](https://docs.microsoft.com/azure/azure-resource-manager/management/authenticate-multi-tenant).
The primary token will be from the tenant for whom a support ticket is being raised against the subscription, i.e.
Cloud solution provider (CSP) customer tenant.
The auxiliary token will be from the Cloud solution provider (CSP) partner tenant.

## SYNTAX

```
New-AzSupportTicket -Name <String> -AdvancedDiagnosticConsent <String> -ContactDetailCountry <String>
 -ContactDetailFirstName <String> -ContactDetailLastName <String>
 -ContactDetailPreferredContactMethod <String> -ContactDetailPreferredSupportLanguage <String>
 -ContactDetailPreferredTimeZone <String> -ContactDetailPrimaryEmailAddress <String> -Description <String>
 -ProblemClassificationId <String> -ServiceId <String> -Severity <String> -Title <String>
 [-SubscriptionId <String>] [-ContactDetailAdditionalEmailAddress <String[]>]
 [-ContactDetailPhoneNumber <String>] [-EnrollmentId <String>] [-FileWorkspaceName <String>]
 [-ProblemScopingQuestion <String>] [-ProblemStartTime <DateTime>]
 [-QuotaTicketDetailQuotaChangeRequest <IQuotaChangeRequest[]>]
 [-QuotaTicketDetailQuotaChangeRequestSubType <String>] [-QuotaTicketDetailQuotaChangeRequestVersion <String>]
 [-Require24X7Response] [-SecondaryConsent <ISecondaryConsent[]>] [-SupportPlanId <String>]
 [-SupportTicketId <String>] [-TechnicalTicketDetailResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new support ticket for Subscription and Service limits (Quota), Technical, Billing, and Subscription Management issues for the specified subscription.
Learn the [prerequisites](https://aka.ms/supportAPI) required to create a support ticket.\<br/\>\<br/\>Always call the Services and ProblemClassifications API to get the most recent set of services and problem categories required for support ticket creation.\<br/\>\<br/\>Adding attachments is not currently supported via the API.
To add a file to an existing support ticket, visit the [Manage support ticket](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/managesupportrequest) page in the Azure portal, select the support ticket, and use the file upload control to add a new file.\<br/\>\<br/\>Providing consent to share diagnostic information with Azure support is currently not supported via the API.
The Azure support engineer working on your ticket will reach out to you for consent if your issue requires gathering diagnostic information from your Azure resources.\<br/\>\<br/\>**Creating a support ticket for on-behalf-of**: Include _x-ms-authorization-auxiliary_ header to provide an auxiliary token as per [documentation](https://docs.microsoft.com/azure/azure-resource-manager/management/authenticate-multi-tenant).
The primary token will be from the tenant for whom a support ticket is being raised against the subscription, i.e.
Cloud solution provider (CSP) customer tenant.
The auxiliary token will be from the Cloud solution provider (CSP) partner tenant.

## EXAMPLES

### Example 1: Creates billing or subscription management support ticket at subscription level
```powershell
New-AzSupportTicket -Name "test12345678" -AdvancedDiagnosticConsent "no" -ContactDetailPrimaryEmailAddress "test@test.com" -ContactDetailFirstName "test" -ContactDetailLastName "test" -ContactDetailPreferredContactMethod "email" -ContactDetailPreferredTimeZone "Pacific Standard Time" -ContactDetailPreferredSupportLanguage "en-US" -ContactDetailCountry "usa" -Description "test ticket - please ignore and close" -Severity "minimal" -Title "test ticket - please ignore and close" -ServiceId "/providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc" -ProblemClassificationId "/providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc/problemClassifications/3ec1a070-f242-9ecf-5a7c-e1a88ce029ef"
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
ModifiedDate                               : 2/22/2024 6:48:50 AM
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
Status                                     : Open
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

Creates a new support ticket for Subscription and Service limits (Quota), Technical, Billing, and Subscription Management issues for the specified subscription

### Example 2: Creates quota support ticket at subscription level
```powershell
New-AzSupportTicket -Name "test_ticket_1234" -AdvancedDiagnosticConsent "Yes" -ContactDetailCountry "USA" -ContactDetailFirstName "firstName" -ContactDetailLastName "lastName" -ContactDetailPreferredContactMethod "email" -ContactDetailPreferredSupportLanguage "en-US" -ContactDetailPreferredTimeZone "Pacific Standard Time" -ContactDetailPrimaryEmailAddress "test@test.com" -Description "test ticket please ignore and close" -ProblemClassificationId "/providers/microsoft.support/services/06bfd9d3-516b-d5c6-5802-169c800dec89/problemclassifications/e12e3d1d-7fa0-af33-c6d0-3c50df9658a3" -ServiceId "/providers/microsoft.support/services/06bfd9d3-516b-d5c6-5802-169c800dec89" -Severity "minimal" -Title "test" -QuotaTicketDetailQuotaChangeRequest @(@{ Payload = "{`"VMFamily`":`"BS Series`",`"NewLimit`":`"353`",`"DeploymentStack`":`"ARM`",`"Type`":`"Regional`",`"EdgeZone`":`"`"}"; Region = "EASTUS"}) -QuotaTicketDetailQuotaChangeRequestVersion "1.0"
```

```output
AdvancedDiagnosticConsent                  : Yes
ContactDetailAdditionalEmailAddress        :
ContactDetailCountry                       : USA
ContactDetailFirstName                     : firstName
ContactDetailLastName                      : lastName
ContactDetailPhoneNumber                   :
ContactDetailPreferredContactMethod        : Email
ContactDetailPreferredSupportLanguage      : en-US
ContactDetailPreferredTimeZone             : Pacific Standard Time
ContactDetailPrimaryEmailAddress           : test@test.com
CreatedDate                                : 3/8/2024 9:59:35 PM
Description                                : test ticket please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 2403080050012950
Id                                         : /subscriptions/5aa76f0c-95b9-42c1-8e0b-faba7a4d1374/providers/Microsoft.Support/supportTick
                                             ets/test_ticket_1234
ModifiedDate                               : 3/8/2024 9:59:44 PM
Name                                       : test_grhuang_2024_03_08_1
ProblemClassificationDisplayName           : Compute-VM (cores-vCPUs) subscription limit increases
ProblemClassificationId                    : /providers/Microsoft.Support/services/06bfd9d3-516b-d5c6-5802-169c800dec89/problemClassific
                                             ations/e12e3d1d-7fa0-af33-c6d0-3c50df9658a3
ProblemScopingQuestion                     :
ProblemStartTime                           :
QuotaTicketDetailQuotaChangeRequest        : {{
                                               "region": "EASTUS",
                                               "payload": "{\"VMFamily\":\"BS Series\",\"NewLimit\":\"353\",\"DeploymentStack\":\"ARM\",
                                             \"Type\":\"Regional\",\"EdgeZone\":\"\"}"
                                             }}
QuotaTicketDetailQuotaChangeRequestSubType :
QuotaTicketDetailQuotaChangeRequestVersion : 1.0
Require24X7Response                        : False
ResourceGroupName                          :
SecondaryConsent                           :
ServiceDisplayName                         : Service and subscription limits (quotas)
ServiceId                                  : /providers/Microsoft.Support/services/06bfd9d3-516b-d5c6-5802-169c800dec89
ServiceLevelAgreementExpirationTime        : 3/11/2024 5:00:00 PM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 3/8/2024 9:59:35 PM
Severity                                   : Minimal
Status                                     : Open
SupportEngineerEmailAddress                :
SupportPlanDisplayName                     : Azure Support Plan - Internal
SupportPlanId                              : U291cmNlOkVBLFN1YnWjcmlwdGlvbklkOjVBQTc2RjBDLTk1QjktNPJDMS04RTBCLURCRUE3QTREMTM3NCxPZmZlckl
                                             kOk1TLUFaUi0wMDE1UCxTb3ZlcmVpZ25DbG91ZDpQdWJsaWMs
SupportPlanType                            : Azure Internal
SupportTicketId                            : 2403080050012950
TechnicalTicketDetailResourceId            :
Title                                      : test
Type                                       : Microsoft.Support/supportTickets
```

Creates a new support ticket for Subscription and Service limits (Quota) issues for the specified subscription

### Example 3: Creates technical support ticket at subscription level
```powershell
New-AzSupportTicket -Name "testticket12345" -AdvancedDiagnosticConsent "Yes" -ContactDetailCountry "USA" -ContactDetailFirstName "firstName" -ContactDetailLastName "lastName" -ContactDetailPreferredContactMethod "email" -ContactDetailPreferredSupportLanguage "en-US" -ContactDetailPreferredTimeZone "Pacific Standard Time" -ContactDetailPrimaryEmailAddress "test@test.com" -Description "test ticket" -ProblemClassificationId "/providers/microsoft.support/services/40ef020e-8ae7-8d57-b538-9153c47cee69/problemclassifications/72d14431-fb9e-7a21-0fa8-d3e4ac446e7a" -ServiceId "/providers/microsoft.support/services/40ef020e-8ae7-8d57-b538-9153c47cee69" -Severity "minimal" -Title "test" -TechnicalTicketDetailResourceId "/subscriptions/5aa67f0c-95b9-42c1-8eb0-dbea7a4d1374/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/TESTMV"
```

```output
AdvancedDiagnosticConsent                  : Yes
ContactDetailAdditionalEmailAddress        :
ContactDetailCountry                       : USA
ContactDetailFirstName                     : firstName
ContactDetailLastName                      : lastName
ContactDetailPhoneNumber                   :
ContactDetailPreferredContactMethod        : Email
ContactDetailPreferredSupportLanguage      : en-US
ContactDetailPreferredTimeZone             : Pacific Standard Time
ContactDetailPrimaryEmailAddress           : test@test.com
CreatedDate                                : 3/8/2024 10:28:14 PM
Description                                : test ticket please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 2403080040013218
Id                                         : /subscriptions/5aa67f0c-95b9-42c1-8eb0-dbea7a4d1374/providers/Microsoft.Support/supportTick
                                             ets/testticket12345
ModifiedDate                               : 3/8/2024 10:28:24 PM
Name                                       : testticket12345
ProblemClassificationDisplayName           : Backup and Restore / Automated or Managed backup
ProblemClassificationId                    : /providers/Microsoft.Support/services/40ef020e-8ae7-8d57-b538-9153c47cee69/problemClassific
                                             ations/72d14431-fb9e-7a21-0fa8-d3e4ac446e7a
ProblemScopingQuestion                     :
ProblemStartTime                           :
QuotaTicketDetailQuotaChangeRequest        :
QuotaTicketDetailQuotaChangeRequestSubType :
QuotaTicketDetailQuotaChangeRequestVersion :
Require24X7Response                        : False
ResourceGroupName                          :
SecondaryConsent                           :
ServiceDisplayName                         : SQL Server in VM - Linux
ServiceId                                  : /providers/Microsoft.Support/services/40ef020e-8ae7-8d57-b538-9153c47cee69
ServiceLevelAgreementExpirationTime        : 3/11/2024 5:29:00 PM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 3/8/2024 10:28:14 PM
Severity                                   : Minimal
Status                                     : Open
SupportEngineerEmailAddress                :
SupportPlanDisplayName                     : Azure Support Plan - Internal
SupportPlanId                              : U291cmNlOkVBLFN1YnNjcmlwdGlvbklkOjVBQTc2RjBDLTk1QjktNDJDMS04RTBCLURCRUE3QTREMTM3NCxPZmZlckl
                                             kOk1TLUFaUi0wMDE1UCxTb3ZlcmVpZ25DbG91ZDpQdWJsaWMs
SupportPlanType                            : Azure Internal
SupportTicketId                            : 2403080040013218
TechnicalTicketDetailResourceId            : /subscriptions/5aa76f0c-95b9-42c1-8e0b-dbea7a4d1374/resourceGroups/testResourceGroup/provider
                                             s/Microsoft.Compute/virtualMachines/TESTMV
Title                                      : test
Type                                       : Microsoft.Support/supportTickets
```

Creates a new support ticket for technical issues for the specified subscription

## PARAMETERS

### -AdvancedDiagnosticConsent
Advanced diagnostic consent to be updated on the support ticket.

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

Required: True
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

Required: True
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

Required: True
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

Required: True
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

Required: True
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

Required: True
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

Required: True
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

### -Description
Detailed description of the question or issue.

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

### -EnrollmentId
Enrollment Id associated with the support ticket.

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

### -FileWorkspaceName
File workspace name.

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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProblemScopingQuestion
Problem scoping questions associated with the support ticket.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IQuotaChangeRequest[]
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

### -ServiceId
This is the resource Id of the Azure service resource associated with the support ticket.

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
A value that indicates the urgency of the case, which in turn determines the response time according to the service level agreement of the technical support plan you have with Azure.
Note: 'Highest critical impact', also known as the 'Emergency - Severe impact' level in the Azure portal is reserved only for our Premium customers.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -SupportPlanId
Support plan id associated with the support ticket.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportTicketDetails

## NOTES

## RELATED LINKS

