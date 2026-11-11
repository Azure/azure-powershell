### Example 1: Update the release channel of an Application Network member
```powershell
Update-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -FullyManagedUpgradeProfileReleaseChannel Stable
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Updates the fully managed release channel of the `member-01` Application Network member to `Stable`.

### Example 2: Update the Application Network version of a self managed member
```powershell
Update-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -SelfManagedUpgradeProfileVersion 1.4
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Updates the self managed Application Network version of the `member-01` member to `1.4`.
