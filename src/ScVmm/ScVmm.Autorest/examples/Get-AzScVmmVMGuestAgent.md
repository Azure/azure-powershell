### Example 1: Get GuestAgent
```powershell
Get-AzScVmmVMGuestAgent -Name "test-vm" -ResourceGroupName "test-rg-01"
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

Gets GuestAgent resource details for the given virtual machine.
