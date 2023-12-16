### Example 1: Creating or Updating a Remote Rendering Account.
```powershell
New-AzMixedRealityRemoteRenderingAccount -Name azpstestrenderingaccount -ResourceGroupName azps_test_group -Location eastus -IdentityType 'SystemAssigned'
```

```output
Location Name                     ResourceGroupName
-------- ----                     -----------------
eastus   azpstestrenderingaccount azps_test_group
```

Creating or Updating a Remote Rendering Account.