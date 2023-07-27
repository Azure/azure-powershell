### Example 1: Create or update a new standard spring cloud service 
```powershell
New-AzSpring -ResourceGroupName azps_test_group_spring -Name azps-spring -Location eastus
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModified
                                                                                                 At
-------- ----                ------------------- -------------------     ----------------------- ----------------------
eastus   Spring-service 2022/6/28 7:59:45   ******@microsoft.com    User                    2022/6/28 7:59:45
```

Create or update a new standard spring cloud service.

### Example 2: Create or update a new enterprise spring cloud service 
```powershell
New-AzSpring -ResourceGroupName azps_test_group_spring -Name eazps-spring -Location eastus -SkuTier "Enterprise" -SkuName "E0"
```

```output
Location Name           SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----           -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   eazps-spring 7/22/2022 7:35:40 AM v-diya@microsoft.com User                    7/22/2022 7:35:40 AM     v-diya@microsoft.com     User                         azps_test_group_spring
```

Create or update a new enterprise spring cloud service .