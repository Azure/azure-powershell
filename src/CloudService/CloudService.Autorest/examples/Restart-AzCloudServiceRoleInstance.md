### Example 1: Restart role instance of a cloud service

```powershell
Restart-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"
```

This command restarts role instance named ContosoFrontEnd_IN_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
