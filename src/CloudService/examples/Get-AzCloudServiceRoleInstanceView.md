### Example 1: Get instance view details for cloud service role instance

```powershell
PS C:\> Get-AzCloudServiceRoleInstanceView -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"

Statuses           PlatformFaultDomain PlatformUpdateDomain
--------           ------------------- --------------------
{RoleStateStarted} 0                   0

```

This cmdlet gets the instance view of the role instance named ContosoFrontEnd_IN_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
