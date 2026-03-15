### Example 1: Remove a Kafka cluster
```powershell
Remove-AzConfluentCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123
```

This command removes a Kafka cluster from the specified environment.

### Example 2: Remove cluster without confirmation
```powershell
Remove-AzConfluentCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-def456 -Force
```

This command removes a Kafka cluster without prompting for confirmation.

