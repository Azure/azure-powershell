### Example 1: Reconciles the NSP association of a storage account
```powershell
Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration -ResourceGroupName "nsprg" -AccountName "nspaccount" -NetworkSecurityPerimeterConfigurationName "00000000-0000-0000-0000-000000000000.associationame"
```

This command refreshes any information about the NSP association of a storage account
