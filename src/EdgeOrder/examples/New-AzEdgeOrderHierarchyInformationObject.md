### Example 1: Creates hierarchy information object
```powershell
<<<<<<< HEAD
$HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
$HierarchyInformation | Format-List
```

```output
=======
PS C:\> $HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
PS C:\> $HierarchyInformation | fl

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ConfigurationName : EdgeP_High
ProductFamilyName : azurestackedge
ProductLineName   : azurestackedge
ProductName       : azurestackedgegpu
```
Creates a in-memory hierarchy information object