### Example 1: Restart role instances of cloud service

```powershell
PS C:\> $roleInstances = @("ContosoFrontEnd_IN_0", "ContosoBackEnd_IN_1")
PS C:\> Restart-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance $roleInstances
```

This command restarts 2 role instances ContosoFrontEnd_IN_0 and ContosoBackEnd_IN_1 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.

### Example 2: Restart all roles of cloud service

```powershell
PS C:\> Restart-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "*"
```

This command restarts all role instances of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
