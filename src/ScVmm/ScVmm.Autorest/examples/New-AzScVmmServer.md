### Example 1: Create a VMM Server resource.
```powershell
$securePassword = ConvertTo-SecureString "******" -AsPlainText -Force
New-AzScVmmServer -Name "test-vmmserver-01" -Fqdn "vmmServerFqdn" -Location "eastus" -Username "scvmm-username" -Password $securePassword -Port 8100 -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -CustomLocationId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl"
```

```output
ConnectionStatus             : Connected
CredentialsPassword          : 
CredentialsUsername          : scvmm-username
ErrorMessage                 : 
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Fqdn                         : vmmServerFqdn
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
Location                     : eastus
Name                         : test-vmmserver-01
Port                         : 8100
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.scvmm/vmmservers
Uuid                         : 00000000-1111-0000-2222-000000000000
Version                      : 10.22.1711.0
```

Create a VMM Server resource in Azure to perform self-service management operation for your on-prem VMM Server.
