### Example 1: Delete Connector by name
```powershell
Remove-AzConfluentConnector `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "conn_3"
```

```output
""
```

This command delete connector by name