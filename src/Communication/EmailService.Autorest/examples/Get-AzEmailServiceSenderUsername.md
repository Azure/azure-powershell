### Example 1: {{ Add title here }}
```powershell

```

{{ Add description here }}

### Example 2: Get infomation on specified Sender user user name
```powershell
Get-AzEmailServiceSenderUsername -SenderUsername donotreply -DomainName AzureManagedDomain -EmailServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1

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

Returns the information on an sender domain resource, if one matching provided parameters is found.

