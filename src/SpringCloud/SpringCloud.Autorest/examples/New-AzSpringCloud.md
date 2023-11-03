### Example 1: Create or update a new standard spring cloud service 
```powershell
New-AzSpringCloud -ResourceGroupName springcloudrg -Name spring-pwsh01 -Location eastus
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModified
                                                                                                 At
-------- ----                ------------------- -------------------     ----------------------- ----------------------
eastus   springcloud-service 2022/6/28 7:59:45   ******@microsoft.com    User                    2022/6/28 7:59:45
```

Create or update a new standard spring cloud service.

### Example 2: Create or update a new enterprise spring cloud service 
```powershell
New-AzSpringCloud -ResourceGroupName springcloudrg -Name espring-pwsh01 -Location eastus -SkuTier "Enterprise" -SkuName "E0"
```

```output
Location Name           SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----           -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   espring-pwsh01 7/22/2022 7:35:40 AM v-diya@microsoft.com User                    7/22/2022 7:35:40 AM     v-diya@microsoft.com     User                         springcloudrg
```

Create or update a new enterprise spring cloud service .