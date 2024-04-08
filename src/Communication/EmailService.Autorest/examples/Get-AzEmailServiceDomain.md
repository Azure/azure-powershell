### Example 1: List existing Email Service domains for a Subscription
```powershell
Get-AzEmailServiceDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
Location Name                                           SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                                                                        odifiedBy
-------- ----                                           ------------------- -------------------        ----------------------- ------------------------ ---------------
global   AzureManagedDomain                             08-12-2023 05:34:31 test@microsoft.com         User                    28-01-2024 13:58:25      test@microsoft.com
global   customdomain.net                               07-02-2024 06:11:24 test@microsoft.com         User                    14-02-2024 06:25:26      test@microsoft.com
```

Returns a list of all domain resources under that email services.

### Example 2: Get infomation on specified Azure Email services resource
```powershell
Get-AzEmailServiceDomain -Name AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
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
FromSenderDomain             : a3d08608-7f9d-4d33-9c79-8b635d9220ab.azurecomm.net
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers
                               /Microsoft.Communication/emailServices/ContosoAcsResource1/domains/AzureManaged
                               Domain
Location                     : global
MailFromSenderDomain         : a3d08608-7f9d-4d33-9c79-8b635d9220ab.azurecomm.net
Name                         : AzureManagedDomain
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SpfErrorCode                 :
SpfStatus                    : Verified
SystemDataCreatedAt          : 08-12-2023 05:34:31
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 28-01-2024 13:58:25
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "ExampleValue1"
                               }
Type                         : microsoft.communication/emailservices/domains
UserEngagementTracking       : Disabled
VerificationRecord           : {
                               }
```

Returns the information on an domain resource, if one matching provided parameters is found.

