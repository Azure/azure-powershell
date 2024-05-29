### Example 1: Get infomation on specified Azure Email services senderusername resource.
```powershell
Get-AzEmailServiceSenderUsername -SenderUsername donotreply -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
DataLocation                 :
DisplayName                  : DoNotReply
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourcegroups/ContosoResourceProvider1/providers/microsoft.communication/emailservices/
                               ContosoAcsResource1/domains/azuremanageddomain/senderusernames/donotreply
Name                         : donotreply
ProvisioningState            :
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : emailservices/domains/senderusernames
Username                     : donotreply
```

Returns the information on senderusername resource.

### Example 2: List existing Email Service sender usernames.
```powershell
Get-AzEmailServiceSenderUsername -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
Name       SystemData SystemData SystemData    SystemData     SystemData     SystemData         ResourceGroup
           CreatedAt  CreatedBy  CreatedByType LastModifiedAt LastModifiedBy LastModifiedByType                                                                                                                                        Name
----       ---------- ---------- ------------- -------------- -------------- ------------------ ------------- 
donotreply                                                                                      ContosoResourceProvider1
test                                                                                            ContosoResourceProvider1
```

Returns the information on existing Email Service sender usernames.

