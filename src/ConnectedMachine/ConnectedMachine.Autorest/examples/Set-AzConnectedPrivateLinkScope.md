### Example 1: Set a private link scope in a subscription by name
```powershell
$tags = @{"Tag1"="tag1"; "Tag2"="tag2"}
Set-AzConnectedPrivateLinkScope -ResourceGroupName "myResourceGroup" -ScopeName "myPrivateLinkScope" -PublicNetworkAccess "Disabled" -Tag $tags -Location "eastus"
```

```output
Name         Location    PublicNetworkAccess ProvisioningState
----         --------    ------------------- -----------------
name         eastus2euap Disabled            Succeeded         
```

Updates the PublicNetworkAccess to "Disable" and tags to $tags
