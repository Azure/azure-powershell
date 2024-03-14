### Example 1: Updates an email service resource.
```powershell
Update-AzEmailService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="UpdatedTagValue"}
```

```output
DataLocation                 : United States
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers/Microsoft.Communication/emailServices/
                               ContosoAcsResource1
Location                     : global
Name                         : ContosoAcsResource1
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 21-02-2024 07:24:19
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 21-02-2024 09:00:57
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "UpdatedTagValue"
                               }
Type                         : microsoft.communication/emailservices
```

Updates an email service resource with the provided tags.

