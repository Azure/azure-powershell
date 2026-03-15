### Example 1: Update a Kafka cluster configuration
```powershell
Set-AzConfluentCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -CkuCount 2
```

```output
Id          Name            Type      CkuCount  Status
--          ----            ----      --------  ------
lkc-abc123  prod-cluster    STANDARD  2         PROVISIONED
```

This command updates the CKU count for a Kafka cluster.

### Example 2: Update cluster with tags
```powershell
Set-AzConfluentCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -Tag @{Environment="Production"; Team="DataPlatform"}
```

This command updates cluster metadata with custom tags.

