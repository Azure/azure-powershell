### Example 1: List all environments in organization
```powershell
Get-AzConfluentOrganizationEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          Name            DisplayName     StreamGovernanceConfig
--          ----            -----------     ----------------------
env-abc123  prod-env        Production      Essentials
env-def456  staging-env     Staging         Advanced
env-ghi789  dev-env         Development     Essentials
```

This command lists all environments in the specified Confluent organization.

### Example 2: Get specific environment details
```powershell
Get-AzConfluentOrganizationEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123
```

This command retrieves details of a specific environment.

