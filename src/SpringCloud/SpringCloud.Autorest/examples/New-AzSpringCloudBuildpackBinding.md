### Example 1: Create or update a buildpack binding
```powershell
New-AzSpringCloudBuildpackBinding -ResourceGroupName springcloudrg -ServiceName sspring-portal0 -BuilderName default -Name binging01 -BindingType 'AppDynamics'
```

```output
Name      SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----      -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
binging01 7/22/2022 2:24:28 AM v-diya@microsoft.com User                    7/22/2022 2:24:28 AM     v-diya@microsoft.com     User                         springcloudrg
```

Create or update a buildpack binding.