### Example 1: List all template under a subscription
```powershell
Get-AzImageBuilderTemplate
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----                ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
eastus   bez-test-img-temp
eastus   bez-test-img-temp12
eastus   bez-test-img-temp13
eastus   test-img-temp
```

This command lists all template under a subscription.

### Example 2: List all template under a resource group
```powershell
Get-AzImageBuilderTemplate -ResourceGroupName bez-rg
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----                ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
eastus   bez-test-img-temp
eastus   bez-test-img-temp12
eastus   bez-test-img-temp13
eastus   test-img-temp
```

This command lists all template under a resource group.

### Example 3: Get a template under a resource group
```powershell
Get-AzImageBuilderTemplate -Name test-img-temp -ResourceGroupName bez-rg
```

```output
Location Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----          ------------------- ------------------- ----------------------- ------------------------ ------------------ 
eastus   test-img-temp
```

This command gets a template under a resource group.

