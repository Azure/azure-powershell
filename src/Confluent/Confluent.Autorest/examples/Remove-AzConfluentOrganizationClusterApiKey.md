### Example 1: Delete API key of a kafka or schema registry cluster
```powershell
Remove-AzConfluentOrganizationClusterApiKey `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -ApiKeyId "ABCDEFGHIJKLMNOP"
```

```output
""
```

This command deletes API key of a kafka or schema registry cluster