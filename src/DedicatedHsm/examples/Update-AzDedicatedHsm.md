### Example 1: Update the parameter tag of the Dedicated HSM by name
```powershell
Update-AzDedicatedHsm -Name hsm-n7wfxi -ResourceGroupName dedicatedhsm-rg-n359cz -Tag @{'key1' = '1'; 'key2' = 2; 'key3' = 3}
```

```output
Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-n7wfxi Succeeded          SafeNet Luna Network HSM A790 eastus
```

This command updates the parameter tag of the Dedicated HSM by name

### Example 2: Update the parameter tag of the Dedicated HSM by object
```powershell
$hsm = Get-AzDedicatedHsm -Name hsm-n7wfxi -ResourceGroupName dedicatedhsm-rg-n359cz
Update-AzDedicatedHsm -InputObject $hsm -Tag @{'key1' = '1'; 'key2' = 2; 'key3' = 3}
```

```output
Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-n7wfxi Succeeded          SafeNet Luna Network HSM A790 eastus
```

This command updates the parameter tag of the Dedicated HSM by object

