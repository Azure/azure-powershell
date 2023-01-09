### Example 1: Remove-AzConnectedNetworkFunction via Resource Group and Resource name
```powershell
Remove-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf
```

Deleting the Network Function in Resource Group myResources with name myVnf.

### Example 2: Remove-AzConnectedNetworkFunction via Identity
```powershell
$vnf = Get-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf1
Remove-AzConnectedNetworkFunction -InputObject $vnf
```

Creating an identity with name myVnf1 and resource group name myResources. Deleting the Network Function with the given Identity.