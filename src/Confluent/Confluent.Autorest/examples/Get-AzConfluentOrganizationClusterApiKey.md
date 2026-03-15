### Example 1: List all cluster API keys
```powershell
Get-AzConfluentOrganizationClusterApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -ClusterId lkc-abc123
```

```output
Id          Name              ClusterId    Owner
--          ----              ---------    -----
key-123     prod-api-key      lkc-abc123   User:u-123
key-456     staging-api-key   lkc-abc123   User:u-456
```

This command lists all API keys for the specified Kafka cluster.

### Example 2: Get specific API key by cluster
```powershell
Get-AzConfluentOrganizationClusterApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -ClusterId lkc-abc123
```

This command retrieves API keys associated with a specific cluster.

