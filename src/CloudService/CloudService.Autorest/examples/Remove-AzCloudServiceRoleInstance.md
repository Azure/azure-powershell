### Example 1: Remove a cloud service role instance

```powershell
Remove-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "ContosoFrontEnd_IN_0"
```

This command removes the role instance named ContosoFrontEnd_IN_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
