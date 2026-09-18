### Example 1: List existing SMTP Usernames for a Communication Service resource
```powershell
Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
EntraApplicationId           : aaaa1111-bbbb-2222-3333-aaaa1111abcd
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourcegroups/ContosoResourceProvider1/providers/microsoft.communicati
                               on/communicationservices/ContosoAcsResource1/SmtpUsernames/ContosoSmtpUsernameResource1
Name                         : ContosoSmtpUsernameResource1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TenantId                     : 72f988bf-86f1-41af-91ab-2d7cd011db47
Type                         : communicationservices/smtpusernames
Username                     : ContosoUsername1
 
EntraApplicationId           : 1e1e1d1a-1111-1111-1111-11ad111bf111
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourcegroups/ContosoResourceProvider1/providers/microsoft.communicati
                               on/communicationservices/ContosoAcsResource1/SmtpUsernames/ContosoSmtpUsernameResource2
Name                         : ContosoSmtpUsernameResource2
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TenantId                     : aaaa1111-bbbb-2222-3333-aaaa11112222
Type                         : communicationservices/smtpusernames
Username                     : ContosoUsername2
```

Returns a list of all SMTP Username resources under the specified Communication Services resource.

### Example 2: Get the information if single SMTP Username resource is present
```powershell
Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
EntraApplicationId           : 1e1e1d1a-1111-1111-1111-11ad111bf111
Id                           : /subscriptions/11112222-3333-4444-5555-666677778888/resourcegroups/ContosoResourceProvider1/pro
                               viders/microsoft.communication/communicationservices/ContosoAcsResource1/SmtpUsernames/ContosoSmtpUsernameResource1
Name                         : ContosoSmtpUsernameResource1
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TenantId                     : aaaa1111-bbbb-2222-3333-aaaa11112222
Type                         : communicationservices/smtpusernames
Username                     : ContosoUsername1
```

Returns information if single SMTP Username resource is present.

