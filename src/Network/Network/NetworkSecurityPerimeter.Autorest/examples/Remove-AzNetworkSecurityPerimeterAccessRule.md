### Example 1: Deletes a NetworkSecurityPerimeterAccessRule by Name

```powershell

 Remove-AzNetworkSecurityPerimeterAccessRule -Name ar5 -ProfileName profile4 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp4

```

```output

```
Deletes a NetworkSecurityPerimeterAccessRule by Name


### Example 2: Deletes a NetworkSecurityPerimeterAccessRule by identity (using pipe)
```powershell

 $accessRuleObj = Get-AzNetworkSecurityPerimeterAccessRule -Name ar6 -ProfileName profile4 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp4     Remove-AzNetworkSecurityPerimeterAccessRule -InputObject $accessRuleObj

```

```output

```
Deletes a NetworkSecurityPerimeterAccessRule by identity (using pipe)
