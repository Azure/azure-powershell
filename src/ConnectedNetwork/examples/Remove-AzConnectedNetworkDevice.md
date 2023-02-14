### Example 1: Remove-AzConnectedNetworkDevice via resource name and resource group
```powershell
<<<<<<< HEAD
Remove-AzConnectedNetworkDevice -Name myMecDevice -ResourceGroupName myResources
=======
PS C:\> Remove-AzConnectedNetworkDevice -Name myMecDevice -ResourceGroupName myResources

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deleting the NFM device with device name myMecDevice in resource group myResources.

### Example 2: Remove-AzConnectedNetworkDevice via Identity
```powershell
<<<<<<< HEAD
$mecDevice = Get-AzConnectedNetworkDevice -Name myMecDevice2 -ResourceGroupName myResources
Remove-AzConnectedNetworkDevice -InputObject $mecDevice
=======
PS C:\> $mecDevice = Get-AzConnectedNetworkDevice -Name myMecDevice2 -ResourceGroupName myResources
PS C:\> Remove-AzConnectedNetworkDevice -InputObject $mecDevice

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Creating an identity with name myMecDevice2 and resource group name myResources. Deleting the NFM device with the given identity.