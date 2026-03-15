### Example 1: List all clusters in a Confluent organization
```powershell
Get-AzConfluentAccessCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          Name            Type      CloudProvider  Region      Status
--          ----            ----      -------------  ------      ------
lkc-abc123  prod-cluster    BASIC     AZURE          eastus      PROVISIONED
lkc-def456  staging-cluster STANDARD  AZURE          westus2     PROVISIONED
```

This command lists all Kafka clusters accessible in the specified Confluent organization.

### Example 2: Get cluster details with search filters
```powershell
$searchFilters = @{SearchFilters = @{Environment = "env-abc123"}}
Get-AzConfluentAccessCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -SearchFilter $searchFilters
```

This command lists clusters filtered by environment ID.

