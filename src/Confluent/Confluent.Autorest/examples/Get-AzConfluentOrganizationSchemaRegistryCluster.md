### Example 1: Get Schema registry cluster by Id
```powershell
Get-AzConfluentOrganizationSchemaRegistryCluster -ClusterId lkc-examplekafka1 -EnvironmentId env-exampleenv001 -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Get-AzConfluentOrganizationSchemaRegistryCluster_Get: Error occurred while retrieving schema registry cluster for resource /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/schemaRegistryClusters/lkc-examplekafka1/. Please try again!
```

This command fetches schema registry cluster by ID