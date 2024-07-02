### Example 1: Updates email service custom domain.
```powershell
Update-AzEmailServiceDomain -Name testcustomdomain2.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleUpdatedValue"} -UserEngagementTracking 1
```

```output
DataLocation                 : unitedstates
Dkim2ErrorCode               :
Dkim2Status                  : NotStarted
DkimErrorCode                :
DkimStatus                   : NotStarted
DmarcErrorCode               :
DmarcStatus                  : NotStarted
DomainErrorCode              :
DomainManagement             : CustomerManaged
DomainStatus                 : NotStarted
FromSenderDomain             : testcustomdomain2.net
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/testcustomdomain2.net
Location                     : global
MailFromSenderDomain         : testcustomdomain2.net
Name                         : testcustomdomain2.net
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SpfErrorCode                 :
SpfStatus                    : NotStarted
SystemDataCreatedAt          : 21-02-2024 07:30:12
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 09:06:45
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "ExampleUpdatedValue"
                               }
Type                         : microsoft.communication/emailservices/domains
UserEngagementTracking       : Enabled
VerificationRecord           : {
                                 "Domain": {
                                   "type": "TXT",
                                   "name": "testcustomdomain2.net",
                                   "value": "ms-domain-verification=1ff18540-e0c0-422b-b956-5b4cfa13613b",
                                   "ttl": 3600
                                 },
                                 "SPF": {
                                   "type": "TXT",
                                   "name": "testcustomdomain2.net",
                                   "value": "v=spf1 include:spf.protection.outlook.com -all",
                                   "ttl": 3600
                                 },
                                 "DKIM": {
                                   "type": "CNAME",
                                   "name": "selector1-azurecomm-prod-net._domainkey",
                                   "value": "selector1-azurecomm-prod-net._domainkey.azurecomm.net",
                                   "ttl": 3600
                                 },
                                 "DKIM2": {
                                   "type": "CNAME",
                                   "name": "selector2-azurecomm-prod-net._domainkey",
                                   "value": "selector2-azurecomm-prod-net._domainkey.azurecomm.net",
                                   "ttl": 3600
                                 }
                               }
```

Updates email service custom domain with the provided parameters.

### Example 2: Updates email service azure managed domain.
```powershell
Update-AzEmailServiceDomain -Name AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleValue1updated"} -UserEngagementTracking 1
```

```output
DataLocation                 : unitedstates
Dkim2ErrorCode               :
Dkim2Status                  : Verified
DkimErrorCode                :
DkimStatus                   : Verified
DmarcErrorCode               :
DmarcStatus                  : Verified
DomainErrorCode              :
DomainManagement             : AzureManaged
DomainStatus                 : Verified
FromSenderDomain             : fb0053ef-c684-4028-81eb-a582c1330d87.azurecomm.net
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/AzureManagedDomain
Location                     : global
MailFromSenderDomain         : fb0053ef-c684-4028-81eb-a582c1330d87.azurecomm.net
Name                         : AzureManagedDomain
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SpfErrorCode                 :
SpfStatus                    : Verified
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     : 21-02-2024 09:07:35
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "ExampleValue1updated"
                               }
Type                         : microsoft.communication/emailservices/domains
UserEngagementTracking       : Enabled
VerificationRecord           : {
                               }
```

Updates email service azure managed domain with the provided parameters.

