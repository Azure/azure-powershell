### Example 1: List all environments in a Confluent organization
```powershell
Get-AzConfluentAccessEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          Name            DisplayName     StreamGovernanceConfig
--          ----            -----------     ----------------------
env-abc123  prod-env        Production      Essentials
env-def456  staging-env     Staging         Advanced
env-ghi789  dev-env         Development     Essentials
```

This command lists all available environments in the specified Confluent organization.

### Example 2: List environments with search criteria
```powershell
$searchFilters = @{SearchFilters = @{PageSize = 10}}
Get-AzConfluentAccessEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -SearchFilter $searchFilters
```

This command lists environments in the organization with pagination support.

