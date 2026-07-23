### Example 1: Create a SMTP Username resource
```powershell
New-AzCommunicationServiceSmtpUsername -SmtpUsername ContosoSmtpUsernameResource1 -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -EntraApplicationId 1ebe1d1a-1111-1111-1c11-11ad111bf111 -TenantId 11f111b1-11f1-11af-11ab-1d1cd111db11 -Username ContosoUsername1
```

```output
EntraApplicationId           : 1ebe1d1a-1111-1111-1c11-11ad111bf111
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/communicationServices/ContosoAcsResource1/smtpUsernames/ContosoSmtpUsernameResource1
Name                         : ContosoSmtpUsernameResource1
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 25-02-2025 11:24:05
SystemDataCreatedBy          : newuser1@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 25-02-2025 11:24:05
SystemDataLastModifiedBy     : newuser1@contoso.com
SystemDataLastModifiedByType : User
TenantId                     : aaaa1111-bbbb-2222-3333-aaaa11112222
Type                         : microsoft.communication/communicationservices/smtpusernames
Username                     : ContosoUsername1
```

Create a SMTP Username resource with the provided parameters.

