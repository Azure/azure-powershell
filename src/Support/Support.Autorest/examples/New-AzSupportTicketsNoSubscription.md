### Example 1: Creates support ticket at tenant level
```powershell
New-AzSupportTicketsNoSubscription -SupportTicketName "test12345678" -AdvancedDiagnosticConsent "no" -ContactDetailPrimaryEmailAddress "test@test.com" -ContactDetailFirstName "test" -ContactDetailLastName "test" -ContactDetailPreferredContactMethod "email" -ContactDetailPreferredTimeZone "Pacific Standard Time" -ContactDetailPreferredSupportLanguage "en-US" -ContactDetailCountry "usa" -Description "test ticket - please ignore and close" -Severity "minimal" -Title "test ticket - please ignore and close" -ServiceId "/providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc" -ProblemClassificationId "/providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc/problemClassifications/3ec1a070-f242-9ecf-5a7c-e1a88ce029ef"
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
CreatedDate                                : 2/22/2024 6:51:11 AM
Description                                : test ticket - please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 2402220010002592
Id                                         : /providers/Microsoft.Support/supportTickets/test12345678
ModifiedDate                               : 2/22/2024 6:51:28 AM
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
ServiceLevelAgreementStartTime             : 2/22/2024 6:51:11 AM
Severity                                   : Minimal
Status                                     : Open
SupportEngineerEmailAddress                :
SupportPlanDisplayName                     : Basic support
SupportPlanId                              : U291cmNlOkZyZWUsRnJlZUlkOjAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwOS
                                             w=
SupportPlanType                            : Basic
SupportTicketId                            : 2402220010002592
TechnicalTicketDetailResourceId            :
Title                                      : test ticket - please ignore and close
Type                                       : Microsoft.Support/supportTickets
```

Creates a new support ticket for Billing, and Subscription Management issues
