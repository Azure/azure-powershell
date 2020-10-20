### Example 1: Reimage a cloud service
```powershell
PS C:\> $roleInstances = @("ContosoFrontEnd_IN_0", "ContosoBackEnd_IN_1")
PS C:\> Reset-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance $roleInstances -Reimage
```
This command reimages 2 role instances ContosoFrontEnd\_IN\_0 and  ContosoBackEnd\_IN\_1 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.

### Example 2: Reimage all roles of cloud service
```powershell
PS C:\> Reset-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "*" -Reimage
```
This command reimages all role instances of cloud service named ContosoCS that belongs to the resource group named ContosOrg.