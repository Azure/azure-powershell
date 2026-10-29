### Example 1: Create or replace an Application Network member
```powershell
Set-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -Location westus2 `
  -ClusterType AKS `
  -MetadataResourceId '/subscriptions/bc7e0da9-5e4c-4a91-9252-9658837006cf/resourcegroups/test-rg/providers/Microsoft.ContainerService/managedClusters/test-member1' `
  -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Stable
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Creates or replaces the `member-01` member of the `appnet-test-01` Application Network resource with the fully managed upgrade profile.
