### Example 1: Creates hierarchy information object
```powershell
PS C:\> $HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
PS C:\> $HierarchyInformation | fl

ConfigurationName : EdgeP_High
ProductFamilyName : azurestackedge
ProductLineName   : azurestackedge
ProductName       : azurestackedgegpu
```
Creates a in-memory hierarchy information object