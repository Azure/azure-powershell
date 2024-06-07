### Example 1: Invoke Reconcile of NetworkSecurityPerimeterNsp AccessRules
```powershell
Invoke-AzNetworkSecurityPerimeterNspAccessRulesReconcile -AccessRuleName MyAccessRule -ProfileName profile -ResourceGroupName ResourceGroup-1 -NetworkSecurityPerimeterName nsp3
```

Invoke Reconcile of NetworkSecurityPerimeterNsp AccessRules

### Example 2: Invoke Reconcile of NetworkSecurityPerimeterNsp AccessRules by identity (using pipe)
```powershell
 $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ProfileName profile1 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3
 Invoke-AzNetworkSecurityPerimeterNspAccessRulesReconcile -InputObject $GETObj
```

Invoke Reconcile of NetworkSecurityPerimeterNsp AccessRules by identity (using pipe)

