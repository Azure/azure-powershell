### Example 1: Deletes a NetworkSecurityPerimeterProfile by Name

```powershell

 Remove-AzNetworkSecurityPerimeterProfile -Name profile6 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp4

```

```output

```
Deletes a NetworkSecurityPerimeterProfile by Name

### Example 2: Deletes a NetworkSecurityPerimeterProfile by identity (using pipe)

```powershell

 $profileObj = Get-AzNetworkSecurityPerimeterProfile -Name profile7 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp4      Remove-AzNetworkSecurityPerimeterProfile -InputObject $profileObj

```

```output

```
Deletes a NetworkSecurityPerimeterProfile by identity (using pipe)
