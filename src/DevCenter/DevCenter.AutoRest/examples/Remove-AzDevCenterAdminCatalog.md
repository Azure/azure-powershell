### Example 1: Remove a catalog
```powershell
Remove-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg
```
This command deletes the catalog named "CentralCatalog" in the dev center "Contoso". 

### Example 2: Remove a catalog using InputObject
```powershell
$catalog = Get-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg
Remove-AzDevCenterAdminCatalog -InputObject $catalog
```
This command deletes the catalog named "CentralCatalog" in the dev center "Contoso". 

