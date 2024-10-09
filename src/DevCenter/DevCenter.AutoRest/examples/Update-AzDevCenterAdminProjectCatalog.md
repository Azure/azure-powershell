### Example 1: Update a project catalog
```powershell
Update-AzDevCenterAdminProjectCatalog -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg -GitHubPath "testpath" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat"
```
This command updates a catalog named "CentralCatalog" in the project "DevProject".

### Example 2: Update a project catalog using InputObject
```powershell
$catalogInput = Get-AzDevCenterAdminProjectCatalog -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg

Update-AzDevCenterAdminProjectCatalog -InputObject $catalogInput -GitHubPath "testpath" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat"
```
This command updates a catalog named "CentralCatalog" in the project "DevProject".
