### Example 1: Get list of support tickets at subscription level
```powershell
 Get-AzSupportTicket
```

```output
Name                                                   Title                                 SupportTicketId  Severity ServiceDisplayName CreatedDate
----                                                   -----                                 ---------------  -------- ------------------ -----------
517f2da6-9bc71cda-278fc71b-7b86-4289-baec-922e8be1a04a test                                  2403080040012292 Minimal  Billing            3/8/2024 9:03:26 PM
test1-5dda17d0-a60d-4f4c-82e3-0fe3604c0ed4             test ticket - please ignore and close 2403060040007460 Minimal  Billing            3/6/2024 3:09:28 PM

Lists all the support tickets for an Azure subscription. If no parameters are specified, then this command will retrieve all tickets created in the last week by default.
```

### Example 2: Get a support ticket at subscription level
```powershell
 Get-AzSupportTicket -SupportTicketName "test1-5dda17d0-a60d-4f4c-82e3-0fe3604c0ed4"
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
CreatedDate                                : 2/22/2024 12:55:38 AM
Description                                : test ticket - please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 2402220010000447
Id                                         : /subscriptions/76cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft.Su
                                             pport/supportTickets/test1-5dda17d0-a60d-4f4c-82e3-0fe3604c0ed4
ModifiedDate                               : 2/22/2024 5:49:22 AM
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
ServiceLevelAgreementExpirationTime        : 2/22/2024 8:56:00 PM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 2/22/2024 12:55:38 AM
Severity                                   : Minimal
Status                                     : Updating
SupportEngineerEmailAddress                :test@test.com
SupportPlanDisplayName                     : Azure Support Plan - Internal
SupportPlanId                              : U291cmNlOkF6dXJlTW9kZXJuLFN1YnNjcmlwdGlvbklkOjc2Y2I3N2ZhLThiMTctNGVhYi05ND
                                             kzLWI2NWRhY2U5OTgxMyxTb3ZlcmVpZ25DbG91ZDpQdWJsaWMsT2ZmZXJJZDpNUy1BWlItMDAx
                                             NVAs
SupportPlanType                            : Azure Internal
SupportTicketId                            : 2402220010000447
TechnicalTicketDetailResourceId            :
Title                                      : test ticket - please ignore and close
Type                                       : Microsoft.Support/supportTickets
```

Get ticket details for an Azure subscription