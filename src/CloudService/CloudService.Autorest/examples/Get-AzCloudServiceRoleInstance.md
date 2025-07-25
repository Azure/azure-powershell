### Example 1: Get all role instances

```powershell
Get-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
```

```output
Name                    Location    SkuName        SkuTier
----                    --------    -------        -------
ContosoFrontEnd_IN_0    eastus2euap Standard_D1_v2 Standard
ContosoFrontEnd_IN_1    eastus2euap Standard_D1_v2 Standard
ContosoBackEnd_IN_1     eastus2euap Standard_D1_v2 Standard
ContosoBackEnd_IN_1     eastus2euap Standard_D1_v2 Standard
```

This command gets the properties of all role instances of cloud service named ContosoCS that belongs to the resource group named ContosOrg.

### Example 2: Get properties for single role instance

```powershell
Get-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"
```

```output
Name                    Location    SkuName        SkuTier
----                    --------    -------        -------
ContosoFrontEnd_IN_0    eastus2euap Standard_D1_v2 Standard
```

This command gets the properties of the role instance named ContosoFrontEnd_IN_0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
