### Example 1: Get all Dedicated HSM under a subscription
```powershell
Get-AzDedicatedHsm
```

```output
Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-7t2xaf Succeeded          SafeNet Luna Network HSM A790 eastus
yeminghsm  Succeeded          SafeNet Luna Network HSM A790 eastus
```

This command gets all Dedicated HSM under a subscription

### Example 2: Get all Dedicated HSM under a resource group.
```powershell
Get-AzDedicatedHsm -ResourceGroupName dedicatedhsm-rg-n359cz
```

```output
Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-7t2xaf Succeeded          SafeNet Luna Network HSM A790 eastus
```

This command gets all Dedicated HSM under a resource group.

### Example 3: Get a Dedicated HSM by name
```powershell
Get-AzDedicatedHsm -Name hsm-7t2xaf -ResourceGroupName dedicatedhsm-rg-n359cz
```

```output
Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-7t2xaf Succeeded          SafeNet Luna Network HSM A790 eastus
```

This command gets a Dedicated HSM by name.

### Example 4: Get a Dedicated HSM by object
```powershell
$hsm = New-AzDedicatedHsm -Name hsm-n7wfxi -ResourceGroupName dedicatedhsm-rg-n359cz -Location eastus -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId "/subscriptions/xxxx-xxxx-xxx-xxx/resourceGroups/dedicatedhsm-rg-n359cz/providers/Microsoft.Network/virtualNetworks/vnetq30la9/subnets/hsmsubnet" -NetworkInterface @{PrivateIPAddress = '10.2.1.120' }
Get-AzDedicatedHsm -InputObject $hsm
```

```output
Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-n7wfxi Succeeded          SafeNet Luna Network HSM A790 eastus
```

This command gets a Dedicated HSM by object.

