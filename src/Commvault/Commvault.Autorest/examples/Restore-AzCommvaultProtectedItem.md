### Example 1: Restore a protected item in place
```powershell
Restore-AzCommvaultProtectedItem -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Name vm-app01 -InPlaceRestore -VMDestinationInfoVminfoList @{ SourceVMGuid = '40000000-aaaa-4bbb-8ccc-000000000000'; StorageAccountId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Storage/storageAccounts/strestore01'; PowerOnVMAfterRestore = $true }
```

Restores the virtual machine in place and powers it on after the restore completes.

### Example 2: Restore a protected item as a new virtual machine by using a JSON request
```powershell
Restore-AzCommvaultProtectedItem -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Name vm-app01 -JsonString '{"inPlaceRestore":false,"restoreType":"VIRTUAL_MACHINE","vmDestinationInfo":{"vmInfoList":[{"sourceVmGuid":"40000000-aaaa-4bbb-8ccc-000000000000","name":"vm-app01-restored","resourceGroup":"rg-restore","region":"eastus","storageAccountId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Storage/storageAccounts/strestore01","networkId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Network/virtualNetworks/vnet-restore","subnetId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Network/virtualNetworks/vnet-restore/subnets/default","powerOnVmAfterRestore":true}]}}'
```

Restores the virtual machine as a new virtual machine in another resource group and region by passing the request body as a JSON string.

