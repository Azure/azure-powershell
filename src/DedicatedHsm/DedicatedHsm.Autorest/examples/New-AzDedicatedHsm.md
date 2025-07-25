### Example 1: Create a Dedicated HSM into an existing virtual network
```powershell
New-AzDedicatedHsm -Name hsm-n7wfxi -ResourceGroupName dedicatedhsm-rg-n359cz -Location eastus -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId "/subscriptions/xxxx-xxxx-xxx-xxx/resourceGroups/dedicatedhsm-rg-n359cz/providers/Microsoft.Network/virtualNetworks/vnetq30la9/subnets/hsmsubnet" -NetworkInterface @{PrivateIPAddress = '10.2.1.120' }
```

```output
Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-n7wfxi Succeeded          SafeNet Luna Network HSM A790 eastus
```

This command creates a Dedicated HSM into an existing virtual network.

**NOTE:** Currently `New-AzDedicatedHsm` has a limitation that it returns before the HSM is fully provisioned on Azure. Therefore after creating a new HSM, please query its state by `Get-AzDedicatedHsm` and make sure its `Provisioning State` is `Succeeded` before using it.