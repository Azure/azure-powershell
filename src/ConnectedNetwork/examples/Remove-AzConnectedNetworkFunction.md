### Example 1: Remove-AzConnectedNetworkFunction via Resource Group and Resource name
```powershell
<<<<<<< HEAD
Remove-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf
=======
PS C:\> Remove-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deleting the Network Function in Resource Group myResources with name myVnf.

### Example 2: Remove-AzConnectedNetworkFunction via Identity
```powershell
<<<<<<< HEAD
$vnf = Get-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf1
Remove-AzConnectedNetworkFunction -InputObject $vnf
=======
PS C:\> $vnf = Get-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf1
PS C:\> Remove-AzConnectedNetworkFunction -InputObject $vnf

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Creating an identity with name myVnf1 and resource group name myResources. Deleting the Network Function with the given Identity.