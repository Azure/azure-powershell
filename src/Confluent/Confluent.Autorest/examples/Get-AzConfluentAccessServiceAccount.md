### Example 1: List all service accounts in a Confluent organization
```powershell
Get-AzConfluentAccessServiceAccount -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          Name                Description
--          ----                -----------
sa-abc123   app-service-account Service account for application
sa-def456   ci-cd-account       Service account for CI/CD pipeline
```

This command lists all service accounts in the specified Confluent organization.

### Example 2: List service accounts with search filters
```powershell
$searchFilters = @{SearchFilters = @{PageSize = 10}}
Get-AzConfluentAccessServiceAccount -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -SearchFilter $searchFilters
```

This command lists service accounts with pagination support.

