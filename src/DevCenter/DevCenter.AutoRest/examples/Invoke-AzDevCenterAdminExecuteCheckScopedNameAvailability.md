### Example 1: Checked scoped name availability of project catalog
```powershell
Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability -Name "CentralCatalog" -Type "Microsoft.DevCenter/projects/catalogs" -Scope "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/rg1/providers/Microsoft.DevCenter/projects/DevProject"
```
This command checks the scoped name availability of "CentralCatalog" with a resource type of "Microsoft.Devcenter/projects/catalogs"

### Example 2: Checked scoped name availability of dev center catalog
```powershell
Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability -Name "CentralCatalog" -Type "Microsoft.DevCenter/devcenters/catalogs" -Scope "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/rg1/providers/Microsoft.DevCenter/devcenters/Contoso"
```
This command checks the scoped name availability of "CentralCatalog" with a resource type of "Microsoft.Devcenter/devcenters/catalogs"

