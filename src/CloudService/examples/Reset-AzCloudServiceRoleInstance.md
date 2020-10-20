### Example 1: Reimage role instance of a cloud service
```powershell
PS C:\> Reset-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0" -Reimage
```
This command reimages role instance named ContosoFrontEnd\_IN\_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.

### Example 2: Restart role instance of a cloud service
```powershell
PS C:\> Reset-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "*" -Restart
```
This command restarts role instance named ContosoFrontEnd\_IN\_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
