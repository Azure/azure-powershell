### Example 1: Join an AKS cluster to an Application Network using fully managed upgrades
```powershell
New-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -Location westus2 `
  -ClusterType AKS `
  -MetadataResourceId '/subscriptions/bc7e0da9-5e4c-4a91-9252-9658837006cf/resourcegroups/test-rg/providers/Microsoft.ContainerService/managedClusters/test-member1' `
  -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Stable
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Joins an AKS cluster to the `appnet-test-01` Application Network as member `member-01`, using the fully managed upgrade mode on the `Stable` release channel.

### Example 2: Join an AKS cluster to an Application Network using self managed upgrades
```powershell
New-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -Location westus2 `
  -ClusterType AKS `
  -MetadataResourceId '/subscriptions/bc7e0da9-5e4c-4a91-9252-9658837006cf/resourcegroups/test-rg/providers/Microsoft.ContainerService/managedClusters/test-member1' `
  -UpgradeProfileMode SelfManaged -SelfManagedUpgradeProfileVersion 1.4
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Joins an AKS cluster to the `appnet-test-01` Application Network as member `member-01`, using the self managed upgrade mode pinned to Application Network version `1.4`.
