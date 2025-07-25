### Example 1: Update a catalog
```powershell
Update-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg -GitHubPath "testpath" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat"
```
This command updates a catalog named "CentralCatalog" in the dev center "Contoso".

### Example 2: Update a catalog using InputObject
```powershell
$catalogInput = Get-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg

Update-AzDevCenterAdminCatalog -InputObject $catalogInput -GitHubPath "testpath" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat"
```
This command updates a catalog named "CentralCatalog" in the dev center "Contoso".
