### Example 1: Create an in-memory object for FilteringTag
```powershell
New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
```

```output
Action  Name        Value
------  ----        -----
Include Environment Prod
```

This command creates an in-memory object for FilteringTag.