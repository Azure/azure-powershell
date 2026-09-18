### Example 1: Delete an asset by name and resource group.
```powershell
Remove-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg
```
This command deletes asset `test-asset` from resource group `test-rg`

### Example 2: DeleteViaIdentity for asset.
```powershell
$asset = @{ "ResourceGroupName" = "test-rg"; "AssetName" = "test-asset"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Remove-AzDeviceRegistryAsset -InputObject $asset
```

This command deletes asset  `test-asset` via the Identity input object.
