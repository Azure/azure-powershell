### Example 1: Create a profile-level association
```powershell
New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel $true
```

Creates an in-memory association object that applies an authentication policy at the profile level. This command does not create or update an Azure resource.

### Example 2: Create an association for a route
```powershell
$route = @{ Id = "/subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/myResourceGroup/providers/Microsoft.Cdn/profiles/myProfile/afdEndpoints/myEndpoint/routes/myRoute" }
New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel:$false -Route $route
```

Creates an in-memory association object for the specified route. Pass the object to an authentication policy create or update command.
