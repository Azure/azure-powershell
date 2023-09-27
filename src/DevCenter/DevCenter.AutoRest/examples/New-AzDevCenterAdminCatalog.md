### Example 1: Create an Azure Dev Ops catalog
```powershell
New-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```
Create an Azure Dev Ops catalog named "CentralCatalog" in the dev center "Contoso".

### Example 2: Create a GitHub catalog
```powershell
New-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/Contoso/centralrepo-fake.git"
```
This command creates a GitHub catalog named "CentralCatalog" in the dev center "Contoso".

### Example 3: Create an Azure Dev Ops catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminCatalog -InputObject $catalog -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```
This command creates an Azure Dev Ops catalog named "CentralCatalog" in the dev center "Contoso".

### Example 4: Create a Github catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminCatalog -InputObject $catalog -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/Contoso/centralrepo-fake.git"
```
This command creates a GitHub catalog named "CentralCatalog" in the dev center "Contoso".
