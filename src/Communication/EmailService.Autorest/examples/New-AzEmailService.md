### Example 1: Create a Email service resource
```powershell
New-AzEmailService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -DataLocation "United States"
```

```output
DataLocation                 : United States
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/ContosoAcsResource1
Location                     : global
Name                         : ContosoAcsResource1
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 19-02-2024 07:54:44
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 19-02-2024 07:54:44
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.communication/emailservices
```

Creates a Email service resource using the specified parameters.

