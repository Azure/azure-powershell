### Example 1: Updates custom domain sender username resource.
```powershell
Update-AzEmailServiceSenderUsername -SenderUsername test -Username test -DisplayName testdisplayname -DomainName testcustomdomain2.net -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1							   
```

```output
DataLocation                 :
DisplayName                  : testdisplayname
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/testcustomdomain2.net/senderUsernames/test
Name                         : test
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 21-02-2024 09:17:38
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 09:17:38
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.communication/emailservices/domains/senderusernames
Username                     : test
```

Updates custom sender username resource with provided parameters.

### Example 2: Updates azure managed domain sender username resource.
```powershell
Update-AzEmailServiceSenderUsername -SenderUsername test -Username test -DisplayName testAzureDomaindisplayname -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
DataLocation                 :
DisplayName                  : testAzureDomaindisplayname
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1/domains/AzureManagedDomain/senderUsernames/test
Name                         : test
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 21-02-2024 09:34:29
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 09:34:29
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.communication/emailservices/domains/senderusernames
Username                     : test
```

Updates azure managed sender username resource with provided parameters.

