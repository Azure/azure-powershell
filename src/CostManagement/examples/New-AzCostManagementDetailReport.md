### Example 1: Request to generate a cost details report for the provided date range, billing period (Only enterprise customers) or Invoice Id asynchronously at a certain scope
```powershell
New-AzCostManagementDetailReport -Scope "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Metric 'ActualCost' -TimePeriodStart "2022-10-01" -TimePeriodEnd "2022-10-20"
```

```output
```

This command requests to generate a cost details report for the provided date range, billing period (Only enterprise customers) or Invoice Id asynchronously at a certain scope.