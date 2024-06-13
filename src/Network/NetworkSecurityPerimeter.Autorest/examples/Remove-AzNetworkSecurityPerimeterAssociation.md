### Example 1: Deletes a NetworkSecurityPerimeterAccessAssociation by Name
```powershell

 Remove-AzNetworkSecurityPerimeterAssociation -Name association4 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp4

```

Deletes a NetworkSecurityPerimeterAccessAssociation by Name

### Example 2: Deletes a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)
```powershell

 $associationObj = Get-AzNetworkSecurityPerimeterAssociation -Name association5 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp4
 Remove-AzNetworkSecurityPerimeterAssociation -InputObject $associationObj

```

Deletes a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)
