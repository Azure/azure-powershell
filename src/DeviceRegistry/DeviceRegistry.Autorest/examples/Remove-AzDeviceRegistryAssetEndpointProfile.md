### Example 1: Delete an asset endpoint profile by name and resource group.
```powershell
Remove-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg
```

This command deletes asset endpoint profile `test-assetendpointprofile` from resource group `test-rg`

### Example 2: DeleteViaIdentity for asset endpoint profile.
```powershell
$assetEndpointProfile = @{ "ResourceGroupName" = "test-rg"; "AssetEndpointProfileName" = "test-assetendpointprofile"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Remove-AzDeviceRegistryAssetEndpointProfile -InputObject $assetEndpointProfile
```

This command deletes asset endpoint profile `test-assetendpointprofile` via the Identity input object.
