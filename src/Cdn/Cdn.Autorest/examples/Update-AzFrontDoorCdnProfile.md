### Example 1: Update an AzureFrontDoor profile under the resource group
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -Tag $tags
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Update an AzureFrontDoor profile under the resource group


### Example 2: Update an AzureFrontDoor profile under the resource group via identity
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 | Update-AzFrontDoorCdnProfile -Tag $tags
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Update an AzureFrontDoor profile under the resource group via identity


### Example 3: Enable managed identity using SystemAssigned type to an AzureFrontDoor profile
```powershell
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -IdentityType SystemAssigned
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable managed identity using SystemAssigned type to an AzureFrontDoor profile


### Example 4: Enable managed identity using UserAssigned type to an AzureFrontDoor profile
```powershell
$userId =  @{"/subscriptions/subId/resourceGroups/testps-rg-da16jm/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testcdnrpaadidentity" = @{}}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -IdentityType UserAssigned -IdentityUserAssignedIdentity $userId
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable managed identity using UserAssigned type to an AzureFrontDoor profile