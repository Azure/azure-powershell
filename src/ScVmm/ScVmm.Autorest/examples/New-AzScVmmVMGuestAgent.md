### Example 1: Enable Guest Management
```powershell
$securePassword = ConvertTo-SecureString "*****" -AsPlainText -Force
New-AzScVmmVMGuestAgent -Name "test-vm" -ResourceGroupName "test-rg-01" -CredentialsPassword $securePassword -CredentialsUsername 'testUser'
```

```output
CredentialsPassword          :
CredentialsUsername          : testUser
CustomResourceName           :
HttpProxyConfigHttpsProxy    :
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/M
                               icrosoft.HybridCompute/machines/test-vm/providers/Microsoft.ScVmm/virtualMachineIn
                               stances/default/guestAgents/default
Name                         : default
ProvisioningAction           : install
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
Status                       : Enabled
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Type                         : microsoft.scvmm/virtualmachineinstances/guestagents
Uuid                         : 
```

Enables Guest Management capability on the virtual machine.

### Example 2: Enable Guest Management
```powershell
$JsonStringInput='{
    "credentials": {
      "username": "testUser",
      "password": "*****"
    },
    "provisioningAction": "install"
}'
New-AzScVmmVMGuestAgent -Name "test-vm" -ResourceGroupName "test-rg-01" -JsonString $JsonStringInput
```

```output
CredentialsPassword          :
CredentialsUsername          : testUser
CustomResourceName           :
HttpProxyConfigHttpsProxy    :
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/M
                               icrosoft.HybridCompute/machines/test-vm/providers/Microsoft.ScVmm/virtualMachineIn
                               stances/default/guestAgents/default
Name                         : default
ProvisioningAction           : install
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
Status                       : Enabled
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Type                         : microsoft.scvmm/virtualmachineinstances/guestagents
Uuid                         : 
```

Enables Guest Management capability on the virtual machine.
