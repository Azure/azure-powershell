### Example 1: List all users in a Confluent organization
```powershell
Get-AzConfluentAccessUser -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          Email                   FullName        Status
--          -----                   --------        ------
u-abc123    admin@contoso.com       Admin User      ACTIVE
u-def456    developer@contoso.com   Dev User        ACTIVE
```

This command lists all users in the specified Confluent organization.

### Example 2: List users with search filters
```powershell
$searchFilters = @{SearchFilters = @{Email = "admin@contoso.com"}}
Get-AzConfluentAccessUser -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -SearchFilter $searchFilters
```

This command lists users filtered by email address.

