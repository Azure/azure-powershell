### Example 1: List members of an Application Network resource
```powershell
Get-AzAppNetworkMember -AppLinkName appnet-test-01 -ResourceGroupName test_rg
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
member-02 AKS         Succeeded         test_rg
```

Lists all members of the `appnet-test-01` Application Network resource.

### Example 2: Get a member of an Application Network resource
```powershell
Get-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Gets the `member-01` member of the `appnet-test-01` Application Network resource.
