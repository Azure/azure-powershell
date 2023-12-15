### Example 1: Update the tags of a private link scope
```powershell
$tag = @{ "Tag1" = "Value1" }
Update-AzConnectedPrivateLinkScopeTag -ResourceGroupName "az-sdk-test" -ScopeName "scope-test" -Tag $tag
```

```output
Name               Location    PublicNetworkAccess ProvisioningState
----               --------    ------------------- -----------------
scope-test         eastus2euap Disabled            Succeeded
```

Update the tags of a private link scope