### Example 1: List all clusters in organization
```powershell
Get-AzConfluentOrganizationCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123
```

```output
Id          Name            Type      Availability  Status
--          ----            ----      ------------  ------
lkc-abc123  prod-cluster    BASIC     SINGLE_ZONE   PROVISIONED
lkc-def456  staging-cluster STANDARD  MULTI_ZONE    PROVISIONED
```

This command lists all Kafka clusters in the specified environment.

### Example 2: Get specific cluster details
```powershell
Get-AzConfluentOrganizationCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123
```

This command retrieves details of a specific Kafka cluster.

