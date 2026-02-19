### Example 1: List all schema registry clusters
```powershell
Get-AzConfluentOrganizationSchemaRegistryCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123
```

```output
Id          Name               Package     Region    Status
--          ----               -------     ------    ------
lsrc-123    prod-schema-reg    ESSENTIALS  eastus    PROVISIONED
lsrc-456    staging-schema-reg ADVANCED    westus2   PROVISIONED
```

This command lists all schema registry clusters in the specified environment.

### Example 2: Get specific schema registry cluster
```powershell
Get-AzConfluentOrganizationSchemaRegistryCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lsrc-123
```

This command retrieves details of a specific schema registry cluster.

