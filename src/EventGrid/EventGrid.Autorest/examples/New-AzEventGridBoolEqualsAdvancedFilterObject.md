### Example 1: Create an in-memory object for BoolEqualsAdvancedFilter.
```powershell
New-AzEventGridBoolEqualsAdvancedFilterObject -Key "testKey" -Value:$true
```

```output
Key     OperatorType Value
---     ------------ -----
testKey BoolEquals   True
```

Create an in-memory object for BoolEqualsAdvancedFilter.