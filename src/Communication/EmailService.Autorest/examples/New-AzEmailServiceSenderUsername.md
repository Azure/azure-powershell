### Example 1: Creates a sender username resource for custom domain.
```powershell
New-AzEmailServiceSenderUsername -SenderUsername test -Username test -DomainName testcustomdomain2.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
DataLocation                 :
DisplayName                  :
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/testcustomdomain2.net/senderUsernames/test
Name                         : test
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 21-02-2024 08:46:18
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 08:46:18
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.communication/emailservices/domains/senderusernames
Username                     : test
```

Create a sender username resource for custom domain with the provided parameters.

### Example 2: Creates a sender username resource for Azure managed domain
```powershell
New-AzEmailServiceSenderUsername -SenderUsername test -Username test -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1							   
```

```output
DataLocation                 :
DisplayName                  :
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/tcsacstest1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/AzureManagedDomain/senderUsernames/test
Name                         : test
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 21-02-2024 08:47:25
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 08:47:25
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.communication/emailservices/domains/senderusernames
Username                     : test
```

Create a sender username resource for Azure managed domain with the provided parameters.

