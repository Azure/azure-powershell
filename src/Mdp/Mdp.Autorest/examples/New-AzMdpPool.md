### Example 1: Create a Managed DevOps Pool
```powershell
New-AzMdpPool -Name Contoso -ResourceGroupName testRG -Location westus -MaximumConcurrency 2 -DevCenterProjectResourceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/example/providers/Microsoft.DevCenter/projects/contoso-proj" -AgentProfile '{"kind": "stateless"}' -OrganizationProfile '{"kind": "AzureDevOps","organizations": [{"url": "https://dev.azure.com/contoso-org","projects": null,"parallelism": 1}],"permissionProfile": {"kind": "CreatorOnly"}}' -FabricProfile '{"kind": "Vmss", "sku": {"name": "Standard_DS12_v2"}, "storageProfile": { "osDiskStorageAccountType": "Standard","dataDisks": []},"images": [{"resourceId": "/Subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/Providers/Microsoft.Compute/Locations/eastus2/Publishers/canonical/ArtifactTypes/VMImage/Offers/0001-com-ubuntu-server-focal/Skus/20_04-lts-gen2/versions/latest","buffer": "*"}]}'
```

This command creates a Managed DevOps Pool named "Contoso" under the resource group "testRG"

### Example 2: Create a Managed DevOps Pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "PoolName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}

New-AzMdpPool -InputObject $pool -Location westus -MaximumConcurrency 2 -DevCenterProjectResourceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/example/providers/Microsoft.DevCenter/projects/contoso-proj" -AgentProfile '{"kind": "stateless"}' -OrganizationProfile '{"kind": "AzureDevOps","organizations": [{"url": "https://dev.azure.com/contoso-org","projects": null,"parallelism": 1}],"permissionProfile": {"kind": "CreatorOnly"}}' -FabricProfile '{"kind": "Vmss", "sku": {"name": "Standard_DS12_v2"}, "storageProfile": { "osDiskStorageAccountType": "Standard","dataDisks": []},"images": [{"resourceId": "/Subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/Providers/Microsoft.Compute/Locations/eastus2/Publishers/canonical/ArtifactTypes/VMImage/Offers/0001-com-ubuntu-server-focal/Skus/20_04-lts-gen2/versions/latest","buffer": "*"}]}'
```

This command creates a Managed DevOps Pool named "Contoso" under the resource group "testRG"
