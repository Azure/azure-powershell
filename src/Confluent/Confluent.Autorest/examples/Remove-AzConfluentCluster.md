### Example 1: Delete confluent cluster by ID
```powershell
Remove-AzConfluentCluster `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -Id "lkc-xxxxx"
```

```output
""
```

This command deletes confluent cluster by ID