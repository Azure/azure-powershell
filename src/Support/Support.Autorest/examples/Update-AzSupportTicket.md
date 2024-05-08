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