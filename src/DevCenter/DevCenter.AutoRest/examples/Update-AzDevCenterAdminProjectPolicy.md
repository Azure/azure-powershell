### Example 1: Update the resource policies of a project policy
```powershell
$resourcePolicies = @(
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win10-m365-gen2" };
    @{ Action = "Deny"; ResourceType = "Skus" }
)
Update-AzDevCenterAdminProjectPolicy `
  -DevCenterName "Contoso" `
  -Name "myPolicy" `
  -ResourceGroupName "testRg" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff" `
  -ResourcePolicy $resourcePolicies
```

This command updates the project policy named "myPolicy" in the dev center "Contoso" to set new resource policies.

### Example 2: Update the scopes of a project policy using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "testRg"
    DevCenterName = "Contoso"
    ProjectPolicyName = "myPolicy"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
$scopes = @(
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject";
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject2"
)
Update-AzDevCenterAdminProjectPolicy -InputObject $inputObject -Scope $scopes
```

This command updates the scopes of the project policy "myPolicy" in the dev center "Contoso" using an input object.