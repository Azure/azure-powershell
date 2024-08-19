### Example 1: Update a support ticket at no subscription level
```powershell
Update-AzSupportTicketsNoSubscription -Name test12345 -AdvancedDiagnosticConsent Yes
```

```output
AdvancedDiagnosticConsent                  : Yes
ContactDetailAdditionalEmailAddress        :
ContactDetailCountry                       : USA
ContactDetailFirstName                     : test
ContactDetailLastName                      : test
ContactDetailPhoneNumber                   :
ContactDetailPreferredContactMethod        : Email
ContactDetailPreferredSupportLanguage      : en-US
ContactDetailPreferredTimeZone             : Pacific Standard Time
ContactDetailPrimaryEmailAddress           : test@test.com
CreatedDate                                : 3/7/2024 5:35:55 PM
Description                                : test ticket - please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 2403070040010395
Id                                         : /providers/Microsoft.Support/supportTickets/test12345
ModifiedDate                               : 3/7/2024 6:12:56 PM
Name                                       : test12345
ProblemClassificationDisplayName           : Add or update VAT, tax id, PO number or profile information
ProblemClassificationId                    : /providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc/problemClassifications/3ec1a070-f242-9ecf-5a7c-e1a88ce029ef
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
ServiceLevelAgreementExpirationTime        : 3/8/2024 1:35:55 AM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 3/7/2024 5:35:55 PM
Severity                                   : Minimal
Status                                     : Open
SupportEngineerEmailAddress                : test@microsoft.com
SupportPlanDisplayName                     : Basic support
SupportPlanId                              : U291cmNlOkZyZWUsRnJlZUlkOjAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwOSw=
SupportPlanType                            : Basic
SupportTicketId                            : 2403070040010395
TechnicalTicketDetailResourceId            :
Title                                      : test ticket - please ignore and close
Type                                       : Microsoft.Support/supportTickets
```

Update a tenant-level support ticket

