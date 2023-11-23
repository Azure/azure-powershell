### Example 1: Get a Redis Enterprise cache by name
```powershell
Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup" -Name "MyCache"
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```

This command gets information about the Redis Enterprise cache named MyCache.

### Example 2: List every Redis Enterprise cache in a resource group
```powershell
Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup"
```

```output
Location Name     Type                            Zone      Database
-------- ----     ----                            ----      --------
East US  MyCache1 Microsoft.Cache/redisEnterprise           {default}
East US  MyCache2 Microsoft.Cache/redisEnterprise {1, 2, 3} {default}

```

This command gets information about every Redis Enterprise cache in the specified resource group.

### Example 3: List every Redis Enterprise cache in a subscription
```powershell
Get-AzRedisEnterpriseCache
```

```output
Location    Name     Type                            Zone      Database
--------    ----     ----                            ----      --------
East US     MyCache1 Microsoft.Cache/redisEnterprise           {default}
East US     MyCache2 Microsoft.Cache/redisEnterprise {1, 2, 3} {default}
West US     MyCache3 Microsoft.Cache/redisEnterprise           {default}
Central US  MyCache4 Microsoft.Cache/redisEnterprise {1, 2, 3} {default}

```

This command gets information about every Redis Enterprise cache in the current subscription.