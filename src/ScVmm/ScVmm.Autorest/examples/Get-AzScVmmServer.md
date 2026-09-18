### Example 1: List VMM Servers in a Subscription
```powershell
Get-AzScVmmServer -SubscriptionId "00000000-abcd-0000-abcde-000000000000"
```

```output
Name                ResourceGroupName Location ProvisioningState
----                ----------------- -------- -----------------
test-vmmserver-01   test-rg-01        eastus   Succeeded
test-vmmserver-02   test-rg-01        eastus   Succeeded
test-vmmserver-03   test-rg-02        westus   Succeeded
test-vmmserver-04   test-rg-02        eastus   Succeeded
test-vmmserver-05   test-rg-03        westus   Succeeded
```

This command lists VMM Servers in provided subscription.

### Example 2: List VMM Servers in a Resource Group
```powershell
Get-AzScVmmServer -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01"
```

```output
Name                ResourceGroupName Location ProvisioningState
----                ----------------- -------- -----------------
test-vmmserver-01   test-rg-01        eastus   Succeeded
test-vmmserver-02   test-rg-01        eastus   Succeeded
```

This command lists VMM Servers in provided Resource Group.

### Example 3: Get a specific VMM Server
```powershell
Get-AzScVmmServer -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01" -Name "test-vmmserver-01"
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

This command gets the VMM Server named `test-vmmserver-01` in a resource group named `test-rg-01`.
