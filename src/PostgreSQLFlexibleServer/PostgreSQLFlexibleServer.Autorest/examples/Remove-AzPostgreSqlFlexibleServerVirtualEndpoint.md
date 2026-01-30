### Example 1: Remove a virtual endpoint
```powershell
Remove-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -VirtualEndpointName "old-endpoint"
```

Removes the specified virtual endpoint from the PostgreSQL Flexible Server. This will disconnect any applications using this endpoint.

### Example 2: Remove a virtual endpoint without confirmation
```powershell
Remove-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "development-rg" -ServerName "dev-postgresql-01" -VirtualEndpointName "test-endpoint" -Force
```

Removes the virtual endpoint without prompting for confirmation. Use with caution as this will immediately disconnect applications using this endpoint.

