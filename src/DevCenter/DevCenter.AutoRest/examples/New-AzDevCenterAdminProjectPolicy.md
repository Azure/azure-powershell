### Example 1: Create a project policy with resource policies and scopes
```powershell
$resourcePolicies = @(
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win10-m365-gen2" };
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win11-m365-gen2" };
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/attachednetworks/network-westus3" };
    @{ Action = "Allow"; ResourceType = "Skus" }
)
$scopes = @(
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject";
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject2"
)
New-AzDevCenterAdminProjectPolicy `
  -DevCenterName "Contoso" `
  -Name "myPolicy" `
  -ResourceGroupName "testRg" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff" `
  -ResourcePolicy $resourcePolicies `
  -Scope $scopes
```

This command creates a project policy named "myPolicy" in the dev center "Contoso" with multiple resource policies and scopes.

### Example 2: Create a project policy using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "testRg"
    DevCenterName = "Contoso"
    ProjectPolicyName = "myPolicy"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
$resourcePolicies = @(
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win10-m365-gen2" }
)
$scopes = @(
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject"
)
New-AzDevCenterAdminProjectPolicy -InputObject $inputObject -ResourcePolicy $resourcePolicies -Scope $scopes
```

This command creates a project policy using an input object and assigns a single resource policy and scope.