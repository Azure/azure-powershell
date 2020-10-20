### Example 1: Get instance view for all role instances
```powershell
PS C:\> Get-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -Expand instaceView

Name                    Location    InstanceViewStatuses   InstanceViewPlatformFaultDomain InstanceViewPlatformUpdateDomain
----                    --------    --------------------   ------------------------------- --------------------------------
ContosoFrontEnd_IN_0    eastus2euap {{...                  0                               0
ContosoFrontEnd_IN_1    eastus2euap {{...                  1                               1
ContosoBackEnd_IN_1     eastus2euap {{...                  0                               0
ContosoBackEnd_IN_1     eastus2euap {{...                  1                               1

```
This command gets the properties of all role instances of cloud service named ContosoCS that belongs to the resource group named ContosOrg. Since the command specifies the -Expand instanceView parameter, the cmdlet gets the instance view of the role instances.

### Example 2: Get properties for single role instance
```powershell
PS C:\> Get-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"

Name                     Location    InstanceViewStatuses InstanceViewPlatformFaultDomain InstanceViewPlatformUpdateDomain
----                     --------    -------------------- ------------------------------- --------------------------------
ContosoFrontEnd_IN_0     eastus2euap
```
This command gets the properties of the role instance named ContosoFrontEnd\_IN_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg. Since the command does not specify the InstanceView switch parameter, the cmdlet gets the model view of the role instance. 

### Example 3: Get instance view details for single role instance
```powershell
PS C:\> Get-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0" -InstanceView
PlatformFaultDomain PlatformUpdateDomain
------------------- --------------------
0                   0
```
This cmdlet gets the instance view of the role instance named ContosoFrontEnd\_IN_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.


