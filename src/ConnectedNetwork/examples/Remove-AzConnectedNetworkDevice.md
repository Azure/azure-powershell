### Example 1: Remove-AzConnectedNetworkDevice via resource name and resource group
```powershell
Remove-AzConnectedNetworkDevice -Name myMecDevice -ResourceGroupName myResources
```

Deleting the NFM device with device name myMecDevice in resource group myResources.

### Example 2: Remove-AzConnectedNetworkDevice via Identity
```powershell
$mecDevice = Get-AzConnectedNetworkDevice -Name myMecDevice2 -ResourceGroupName myResources
Remove-AzConnectedNetworkDevice -InputObject $mecDevice
```

Creating an identity with name myMecDevice2 and resource group name myResources. Deleting the NFM device with the given identity.