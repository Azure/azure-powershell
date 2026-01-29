### Example 1: Enable threat protection for a PostgreSQL Flexible Server
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -ThreatProtectionName "Default" -State "Enabled"
```

```output
Name              : Default
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
State             : Enabled
CreationTime      : 2024-01-15T10:30:00Z
EmailAddresses    : {}
DisabledAlerts    : {}
EmailAccountAdmins: False
```

Enables Microsoft Defender for the PostgreSQL Flexible Server with default settings.

### Example 2: Enable threat protection with custom settings
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -ThreatProtectionName "Default" -State "Enabled" -EmailAddress @("admin@contoso.com", "security@contoso.com") -EmailAccountAdmin $true -DisabledAlert @("Sql_Injection_Vulnerability")
```

```output
Name              : Default
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
State             : Enabled
CreationTime      : 2024-01-20T14:15:00Z
EmailAddresses    : {"admin@contoso.com", "security@contoso.com"}
DisabledAlerts    : {"Sql_Injection_Vulnerability"}
EmailAccountAdmins: True
```

Enables Microsoft Defender for the PostgreSQL Flexible Server with custom notification settings and disabled alerts.

