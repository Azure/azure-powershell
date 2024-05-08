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