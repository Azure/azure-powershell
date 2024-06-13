### Example 1: Reconcile NSP association
```powershell
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName association3 -NetworkSecurityPerimeterName nsp3 -ResourceGroupName ResourceGroup-1 
```

Reconcile NSP association

### Example 2: Reconcile NSP association by identity (using pipe)
```powershell
 $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3
 Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -InputObject $GETObj
```

Reconcile NSP association by identity (using pipe)

