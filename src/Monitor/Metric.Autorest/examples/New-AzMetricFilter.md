### Example 1: Create a metric dimension filter
```powershell
New-AzMetricFilter -Dimension City -Operator eq -Value "Seattle","New York"
```

```output
City eq 'Seattle' or City eq 'New York'
```

This command creates metric dimension filter of the format "City eq 'Seattle' or City eq 'New York'".

