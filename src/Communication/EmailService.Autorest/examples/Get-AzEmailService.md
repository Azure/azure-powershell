### Example 1: List existing Email Services for a Subscription
```powershell
Get-AzCommunicationService -SubscriptionId 73fc3592-3cef-4300-5e19-8d18b65ce0e8
```

```output
Location Name                                         SystemDataCreatedAt SystemDataCreatedBy         SystemDataCreated
                                                                                                      ByType
-------- ----                                         ------------------- -------------------         -----------------
global   ContosoResource1                             06-12-2021 20:19:45 test@microsoft.com        User
global   ContosoResource2                             06-12-2021 20:22:48 test@microsoft.com        User
```

Returns a list of all ACS resources under that subscription.

### Example 2: Get infomation on specified Azure Email services resource
```powershell
Get-AzEmailService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
DataLocation                 : unitedstates
Id                           : /subscriptions/653983b8-683a-427c-8c27-9e9624ce9176/resourceGroups/ContosoResourceProvider1/providers
                               /Microsoft.Communication/emailServices/ContosoAcsResource1
Location                     : global
Name                         : ContosoAcsResource1
ProvisioningState            : Succeeded
ResourceGroupName            : ContosoResourceProvider1
SystemDataCreatedAt          : 08-12-2023 05:24:48
SystemDataCreatedBy          : test@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12-02-2024 10:35:26
SystemDataLastModifiedBy     : test@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "ExampleKey1": "UpdatedTagValue"
                               }
Type                         : microsoft.communication/emailservices
```

Returns the information on an ACS resource, if one matching provided parameters is found.

