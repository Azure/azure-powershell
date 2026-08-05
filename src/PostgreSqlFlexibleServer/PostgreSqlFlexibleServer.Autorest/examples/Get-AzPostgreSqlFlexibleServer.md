### Example 1: List flexible servers in subscription explicitly specified
```powershell
Get-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server-01                        example-resource-group-01                Australia East       Standard_D4ads_v5    GeneralPurpose  adminlogin01              128
example-server-02                        example-resource-group-02                Canada Central       Standard_D4ds_v4     GeneralPurpose  adminlogin02              32
example-server-03                        example-resource-group-03                Japan West           Standard_B1ms        Burstable       adminlogin03              64
example-server-04                        example-resource-group-01                Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin04              4096
example-server-05                        example-resource-group-04                Central US           Standard_E2ds_v4     MemoryOptimized adminlogin05              128
```

Gets Azure Database for PostgreSQL flexible servers in subscription explicitly passed as an argument. If subscription is not passed explicitly, it's taken from default context.

### Example 2: List flexible servers in specific resource group of a subscription
```powershell
Get-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group-01
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server-01                        example-resource-group-01                Australia East       Standard_D4ads_v5    GeneralPurpose  adminlogin01              128
example-server-04                        example-resource-group-01                Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin04              4096
```

Gets Azure Database for PostgreSQL flexible servers in subscription and resource group explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 3: Get flexible server corresponding to specific name, resource group and subscription
```powershell
Get-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -Name example-server
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server                           example-resource-group                   Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin                4096
```

Gets Azure Database for PostgreSQL flexible server with name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 4: Get flexible server corresponding to specific resource identifier
```powershell
$ID = "/subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server"
Get-AzPostgreSqlFlexibleServer -InputObject $ID
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-server                           example-resource-group                   Southeast Asia       Standard_D4ads_v5    GeneralPurpose  adminlogin                4096
```

Gets Azure Database for PostgreSQL flexible server with the specific resource identifier of the server, explicitly passed as an argument.
