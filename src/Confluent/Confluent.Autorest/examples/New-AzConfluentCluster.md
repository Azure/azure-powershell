### Example 1: Create a new Kafka cluster
```powershell
New-AzConfluentCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -Name prod-cluster -Type BASIC -Region eastus -AvailabilityZone SINGLE_ZONE
```

```output
Id          Name            Type      Region      Status
--          ----            ----      ------      ------
lkc-new123  prod-cluster    BASIC     eastus      PROVISIONING
```

This command creates a new Kafka cluster in the specified environment.

### Example 2: Create a multi-zone cluster
```powershell
New-AzConfluentCluster -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -Name ha-cluster -Type STANDARD -Region westus2 -AvailabilityZone MULTI_ZONE
```

This command creates a highly available Kafka cluster with multi-zone deployment.

