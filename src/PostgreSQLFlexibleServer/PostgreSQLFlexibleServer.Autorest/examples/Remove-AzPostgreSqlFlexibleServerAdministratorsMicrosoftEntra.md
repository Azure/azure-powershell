### Example 1: Remove a Microsoft Entra administrator
```powershell
Remove-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -ObjectId "12345678-1234-1234-1234-123456789abc"
```

Removes the Microsoft Entra administrator with the specified object ID from the PostgreSQL Flexible Server.

### Example 2: Remove all Microsoft Entra administrators
```powershell
Remove-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "development-rg" -ServerName "dev-postgresql-01" -Force
```

Removes all Microsoft Entra administrators from the PostgreSQL Flexible Server without prompting for confirmation.

