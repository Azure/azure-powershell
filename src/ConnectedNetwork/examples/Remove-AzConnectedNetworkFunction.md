### Example 1: Remove-AzConnectedNetworkFunction via Resource Group and Resource name
```powershell
PS C:\> Remove-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf

```

Deleting the Network Function in Resource Group myResources with name myVnf.

### Example 2: Remove-AzConnectedNetworkFunction via Identity
```powershell
PS C:\> $vnf = Get-AzConnectedNetworkFunction -ResourceGroupName myResources -Name myVnf1
PS C:\> Remove-AzConnectedNetworkFunction -InputObject $vnf

```

Creating an identity with name myVnf1 and resource group name myResources. Deleting the Network Function with the given Identity.