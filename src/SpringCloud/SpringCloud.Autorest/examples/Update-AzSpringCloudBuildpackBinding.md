### Example 1: Update a buildpack binding
```powershell
Update-AzSpringCloudBuildpackBinding -ResourceGroupName springcloudrg -ServiceName sspring-portal0 -BuilderName default -Name binging01 -BindingType 'AppDynamics'
```

```output
Name      SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----      -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
binging01 4/22/2025 2:24:28 AM tester@microsoft.com User                    4/22/2025 3:24:28 AM     tester@microsoft.com     User                         springcloudrg
```

This command updates a buildpack binding.