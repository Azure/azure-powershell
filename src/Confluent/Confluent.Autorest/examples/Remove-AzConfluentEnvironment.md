### Example 1: Delete Confluent Environment by ID
```powershell
Remove-AzConfluentEnvironment `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -Id "env-exampleenv001"
```

```output
""
```

This command delete confluent environment by ID