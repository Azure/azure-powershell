### Example 1:
```powershell
Get-AzStackHciUpdateSummary -ClusterName 'test-cluster' -ResourceGroupName 'test-rg'
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy                SystemDataCreatedByType
----    -------------------  -------------------                -----------------------
default 7/8/2024 10:25:44 AM 1412d89f-b8a8-4111-b4fd-e82905cbd85d       Application
```

Gets the Cluster Update Summary
