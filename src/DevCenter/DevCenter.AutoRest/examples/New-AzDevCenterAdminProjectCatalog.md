### Example 1: Create an Azure Dev Ops project catalog
```powershell
New-AzDevCenterAdminProjectCatalog -ProjectName DevProject -Name CentralCatalog -ResourceGroupName testRg -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```
Create an Azure Dev Ops project catalog named "CentralCatalog" in the project "DevProject".

### Example 2: Create a GitHub project catalog
```powershell
New-AzDevCenterAdminProjectCatalog -ProjectName DevProject -Name CentralCatalog -ResourceGroupName testRg -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/DevProject/centralrepo-fake.git"
```
This command creates a GitHub project catalog named "CentralCatalog" in the project "DevProject".

### Example 3: Create an Azure Dev Ops project catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminProjectCatalog -InputObject $catalog -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```
This command creates an Azure Dev Ops project catalog named "CentralCatalog" in the project "DevProject".

### Example 4: Create a Github project catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminProjectCatalog -InputObject $catalog -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/DevProject/centralrepo-fake.git"
```
This command creates a GitHub project catalog named "CentralCatalog" in the project "DevProject".
