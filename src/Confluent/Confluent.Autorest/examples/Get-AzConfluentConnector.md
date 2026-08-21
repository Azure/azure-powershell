### Example 1: List all connectors under the cluster in the Environment of an Organization in the Resource Group
```powershell
Get-AzConfluentConnector -ClusterId lkc-examplekafka1 -EnvironmentId env-exampleenv001 -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
conn_1
conn_2
```

This command list all connectors under the cluster in the environment of an organization in the resource group