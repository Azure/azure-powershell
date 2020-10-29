### Example 1: Reimage role instance of a cloud service

```powershell
PS C:\> Invoke-AzCloudServiceRoleInstanceReimage -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"
```

This command reimages role instance named ContosoFrontEnd_IN_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
