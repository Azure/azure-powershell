### Example 1: Create a query object with single resource id
```powershell
New-AzTerraformExportResourceObject -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet"
```

```output
FullProperty   :
MaskSensitive  :
NamePattern    :
ResourceId     : {/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks
                 /test-vnet}
ResourceName   :
ResourceType   :
TargetProvider :
Type           : ExportResource
```

 Create a query object with single resource id

### Example 2: Create a query object with multiple resource Ids
```powershell
New-AzTerraformExportResourceObject -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet","/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet2"
```

```output
FullProperty   :
MaskSensitive  :
NamePattern    :
ResourceId     : {/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks
                 /test-vnet, /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virt
                 ualNetworks/test-vnet2}
ResourceName   :
ResourceType   :
TargetProvider :
Type           : ExportResource
```

Create a query object with multiple resource Ids
